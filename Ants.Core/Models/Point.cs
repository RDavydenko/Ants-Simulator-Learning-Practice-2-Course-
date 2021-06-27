using System;
using System.Collections.Generic;
using System.Text;

namespace Ants.Core.Models
{
	public struct Point
	{
		public Point(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; set; }
		public int Y { get; set; }

		public double GetDistance(Point other)
		{
			var dx = X - other.X;
			var dy = Y - other.Y;
			return Math.Sqrt(dx * dx + dy * dy);
		}

		public static bool operator ==(Point p1, Point p2)
		{
			return p1.Equals(p2) == true;
		}

		public static bool operator !=(Point p1, Point p2)
		{
			return p1.Equals(p2) == false;
		}

		public override bool Equals(object obj)
		{
			return obj is Point point
					&& X == point.X
					&& Y == point.Y;
		}

		public override int GetHashCode()
		{
			int hashCode = 1861411795;
			hashCode = hashCode * -1521134295 + X.GetHashCode();
			hashCode = hashCode * -1521134295 + Y.GetHashCode();
			return hashCode;
		}

		public override string ToString() => $"({X}, {Y})";

	}
}
