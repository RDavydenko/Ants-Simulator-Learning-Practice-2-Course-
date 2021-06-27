using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ants.Core.Models;

namespace Ants.Visual.Extensions
{
	internal static class ColorExtensions
	{
		public static Brush GetBrush(this Ant ant)
		{
			return ant.Team switch
			{
				AntTeam.Red => Brushes.DarkRed,
				AntTeam.Black => Brushes.Black,
				AntTeam.Blue => Brushes.DarkBlue,
				AntTeam.Yellow => Brushes.Orange,
				_ => throw new ArgumentOutOfRangeException(nameof(ant.Team)),
			};
		}

		public static Brush GetBrush(this AntHill antHill)
		{
			return antHill.Team switch
			{
				AntTeam.Red => Brushes.RosyBrown,
				AntTeam.Black => Brushes.Gray,
				AntTeam.Blue => Brushes.BlueViolet,
				AntTeam.Yellow => Brushes.Yellow,
				_ => throw new ArgumentOutOfRangeException(nameof(antHill.Team)),
			};
		}
	}
}
