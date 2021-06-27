using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ants.Core.Models;

namespace Ants.Visual
{
	public partial class SettingsForm : Form
	{
		private readonly Settings gameSettings;
		private readonly List<(NumericUpDown, Expression<Func<AntSettings, int>>)> antFieldsResolver;
		private readonly List<(NumericUpDown, Expression<Func<AntHillSettings, int>>)> antHillFieldsResolver;
		private readonly List<(NumericUpDown, Expression<Func<FoodSettings, int>>)> foodFieldsResolver;

		public SettingsForm(Settings gameSettings)
		{
			InitializeComponent();

			this.gameSettings = gameSettings;
			antFieldsResolver = new List<(NumericUpDown, Expression<Func<AntSettings, int>>)>()
			{
				(antMaxFood, (ant) => ant.MaxFood),
				(antMaxStamina, (ant) => ant.MaxStamina),
				(antMaxUpgradedFood, (ant) => ant.MaxUpgradedFood),
				(antMaxUpgradedStamina, (ant) => ant.MaxUpgradedStamina),
				(antMaxUpgradedVision, (ant) => ant.MaxUpgradedVision),
				(antAgePerVisionUpgrade, (ant) => ant.AgePerVisionUpgrade),
				(antStaminaPerStep, (ant) => ant.StaminaPerStep)
			};

			antHillFieldsResolver = new List<(NumericUpDown, Expression<Func<AntHillSettings, int>>)>()
			{
				(antHillBaseCount, (anthill) => anthill.BaseCount),
				(antHillFoodPerSpawnAnt, (anthill) => anthill.FoodPerSpawnAnt),
				(antHillFoodPerSpawnAntHill, (anthill) => anthill.FoodPerSpawnAntHill),
				(antHillChanceSpawnAnt, (anthill) => anthill.ChanceSpawnAnt),
				(antHillChanceSpawnAntHill, (anthill) => anthill.ChanceSpawnAntHill)
			};

			foodFieldsResolver = new List<(NumericUpDown, Expression<Func<FoodSettings, int>>)>()
			{
				(foodCount, (food) => food.Count),
				(foodChanceSpawn, (food) => food.ChanceSpawn),
				(foodChanceGrowth, (food) => food.ChanceGrowth)
			};

			InitializeInputs();
		}

		private void InitializeInputs()
		{
			InitializeInputs(antFieldsResolver, gameSettings.AntSettings);
			InitializeInputs(antHillFieldsResolver, gameSettings.AntHillSettings);
			InitializeInputs(foodFieldsResolver, gameSettings.FoodSettings);
			InitializeBehaviour();
		}

		private void InitializeBehaviour()
		{
			if (gameSettings.BehaviourMap.AbsoluteBehaviour.HasValue)
			{
				switch (gameSettings.BehaviourMap.AbsoluteBehaviour.Value)
				{
					case BehaviourType.Neutral:
						allNeutralsButton.Checked = true;
						break;
					case BehaviourType.Friend:
						allFriendsButton.Checked = true;
						break;
					case BehaviourType.Enemy:
						allEnemiesButton.Checked = true;
						break;

					case BehaviourType.None:
					default:
						break;
				}
			}
		}

		private void InitializeInputs<T>(List<(NumericUpDown, Expression<Func<T, int>>)> inputs, T settings)
		{
			foreach (var input in inputs)
			{
				input.Item1.Value = input.Item2.Compile()(settings);
			}
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			SetValuesFromInputs(antFieldsResolver, gameSettings.AntSettings);
			SetValuesFromInputs(antHillFieldsResolver, gameSettings.AntHillSettings);
			SetValuesFromInputs(foodFieldsResolver, gameSettings.FoodSettings);
			SetValuesFromCheckBoxes();
			this.Close();
		}

		private void SetValuesFromCheckBoxes()
		{
			if (allEnemiesButton.Checked)
				gameSettings.BehaviourMap.AbsoluteBehaviour = BehaviourType.Enemy;
			else if (allFriendsButton.Checked)
				gameSettings.BehaviourMap.AbsoluteBehaviour = BehaviourType.Friend;
			else if (allNeutralsButton.Checked)
				gameSettings.BehaviourMap.AbsoluteBehaviour = BehaviourType.Neutral;
			else
				gameSettings.BehaviourMap.AbsoluteBehaviour = null;
		}

		private void SetValuesFromInputs<T>(List<(NumericUpDown, Expression<Func<T, int>>)> inputs, T settings)
		{
			foreach (var input in inputs)
			{
				if (input.Item2.Body is MemberExpression memberSelectorExpression)
				{
					if (memberSelectorExpression.Member is PropertyInfo property)
					{
						property.SetValue(settings, (int)input.Item1.Value, null);
					}
				}
			}
		}
	}
}
