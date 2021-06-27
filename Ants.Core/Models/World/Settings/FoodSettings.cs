namespace Ants.Core.Models
{
	/// <summary>
	/// Настройки еды
	/// </summary>
	public class FoodSettings
	{
		/// <summary>
		/// Стартовое количество еды в одном экземляре Food
		/// </summary>
		public int Count { get; set; } = 200;

		/// <summary>
		/// Шанс разрастания (1/число)
		/// </summary>
		public int ChanceGrowth { get; set; } = 100000;

		/// <summary>
		/// Шанс спавна новой еды на игровом поле (1/число)
		/// </summary>
		public int ChanceSpawn { get; set; } = 5;
	}
}
