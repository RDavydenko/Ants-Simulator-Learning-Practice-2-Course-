namespace Ants.Core.Models
{
	/// <summary>
	/// Настройки муравья
	/// </summary>
	public class AntSettings
	{
		/// <summary>
		/// Максимальное стартовое количество выносливости
		/// </summary>
		public int MaxStamina { get; set; } = 100;

		/// <summary>
		/// Максимальное стартовое количество еды
		/// </summary>
		public int MaxFood { get; set; } = 100;

		/// <summary>
		/// Максимальное дальность видимости (при прокачке)
		/// </summary>
		public int MaxUpgradedVision { get; set; } = 3;

		/// <summary>
		/// Сколько требуется возраста перед прокачкой дальности видимости
		/// </summary>
		public int AgePerVisionUpgrade { get; set; } = 200;

		/// <summary>
		/// Максимальное количество еды (при прокачке)
		/// </summary>
		public int MaxUpgradedFood { get; set; } = 1000;

		/// <summary>
		/// Максимальное количество выносливости (при прокачке)
		/// </summary>
		public int MaxUpgradedStamina { get; set; } = 1000;

		/// <summary>
		/// Количество выносливости, которое муравей тратит за ход
		/// </summary>
		public int StaminaPerStep { get; set; } = 2;
	}
}
