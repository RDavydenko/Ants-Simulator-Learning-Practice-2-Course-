using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Ants.Core.Models;
using Ants.Core.Modifications;
using Ants.Visual.Extensions;
using Ants.Visual.Models;

namespace Ants.Visual
{
	public partial class MainForm : Form
	{
		private Settings gameSettings;
		private Map map;

		private int x;
		private int y;

		private Graphics graphics;
		// Ширина и высота квадратика на поле
		private int width;
		private int height;

		private int initialWidth;
		private int statsWidth;
		private List<Label> statsLabels;

		private GameState state;
		private GameState State
		{
			set 
			{
				if (value == GameState.Started)
				{
					intervalInput.Enabled = false;
					startButton.Enabled = false;
					pauseButton.Enabled = true;
					continueButton.Enabled = false;
					resetButton.Enabled = true;
					configureButton.Enabled = false;
				}
				else if (value == GameState.Paused)
				{
					intervalInput.Enabled = true;
					startButton.Enabled = false;
					pauseButton.Enabled = false;
					continueButton.Enabled = true;
					resetButton.Enabled = true;
					configureButton.Enabled = true;
				}
				state = value;
			}
			get => state;
		}

		public MainForm()
		{
			InitializeComponent();

			Width = 618;

			initialWidth = Width;
			statsWidth = 950;
			statsLabels = new List<Label>();

			gameSettings = new Settings();
		}

		private void Configure()
		{
			x = 50;
			y = 50;

			map = new Map(x, y, gameSettings);

			map.AddAntHill(1, 1, AntTeam.Red, 400);
			map.AddAntHill(1, 2, AntTeam.Red, 0);
			map.AddAntHill(2, 1, AntTeam.Red, 0);
			map.AddAntHill(2, 2, AntTeam.Red, 0);

			map.AddAntHill(x - 2, y - 2, AntTeam.Black, 400);
			map.AddAntHill(x - 2, y - 3, AntTeam.Black, 0);
			map.AddAntHill(x - 3, y - 2, AntTeam.Black, 0);
			map.AddAntHill(x - 3, y - 3, AntTeam.Black, 0);

			map.AddAntHill(x - 2, 1, AntTeam.Yellow, 400);
			map.AddAntHill(x - 2, 2, AntTeam.Yellow, 0);
			map.AddAntHill(x - 3, 1, AntTeam.Yellow, 0);
			map.AddAntHill(x - 3, 2, AntTeam.Yellow, 0);

			map.AddAntHill(1, y - 2, AntTeam.Blue, 400);
			map.AddAntHill(1, y - 3, AntTeam.Blue, 0);
			map.AddAntHill(2, y - 2, AntTeam.Blue, 0);
			map.AddAntHill(2, y - 3, AntTeam.Blue, 0);

			var r = new Random();
			var count = (x - 4) * (y - 4) / 2;
			for (int i = 0; i < count; i++)
			{
				map.AddFood(r.Next(4, x - 4), r.Next(4, y - 4));
			}

			// Модификации
			var foodSpawner = new FoodSpawner();
			map.AfterTick += foodSpawner.SpawnFood;
		}

		private void Start()
		{
			State = GameState.Started;

			// Конфигурация игры
			Configure();

			pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
			graphics = Graphics.FromImage(pictureBox.Image);

			width = pictureBox.Width / x;
			height = pictureBox.Height / y;

			gameTimer.Interval = (int)intervalInput.Value; // 1000 - Секунда (1 fps), 100 - (10 fps), 50 - (20 fps), 25 - (40 fps), 17 - (60 fps)
			gameTimer.Start();
		}

		private void Update(object sender, EventArgs e)
		{
			Rerender();
			map.NextTick();
		}

		private void Rerender()
		{
			for (int i = 0; i < x; i++)
			{
				for (int j = 0; j < y; j++)
				{
					bool needDrawRect = false;
					if (map.Cells[i, j].Entities.FirstOrDefault(x => x is AntHill) is AntHill antHill)
					{
						needDrawRect = true;
						graphics.FillRectangle(antHill.GetBrush(), i * width, j * height, width, height);
					}
					else if (map.Cells[i, j].Entities.FirstOrDefault(x => x is Food) != null)
					{
						needDrawRect = true;
						graphics.FillRectangle(Brushes.Green, i * width, j * height, width, height);
					}

					if (map.Cells[i, j].Entities.FirstOrDefault(x => x is Ant) is Ant ant)
					{
						graphics.FillEllipse(ant.GetBrush(), i * width, j * height, width, height);
					}

					// Цвет фона
					if (map.Cells[i, j].IsEmpty)
					{
						graphics.FillRectangle(Brushes.WhiteSmoke, i * width, j * height, width, height);
					}

					if (needDrawRect)
					{
						// Сеточка на муравейник
						graphics.DrawRectangle(Pens.Black, i * width, j * height, width, height);
					}
				}
			}
			pictureBox.Refresh();
		}

		// Управление игровым процессом
		private void Start(object sender, EventArgs e) => Start();
		private void Continue(object sender, EventArgs e) 
		{
			State = GameState.Started;
			gameTimer.Interval = (int) intervalInput.Value;
			gameTimer.Start();
		}
		private void Pause(object sender, EventArgs e)
		{
			State = GameState.Paused;
			gameTimer.Stop();
			Rerender();
		}
		private void Reset(object sender, EventArgs e)
		{
			State = GameState.Started;
			Start();
		}

		/// <summary>
		/// Нажатие на игровую клетку с целью получения подробной информации про Entity
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void AboutEntity(object sender, EventArgs e)
		{
			if (State == GameState.Paused)
			{
				var (i, j) = ((e as MouseEventArgs).X / width, (e as MouseEventArgs).Y / height);
				var about = map.Cells[i, j].Entities
					.OrderByDescending(x => x is Ant)
					.ThenByDescending(x => x is AntHill)
					.FirstOrDefault()
					?.About();
				if (about != null)
				{
					Width = statsWidth;
					statsLabels.ForEach(x => x.Dispose());
					statsLabels.Clear();
					var labels = about.Properties.Select((x, i) => 
						new Label 
						{ 
							Parent = this, 
							Text = $"{x.Key}: {x.Value}", 
							Width = 200,
							Location = new System.Drawing.Point(635, i * 25 + 45) 
						});
					statsLabels.AddRange(labels);
				}
			}
		}

		private void HideStatsButton_Click(object sender, EventArgs e)
		{
			Width = initialWidth;
		}

		private void ConfigureButton_Click(object sender, EventArgs e)
		{
			var settingsForm = new SettingsForm(gameSettings);
			settingsForm.ShowDialog();
		}
	}
}
