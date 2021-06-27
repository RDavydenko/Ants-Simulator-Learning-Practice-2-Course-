using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Ants.Core.Models;
using Ants.Core.Extenstions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ants.Tests
{
	[TestClass]
	public class AntsTest
	{
		[TestMethod]
		public void AntDoAnything()
		{
			Map map = new Map(4, 4);
			var antHill = map.AddAntHill(0, 0, AntTeam.Red);
			var ant = map.AddAnt(0, 0, antHill);
			map.AddFood(3, 3);

			while (ant.Stamina > 0)
			{
				ant.Do();
			}
		}

		[TestMethod]
		public void OneAntMoves()
		{
			Map map = new Map(10, 10);
			var antHill = map.AddAntHill(0, 0, AntTeam.Blue, 0);
			// Пришлось пойти на хитрость: создать синий AntHill и сделать команду муравья красной
			var ant = map.AddAnt(0, 0, antHill, 1000000); // Делаем очень выносливым
			ant.GetType().GetProperty(nameof(ant.Team)).GetSetMethod(true).Invoke(ant, new object[] { AntTeam.Red }); // Team = AntTeam.Red

			while (ant.Stamina > 0)
			{
				map.NextTick();

				var antsCount = 1;
				for (int i = 0; i < map.Cells.GetLength(0); i++)
					for (int j = 0; j < map.Cells.GetLength(1); j++)
						if (map.Cells[i, j].Entities.FirstOrDefault(x => x is Ant) is Ant ant2)
						{
							if (ant2 != ant)
							{
								antsCount++;
							}
						}

				Assert.AreEqual(1, antsCount);
			}
		}

		[TestMethod]
		public void ValidateCoords()
		{
			int w = 100, h = 100;

			Map map = new Map(w, h);
			var rand = new Random();
			var method = map.GetType().GetMethod("IsValidCoords", BindingFlags.NonPublic | BindingFlags.Instance);

			int count = 1_000_000;
			for (int i = 0; i < count; i++)
			{
				var valid = (bool)method.Invoke(map, new object[] { new Point(rand.Next(0, w), rand.Next(0, h)) });
				Assert.AreEqual(true, valid);
			}
		}

		[TestMethod]
		public void NextStepsCalculates()
		{
			int w = 1000, h = 1000;

			Map map = new Map(w, h);
			var rand = new Random();
			var method = map.GetType().GetMethod("Scan", BindingFlags.NonPublic | BindingFlags.Instance);

			int count = 1_000_000;
			for (int i = 0; i < count; i++)
			{
				var position = new Point(rand.Next(0, w), rand.Next(0, h));
				var res = (IEnumerable<ScanResult>)method.Invoke(map, new object[] { position, 1 });
				var valid = res.All(x => (int)Math.Abs(x.Coords.X - position.X) <= 1 && (int)Math.Abs(x.Coords.Y - position.Y) <= 1);
				Assert.AreEqual(true, valid);
			}
		}

		[TestMethod]
		public void FindIndexesSpeed()
		{
			Map map = new Map(1000, 1000);
			var antHill = map.AddAntHill(0, 0, AntTeam.Red);
			var ant1 = map.AddAnt(0, 0, antHill);
			var ant2 = map.AddAnt(0, 0, antHill);
			map.AddFood(3, 3);
			map.AddFood(4, 3);
			map.AddFood(3, 7);
			map.AddFood(99, 3);
			map.AddFood(43, 3);
			map.AddFood(3, 23);

			var method = map.GetType().GetMethod("GetEntityIndexes", BindingFlags.NonPublic | BindingFlags.Instance);

			var sw = Stopwatch.StartNew();
			int count = 100000;
			for (int i = 0; i < count; i++)
			{
				var indexes1 = method.Invoke(map, new object[] { ant1 });
				var indexes2 = method.Invoke(map, new object[] { ant2 });
			}
			sw.Stop();
			Console.WriteLine("Время поиска: " + sw.ElapsedMilliseconds + " ms");
		}

		[TestMethod]
		public void GetDiffVariants()
		{
			Map map = new Map(1000, 1000);
			var res1 = new Point[]
			{
				new Point(-1, -1),
				new Point(-1, 0),
				new Point(-1, 1),
				new Point(0, -1),
				new Point(0, 1),
				new Point(1, -1),
				new Point(1, 0),
				new Point(1, 1)
			};
			var res2 = new Point[]
			{
				new Point(-2, -2),
				new Point(-2, -1),
				new Point(-2, 0),
				new Point(-2, 1),
				new Point(-2, 2),

				new Point(-1, -2),
				new Point(-1, -1),
				new Point(-1, 0),
				new Point(-1, 1),
				new Point(-1, 2),

				new Point(0, -2),
				new Point(0, -1),
				new Point(0, 1),
				new Point(0, 2),

				new Point(1, -2),
				new Point(1, -1),
				new Point(1, 0),
				new Point(1, 1),
				new Point(1, 2),

				new Point(2, -2),
				new Point(2, -1),
				new Point(2, 0),
				new Point(2, 1),
				new Point(2, 2)
			};

			var method = map.GetType().GetMethod("GetVariants", BindingFlags.NonPublic | BindingFlags.Instance);

			var variants1 = (Point[]) method.Invoke(map, new object[] { 1 });
			var variants2 = (Point[]) method.Invoke(map, new object[] { 2 });

			var isEqual1 = res1.OrderBy(x => x).SequenceEqual(variants1.OrderBy(x => x));
			var isEqual2 = res2.OrderBy(x => x).SequenceEqual(variants2.OrderBy(x => x));
			Assert.IsTrue(isEqual1);
			Assert.IsTrue(isEqual2);
		}

		[TestMethod]
		public void FindMinSpeedTest()
		{
			var startPos = new Point(0, 0);
			var array = new Point[]
			{
				new Point(3, 5),
				new Point(8, 2),
				new Point(2, 2),
				new Point(123, 1),
				new Point(4, 5),
				new Point(1, 1), // Ближайший
				new Point(4, 5),
				new Point(5, 5),
				new Point(9, 5),
				new Point(4, 0),
				new Point(4, 5),
				new Point(3, 5),
				new Point(4, 5),
				new Point(7, 9),
				new Point(9, 9),
				new Point(0, 5),
				new Point(4, 5),
				new Point(5, 5),
				new Point(9, 5),
				new Point(4, 0),
				new Point(4, 5),
				new Point(3, 5),
				new Point(4, 5),
				new Point(7, 9),
				new Point(9, 9),
				new Point(0, 5),
				new Point(4, 5),
				new Point(5, 5),
				new Point(9, 5),
				new Point(4, 0),
				new Point(4, 5),
				new Point(3, 5),
				new Point(4, 5),
				new Point(7, 9),
				new Point(9, 9),
				new Point(0, 5),
				new Point(4, 5),
				new Point(5, 5),
				new Point(9, 5),
				new Point(4, 0),
				new Point(4, 5),
				new Point(3, 5),
				new Point(4, 5),
				new Point(7, 9),
				new Point(9, 9),
				new Point(0, 5),
				new Point(4, 5),
				new Point(5, 5),
				new Point(9, 5),
				new Point(4, 0),
				new Point(4, 5),
				new Point(3, 5),
				new Point(4, 5),
				new Point(7, 9),
				new Point(9, 9),
				new Point(0, 5),
				new Point(4, 5),
				new Point(5, 5),
				new Point(9, 5),
				new Point(4, 0),
				new Point(4, 5),
				new Point(3, 5),
				new Point(4, 5),
				new Point(7, 9),
				new Point(9, 9),
				new Point(0, 5),
				new Point(4, 5),
				new Point(5, 5),
				new Point(9, 5),
				new Point(4, 0),
				new Point(4, 5),
				new Point(3, 5),
				new Point(4, 5),
				new Point(7, 9),
				new Point(9, 9),
				new Point(0, 5),
				new Point(4, 5),
				new Point(5, 5),
				new Point(9, 5),
				new Point(4, 0),
				new Point(4, 5),
				new Point(3, 5),
				new Point(4, 5),
				new Point(7, 9),
				new Point(9, 9),
				new Point(0, 5),
			};

			var sw = Stopwatch.StartNew();
			var count = 100000;
			for (int i = 0; i < count; i++)
			{
				//var min = array.OrderBy(x => x.GetDistance(startPos)).First();
				var min = array.MinBy(x => x.GetDistance(startPos));
				if (min.X != 1 || min.Y != 1)
				{
					Assert.Fail();
				}
			}
			sw.Stop();
			Console.WriteLine("Elapsed milliseconds: " + sw.ElapsedMilliseconds);
		}
	}
}
