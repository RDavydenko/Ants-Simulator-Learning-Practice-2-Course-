using System;
using System.Collections.Generic;
using System.Linq;
using Ants.Core.Extenstions;

namespace Ants.Core.Models
{
	/// <summary>
	/// Муравей
	/// </summary>
	public class Ant : Entity
	{
		private readonly AntHill antHill;

		public Ant(int x, int y, int stamine, Map map, AntHill antHill)
			: base(x, y, map)
		{
			this.antHill = antHill;

			Mode = AntMode.FindFood;
			Team = antHill.Team;
			LastFoodCoords = null;
			Food = 0;
			MaxFood = map.Settings.AntSettings.MaxFood;
			Stamina = stamine;
			MaxStamina = map.Settings.AntSettings.MaxStamina;
			Age = 0;
			Vision = 1;
		}

		public AntMode Mode { get; private set; }       // Режим работы муравья. Его цель
		public AntTeam Team { get; private set; }       // Команда (муравейник)
		public Point? LastFoodCoords { get; private set; }		// Координаты последней найденной еды
		public int Food { get; private set; }           // Еда, которую несет с собой
		public int MaxFood { get; private set; }        // Максимальное количество еды, которое может унести
		public int Stamina { get; private set; }        // Выносливость
		public int MaxStamina { get; private set; }     // Максимальная выносливость
		public int Age { get; private set; }            // Возраст (кол-во пережитых ходов/тиков)
		public int Vision { get; private set; }         // Область видимости (обзор) - на сколько клеток может смотреть вперед
		public int Frags { get; private set; }			// Количество убитых врагов

		public override void Do()
		{
			StepFlag = true;

			if (Stamina > 0)
			{
				SpendStamina();
			}
			else
			{
				// Смерть - превращение в еду
				map.TransformToFood(this);
				return;
			}

			// Апгрейд скиллов
			Upgrade();

			// Если несем еду в муравейник
			if (Mode == AntMode.CarryFood)
			{
				MoveToAntHill();
			}
			// Если идем обратно к еде
			else if (Mode == AntMode.GoToFood)
			{
				MoveToFood();
			}
			// Если ищем еду
			else if (Mode == AntMode.FindFood)
			{
				var scanResults = map.Scan(Position, Vision);
				var enemyAnt = scanResults
					.FirstOrDefault(x => x.Entity is Ant ant
						&& ant is not null
						&& IsNear(ant.Position)
						&& map.GetBehaviour(ant.Team, Team) == BehaviourType.Enemy)
					?.Entity as Ant;

				// Если рядом враг
				if (enemyAnt is not null)
				{
					Fight(enemyAnt);
					return;
				}


				var foodResult = GetNearlyFoodResult(scanResults); // Ближайшая еда (может быть NULL, если еды нет) (не свой муравейник)

				// Если соседняя клетка
				if (foodResult is not null && IsNear(foodResult.Coords))
				{
					// Подбираем еду
					TakeFood(scanResults, foodResult);
				}
				else // Если ищем еду
				{
					if (foodResult is null) // Если поблизости не видит еды (в т.ч. в радиусе обзора)
					{
						var friendAntWhoMayKnowWhereIsFood = scanResults
							.FirstOrDefault(x => x.Entity is Ant ant 
									&& ant is not null
									&& map.GetBehaviour(ant.Team, Team) == BehaviourType.Friend
									&& ant.LastFoodCoords.HasValue
									&& ant.LastFoodCoords.Value.GetDistance(Position) > 8)
							?.Entity as Ant;

						if (friendAntWhoMayKnowWhereIsFood is not null) // Если нашли такого дружественного муравья
						{
							LastFoodCoords = friendAntWhoMayKnowWhereIsFood.LastFoodCoords;
							Mode = AntMode.GoToFood;
						}
						else // Если не нашли другана, придется искать самим
						{
							FindFood(scanResults, foodResult);
						}
					}
					else // Если поблизости есть еда или в радиусе обзора
					{
						FindFood(scanResults, foodResult);
					}
				}
			}
		}

		private void Fight(Ant enemyAnt)
		{
			// Формула, по которой считается сила муравья
			Func<Ant, double> formula = (Ant ant) =>
			{
				var ageImpact = ant.Age < 200 ? ant.Age : 200; // Не больше 200 за возраст
				var fragsImpact = ant.Frags * 20 < 400 ? ant.Frags * 20 : 400; // За каждый фраг - 20. Но не более 400
				return ant.Stamina + ageImpact + fragsImpact; 
			};

			if (formula(this) > formula(enemyAnt)) // Победа
			{
				Frags++;
				map.TransformToFood(enemyAnt);
			}
			else // Поражение
			{
				enemyAnt.Frags++;
				map.TransformToFood(this);
			}
		}

		private bool IsEatableFood(Entity entity)
		{
			// Еда или чужой муравейник
			return entity is Food food
					&& (food is not AntHill antHill ||
						map.GetBehaviour(antHill.Team, Team) == BehaviourType.Enemy);
		}

		private bool IsNear(Point coords)
		{
			return coords.GetDistance(Position) < 2;
		}

		private ScanResult GetNearlyFoodResult(List<ScanResult> scanResult)
		{
			return scanResult
				.Where(x => IsEatableFood(x.Entity))
				.OrderBy(x => x.Coords.GetDistance(Position))
				.FirstOrDefault();
		}

