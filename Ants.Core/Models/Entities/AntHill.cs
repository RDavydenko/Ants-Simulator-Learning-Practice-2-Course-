using System;
using System.Linq;
using Ants.Core.Extenstions;

namespace Ants.Core.Models
{
	public class AntHill : Food
	{
		private readonly static Random rand = new Random();

		public AntTeam Team { get; }
		public int BaseCount { get; }

		public AntHill(int x, int y, int startFood, Map map, AntTeam team)
			: base(x, y, map, startFood)
		{
			Team = team;
			BaseCount = map.Settings.AntHillSettings.BaseCount;
		}

		public override void Do()
		{
			StepFlag = true;

			var foodPerSpawnAnt = map.Settings.AntHillSettings.FoodPerSpawnAnt;
			var foodPerSpawnAntHill = map.Settings.AntHillSettings.FoodPerSpawnAntHill;

			if (Count - BaseCount >= foodPerSpawnAntHill)
			{
				if (rand.Next(0, map.Settings.AntHillSettings.ChanceSpawnAntHill) == 0)
				{
					var positions = map.Scan(Position).Where(x => x.Entity is not AntHill);
					if (positions.Any())
					{
						var coords = positions.Random().Coords;
						map.AddAntHill(coords.X, coords.Y, Team);
					}

					Count -= foodPerSpawnAntHill;
				}
			}

			// Спавн новых муравьев
			if (Count >= foodPerSpawnAnt)
			{
				if (rand.Next(0, map.Settings.AntHillSettings.ChanceSpawnAnt) == 0)
				{
					var positions = map.Scan(Position);
					if (positions.Any())
					{
						var coords = positions[rand.Next(0, positions.Count)].Coords;
						// Спавн муравья
						map.AddAnt(coords.X, coords.Y, this);
					}
					Count -= foodPerSpawnAnt;
				}
			}
		}

		internal void AddFood(int food)
		{
			Count += food;
		}

		public override string ToString() => "AntHill";
	}
}
