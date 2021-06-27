using System;
using System.Linq;
using System.Collections.Generic;
using Ants.Core.Extenstions;
using Ants.Core.Models;

namespace Ants.Core.Modifications
{
	public class FoodSpawner
	{
		private readonly static Random rand = new Random();

		public void SpawnFood(Map map)
		{
			if (rand.Next(0, map.Settings.FoodSettings.ChanceSpawn) == 0)
			{
				var (i, j) = GetRandomFreeCoords(map);
				if (i != -1 && j != -1)
				{
					map.AddFood(i, j);
				}
			}
		}

		private (int i, int j) GetRandomFreeCoords(Map map)
		{
			var freeCoords = new List<(int i, int j)>();

			for (int i = 0; i < map.Width; i++)
				for (int j = 0; j < map.Height; j++)
					if (map.Cells[i, j].IsEmpty)
						freeCoords.Add((i, j));

			if (freeCoords.Any())
			{
				return freeCoords.Random();
			}
			else
			{
				return (-1, -1);
			}
		}
	}
}