		private void MoveToAntHill()
		{
			// Если поблизости есть муравейник своей команды
			var territoryScanResults = map.Scan(Position);
			var anthill = territoryScanResults
				.FirstOrDefault(x => x.Entity is AntHill antHill && map.GetBehaviour(antHill.Team, Team) == BehaviourType.Friend)
				?.Entity as AntHill;
			if (anthill is not null)
			{
				// Отдаем в муравейник
				anthill.AddFood(Food);
				Food = 0;

				Stamina = MaxStamina; // Восстановились в муравейнике

				
				// Если знаем, где еда, то идем за ней
				if (LastFoodCoords.HasValue)
				{
					Mode = AntMode.GoToFood;
				}
				// Если еда кончилась в том месте, то все по новой
				else
				{
					Mode = AntMode.FindFood;
				}

				return;
			}

			
			// Идем до муравейника по кратчайшему пути
			var nextCoords = territoryScanResults
				.Where(x => IsNear(x.Coords))
				.OrderBy(x => x.Coords.GetDistance(antHill.Position))
				.First()
				.Coords;
			Move(nextCoords);
		}

		/// <summary>
		/// Идти к еде от муравейника
		/// </summary>
		/// <returns></returns>
		private void MoveToFood()
		{
			var scanResults = map.Scan(Position);
			var foodResults = scanResults
				.Where(x => IsEatableFood(x.Entity))
				.FirstOrDefault();

			// Если уже поблизости есть еда, то нет смысла идти до прошлой, т.к. может быть дальше
			if (foodResults is not null)
			{
				Mode = AntMode.FindFood;
				LastFoodCoords = foodResults.Coords;
				return;
			}

			if (LastFoodCoords.HasValue) // Знает, где еда
			{
				// Только среди тех, которые являются соседними клетками (Distance < 2)
				// Следующий ход к еде
				var nextCoords = scanResults
					.OrderBy(x => x.Coords.GetDistance(LastFoodCoords.Value))
					.First()
					.Coords;

				Move(nextCoords); // Перемещаемся

				// Если на соседней клетке, то переход в режим FindFood, т.к. там реализована логика подбора еды
				if (IsNear(LastFoodCoords.Value))
				{
					Mode = AntMode.FindFood;
				}
				else
				{
					Mode = AntMode.GoToFood;
				}
				return;
			}
			else
			{
				Mode = AntMode.FindFood;
				return;
			}
		}

		private void TakeFood(List<ScanResult> scanResults, ScanResult foodResult)
		{
			var food = foodResult.Entity as Food;
			var takedFood = food.GetFood(MaxFood - Food);
			Food += takedFood;
			Mode = AntMode.CarryFood; // Несем в муравейник

			// Если еда в этом месте не кончилась или поблизости есть еда
			var isAnotherFoodNearly = scanResults
				.Where(x => x.Coords != foodResult.Coords)
				.Any(x => IsEatableFood(x.Entity));
			if (food.Count > 0 || isAnotherFoodNearly)
			{
				LastFoodCoords = foodResult.Coords;
			}
			else
			{
				LastFoodCoords = null;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="scanResults">Весь скан территории</param>
		/// <param name="nearFoodResult">Ближайшая еда, до которой надо идти</param>
		private void FindFood(IEnumerable<ScanResult> scanResults, ScanResult nearFoodResult)
		{
			// nearFoodResult может быть null, тогда рандомно
			if (nearFoodResult is null)
			{
				// Только среди тех, которые являются соседними клетками (Distance < 2)
				var nextResults = scanResults
					.Where(x => IsNear(x.Coords));

				// Знает, где была еда
				if (LastFoodCoords.HasValue)
				{
					nextResults = nextResults
						.OrderBy(x => x.Coords.GetDistance(LastFoodCoords.Value));
				}

				var nextCoords = nextResults.Random().Coords;
				Move(nextCoords); // Перемещаемся
			}
			else // Идем к ближайшей еде по кратчайшему пути
			{
				var nearlyToFoodCoords = scanResults
					.Where(x => IsNear(x.Coords))
					.OrderBy(x => x.Coords.GetDistance(nearFoodResult.Coords))
					.First()
					.Coords;
				Move(nearlyToFoodCoords); // Перемещаемся
			}
		}

		private void SpendStamina()
		{
			var staminaPerStep = map.Settings.AntSettings.StaminaPerStep; // Выносливость за ход

			if (Stamina - staminaPerStep <= 0)
			{
				// Попытка покушать и восстановиться
				if (Food > 0)
				{
					var spendedFood = Food % MaxStamina;
					Food -= spendedFood;
					Stamina += spendedFood;
				}
			}

			Stamina -= staminaPerStep;
		}

		private void Move(Point position)
		{
			Position = position;
			map.UpdateEntityPosition(this);
		}

		private void Upgrade()
		{
			var maxVision = map.Settings.AntSettings.MaxUpgradedVision;
			if (Age < int.MaxValue)
			{
				Age++;
			}

			// Каждые n ходов можно прокачать область видимости, если она меньше максимальной
			if (Age % map.Settings.AntSettings.AgePerVisionUpgrade == 0 && Vision < maxVision)
			{
				Vision += 1;
			}

			if (MaxFood < map.Settings.AntSettings.MaxUpgradedFood) // Ограничение на прокачку
			{
				MaxFood += 1; 
			}
			if (MaxStamina < map.Settings.AntSettings.MaxUpgradedStamina) // Ограничение на прокачку
			{ 
				MaxStamina += 1;
			}
		}

		public override string ToString() => "Ant";
	}
}
