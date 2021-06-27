namespace Ants.Core.Models
{
	/// <summary>
	/// Настройки игрового мира
	/// </summary>
	public class Settings
	{
		public Settings(
			AntSettings antSettings = null,
			AntHillSettings antHillSettings = null,
			FoodSettings foodSettings = null,
			BehaviourMap behaviourMap = null)
		{

			AntSettings = antSettings ?? new AntSettings();
			AntHillSettings = antHillSettings ?? new AntHillSettings();
			FoodSettings = foodSettings ?? new FoodSettings();
			BehaviourMap = behaviourMap ?? new BehaviourMap();
		}

		/// <summary>
		/// Настройки муравья
		/// </summary>
		public AntSettings AntSettings { get; }

		/// <summary>
		/// Настройки муравейника
		/// </summary>
		public AntHillSettings AntHillSettings { get; }

		/// <summary>
		/// Настройки пищи
		/// </summary>
		public FoodSettings FoodSettings { get; }

		/// <summary>
		/// Карта поведения между командами
		/// </summary>
		public BehaviourMap BehaviourMap { get; }
	}
}
