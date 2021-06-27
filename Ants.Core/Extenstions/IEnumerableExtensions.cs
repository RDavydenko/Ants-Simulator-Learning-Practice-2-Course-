using System;
using System.Collections.Generic;
using System.Linq;

namespace Ants.Core.Extenstions
{
	public static class IEnumerableExtensions
	{
		private readonly static Random rand = new Random();

		public static T Random<T>(this IEnumerable<T> items)
		{
			return items.ElementAt(rand.Next(0, items.Count()));
		}

		public static T MinBy<T,E>(this IEnumerable<T> items, Func<T,E> selector)
		{
			T minElem = items.ElementAt(0);
			E min = selector(minElem);
			var enumerator = items.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (Comparer<E>.Default.Compare(selector(enumerator.Current), min) < 0)
				{
					minElem = enumerator.Current;
					min = selector(minElem);
				}
			}
			return minElem;
		}
		public static T MaxBy<T, E>(this IEnumerable<T> items, Func<T, E> selector)
		{
			T minElem = items.ElementAt(0);
			E min = selector(minElem);
			var enumerator = items.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (Comparer<E>.Default.Compare(selector(enumerator.Current), min) > 0)
				{
					minElem = enumerator.Current;
					min = selector(minElem);
				}
			}
			return minElem;
		}
	}
}
