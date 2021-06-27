using System;
using System.Collections.Generic;
using System.Text;

namespace Ants.Core.Models
{
	public enum BehaviourType
	{
		/// <summary>
		/// Неизвестно
		/// </summary>
		None = 0,

		/// <summary>
		/// Нейтральный
		/// </summary>
		Neutral = 1,

		/// <summary>
		/// Друг (союзник)
		/// </summary>
		Friend = 2,

		/// <summary>
		/// Враждебный
		/// </summary>
		Enemy = 3
	}

	public enum AntMode
	{
		/// <summary>
		/// Искать еду
		/// </summary>
		FindFood = 0,

		/// <summary>
		/// Нести еду в муравейник
		/// </summary>
		CarryFood = 1,

		/// <summary>
		/// Идем обратно к еде
		/// </summary>
		GoToFood = 2
	}

	public enum AntTeam
	{
		Red = 0,
		Black = 1,
		Blue = 2,
		Yellow = 3
	}
}
