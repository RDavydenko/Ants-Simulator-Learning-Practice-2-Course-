namespace Ants.Core.Models
{
	/// <summary>
	/// Настройки муравейника
	/// </summary>
	public class AntHillSettings
	{
		/// <summary>
		/// Количество еды, требуемое для спавна нового муравья
		/// </summary>
		public int FoodPerSpawnAnt { get; set; } = 50;

		/// <summary>
		/// Количество еды, требуемое для спавна нового муравейника
		/// </summary>
		public int FoodPerSpawnAntHill { get; set; } = 150;

		/// <summary>
		/// Базовый (неприкасаемый) запас еды в муравейнике для спавна муравьев
		/// </summary>
		public int BaseCount { get; set; } = 100;

		/// <summary>
		/// Шанс спавна нового муравья (1/число)
		/// </summary>
		public int ChanceSpawnAnt { get; set; } = 100;

		/// <summary>
		/// Шанс спавна нового муравейника (1/число)
		/// </summary>
		public int ChanceSpawnAntHill { get; set; } = 20;
	}
}
