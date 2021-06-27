using System.Collections.Generic;

namespace Ants.Core.Models
{
	/// <summary>
	/// Карта поведения команд
	/// </summary>
	public class BehaviourMap
	{
		private readonly Dictionary<(AntTeam, AntTeam), BehaviourType> behaviourDictionary;

		public BehaviourMap()
		{
			behaviourDictionary = new Dictionary<(AntTeam, AntTeam), BehaviourType>();
		}

		public BehaviourType? AbsoluteBehaviour { get; set; }

		/// <summary>
		/// Добавить врагов
		/// </summary>
		/// <param name="team1">Команда 1</param>
		/// <param name="team2">Команда 2</param>
		public void AddEnemy(AntTeam team1, AntTeam team2)
		{
			SetBehaviour(team1, team2, BehaviourType.Enemy);
		}

		/// <summary>
		/// Добавить нейтралов
		/// </summary>
		/// <param name="team1">Команда 1</param>
		/// <param name="team2">Команда 2</param>
		public void AddNeutral(AntTeam team1, AntTeam team2)
		{
			SetBehaviour(team1, team2, BehaviourType.Neutral);
		}

		/// <summary>
		/// Добавить союзников
		/// </summary>
		/// <param name="team1">Команда 1</param>
		/// <param name="team2">Команда 2</param>
		public void AddFriend(AntTeam team1, AntTeam team2)
		{
			SetBehaviour(team1, team2, BehaviourType.Friend);
		}

		/// <summary>
		/// Получить поведение между командами
		/// </summary>
		/// <param name="team1">Команда 1</param>
		/// <param name="team2">Команда 2</param>
		public BehaviourType GetBehaviour(AntTeam team1, AntTeam team2)
		{
			if (team1 == team2)
			{
				return BehaviourType.Friend;
			}

			if (AbsoluteBehaviour.HasValue)
			{
				return AbsoluteBehaviour.Value;
			}

			if (behaviourDictionary.TryGetValue((team1, team2), out var behaviour))
			{
				return behaviour;
			}

			return BehaviourType.Neutral;
		}
		private void SetBehaviour(AntTeam team1, AntTeam team2, BehaviourType behaviourType)
		{
			behaviourDictionary[(team1, team2)] = behaviourType;
			behaviourDictionary[(team2, team1)] = behaviourType;
		}
	}
}
