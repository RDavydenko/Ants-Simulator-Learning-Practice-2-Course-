using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ants.Core.Extenstions;

namespace Ants.Core.Models
{
	public class Food : Entity
	{
		private readonly static Random rand = new Random();

		public Food(int x, int y, Map map, int count)
			: base(x, y, map)
		{
			Count = count;
		}

		public virtual int Count { get; protected set; }	// Количество еды
		
		public override void Do()
		{ 
			StepFlag = true;

			// Разрастание
			if (rand.Next(0, map.Settings.FoodSettings.ChanceGrowth) == 0)
			{
				var positions = map.Scan(Position).Where(x => x.Entity is not Food);
				if (positions.Any())
				{
					var coords = positions.Random().Coords;
					map.AddFood(coords.X, coords.Y);
				}
			}
		}

		public int GetFood(int count)
		{
			var realCount = 0;
			if (Count > 0)
			{
				realCount = count > Count ? Count : count;
				Count -= realCount;
			}

			// Если Count <= 0 - удаляем с поля
			if (Count <= 0)
			{
				map.RemoveEntity(this);
			}

			return realCount;
		}

		public override string ToString() => "Food";
	}
}
