using System;
using System.Collections.Generic;
using System.Linq;

namespace Ants.Core.Models
{
	/// <summary>
	/// Карта игрового мира
	/// </summary>
	public class Map
	{
		private readonly Dictionary<int, Point[]> variants;

		public Map(int width, int heigth, Settings settings = null)
		{
			variants = new Dictionary<int, Point[]>();

			Cells = new GameCell[width, heigth];

			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < heigth; j++)
				{
					Cells[i, j] = new GameCell();
				}
			}

			Width = width;
			Height = heigth;

			Settings = settings ?? new Settings();
		}

		public event Action<Map> BeforeTick;
		public event Action<Map> AfterTick;

		public int Width { get; }
		public int Height { get; }
		public GameCell[,] Cells { get; }
		public Settings Settings { get; }

		public void NextTick()
		{
			ResetStepFlags();

			BeforeTick?.Invoke(this);

			for (int i = 0; i < Width; i++)
				for (int j = 0; j < Height; j++)
					Cells[i, j].Do();

			AfterTick?.Invoke(this);
		}

		public Ant AddAnt(int x, int y, AntHill antHill, int stamine = 100)
		{
			var ant = new Ant(x, y, stamine, this, antHill);
			if (AddEntity(ant))
			{
				return ant;
			}
			return null;
		}

		public AntHill AddAntHill(int x, int y, AntTeam team, int startFood = 100)
		{
			var antHill = new AntHill(x, y, startFood, this, team);
			AddEntity(antHill);
			return antHill;
		}

		public void AddFood(int x, int y, int? count = null)
		{
			count ??= Settings.FoodSettings.Count;
			AddEntity(new Food(x, y, this, count.Value));
		}

		internal BehaviourType GetBehaviour(AntTeam team1, AntTeam team2)
		{
			return Settings.BehaviourMap.GetBehaviour(team1, team2);
		}

		internal void TransformToFood(Entity entity)
		{
			RemoveEntity(entity);
			AddFood(entity.Position.X, entity.Position.Y, 50);
		}

		internal void RemoveEntity(Entity entity)
		{
			var indexes = GetEntityIndexes(entity);
			if (indexes != (-1, -1))
			{
				Cells[indexes.I, indexes.J].Entities.Remove(entity);
			}
		}

		internal List<ScanResult> Scan(Point position, int radius = 1)
		{
			var list = new List<ScanResult>();
			var diffs = GetVariants(radius);
			foreach (var dif in diffs)
			{
				var newPos = new Point(position.X + dif.X, position.Y + dif.Y);
				if (IsValidCoords(newPos))
				{	
					list.Add(new ScanResult(newPos, Cells[newPos.X, newPos.Y].Entities.OrderByDescending(x => x is Food).FirstOrDefault()));
				}
			}
			return list;
		}

		internal void UpdateEntityPosition(Entity entity)
		{
			var indexes = GetEntityIndexes(entity);
			if (indexes != (-1, -1))
			{
				Cells[indexes.I, indexes.J].Entities.Remove(entity);
				Cells[entity.Position.X, entity.Position.Y].Entities.Add(entity);
			}
		}

		private bool AddEntity(Entity entity)
		{
			if (IsValidCoords(entity.Position))
			{
				Cells[entity.Position.X, entity.Position.Y].Entities.Add(entity);
				return true;
			}
			return false;
		}

		private bool IsValidCoords(Point coords)
		{
			return (coords.X >= 0 && coords.X < Width && coords.Y >= 0 && coords.Y < Height);
		}

		private void ResetStepFlags()
		{
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					Cells[i, j].Entities.ForEach(x => x.ResetStepFlag());
				}
			}
		}

		private (int I, int J) GetEntityIndexes(Entity entity)
		{
			for (int i = 0; i < Width; i++)
				for (int j = 0; j < Height; j++)
					if (Cells[i, j].Entities.Contains(entity))
					{
						return (i, j);
					}
			return (-1, -1);
		}

		private Point[] GetVariants(int radius)
		{
			if (!variants.ContainsKey(radius))
			{
				var sideSize = radius * 2 + 1;
				var vars = new Point[sideSize * sideSize - 1];
				var index = 0;

				for (int i = -radius; i <= radius; i++)
				{
					for (int j = -radius; j <= radius; j++)
					{
						if (i == 0 && j == 0)
						{
							continue;
						}
						vars[index++] = new Point(i, j);
					}
				}

				variants[radius] = vars;
			}

			return variants[radius];
		}
	}
}
