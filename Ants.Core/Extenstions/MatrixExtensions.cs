using System;
using System.Collections.Generic;
using System.Text;

namespace Ants.Core.Extenstions
{
	internal static class MatrixExtensions
	{
		public static (int I, int J) SearchIndex<T>(this T[,] matrix, T elem)
		{
			for (int i = 0; i < matrix.GetLength(0); i++)
				for (int j = 0; j < matrix.GetLength(1); j++)
					if (EqualityComparer<T>.Default.Equals(matrix[i, j], elem))
						return (i, j);

			return (-1, -1);
		}
	}
}
