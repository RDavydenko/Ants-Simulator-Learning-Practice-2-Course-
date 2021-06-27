using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ants.Core.Models
{
	public abstract class Entity
	{
		protected readonly Map map;

		public Entity(int x, int y, Map map)
		{
			this.map = map;
			Position = new Point(x, y);
		}

		public Point Position { get; protected set; }
		internal bool StepFlag { get; set; }
		public virtual string Name => this.ToString();

		public abstract void Do();

		public virtual EntityInfo About()
		{
			var props = this.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
			var dict = props.ToDictionary(x => x.Name, x => x.GetValue(this)?.ToString());
			return new EntityInfo
			{
				Name = this.Name,
				Properties = dict
			};
		}

		internal void ResetStepFlag() => StepFlag = false;
	}
}
