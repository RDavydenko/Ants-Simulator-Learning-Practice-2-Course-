using System.Collections.Generic;
using System.Linq;

namespace Ants.Core.Models
{
	/// <summary>
	/// Клетка игрового поля
	/// </summary>
	public class GameCell
	{ 
		public List<Entity> Entities { get; set; }
		public bool IsEmpty => Entities.Count == 0;

		public GameCell()
		{
			Entities = new List<Entity>();
		}

		public void Do()
		{
			for (int i = 0; i < Entities.Count; i++)
				if (Entities[i].StepFlag == false)
					Entities[i].Do();
		}

		public override string ToString()
			=> string.Join(", ", Entities?.Select(x => x.ToString()));
	}
}
