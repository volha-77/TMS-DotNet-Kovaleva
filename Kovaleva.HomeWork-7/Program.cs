using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TMS.FitnessTracker
{
	class Program

	{
		

		static void Main(string[] args)
		{
			
			Console.WriteLine("Starting Fitness Tracker...");
			IEnumerable<Training> trainings = TrainingGenerator.GetTrainings().ToList();

			ShowTrainings(trainings);
			//var pulses1 = TrainingGenerator.GetPulses(true);
			//var pulses2 = TrainingGenerator.GetPulses(false);

			Console.WriteLine("\nStarted Fitness Tracker.");
			var averageDistance = GetAverageDistance(trainings);
			var allTimeDistance = GetAllTimeDistance(trainings);
			var maxDistance = GetMaxDistance(trainings);

			Console.WriteLine();
			Console.WriteLine($"Average distance: {averageDistance}");
			Console.WriteLine($"All time distance: {allTimeDistance}");
			Console.WriteLine($"Max distance: {maxDistance}");
		}

		private static double GetMaxDistance(IEnumerable<Training> trainings)
		{
			return trainings.Max(x => x.Distance);
		}

		private static double GetAllTimeDistance(IEnumerable<Training> trainings)
		{
			return trainings.Sum(x => x.Distance);
		}

		private static double GetAverageDistance(IEnumerable<Training> trainings)
		{
			return trainings.Average(x=>x.Distance);
		}

		private static void ShowTrainings(IEnumerable<Training> trainings)
		{
			int i = 1;
            foreach (var training in trainings)
            {
				Console.WriteLine($"Training[{i}]: AveragePulse {training.AveragePulse}, Distance {training.Distance}, Steps " +
					$"{training.Steps}, Duration {training.Duration}, StartDate {training.StartDate}");
				i++;
            }
		}


	}

	internal class TrainingGenerator
	{
		private static Random rnd = new Random();
		public static IEnumerable<Training> GetTrainings()
		{
			return Enumerable.Range(0, 10).Select(CreateTraining);
		}

		private static Training CreateTraining(int num)
		{
			Training training = new Training();

			training.AveragePulse = (int)GetPulses(true).Average();
			training.Distance = rnd.Next(0, 10000);
			training.Steps = rnd.Next(0, 10000);
			training.Duration = TimeSpan.FromMinutes(rnd.Next(5, 480));
			training.StartDate = RandomStartDate();
			return training;
		}

		public static IEnumerable<int> GetPulses(bool hasThird) // true -> [0, 1, 2, 3]
																// 1. Current = 0 -> MoveNext()
																// 2. Current = 1 -> MoveNext()
																// 3. hasThird 
																//		? Current = 2 -> MoveNext()
																//		: Current = 3 -> MoveNext();
		{
			//yield return 0;

			//yield return 1;

			//if (hasThird)
			//	yield return 2;
			//// else
			//// 	yield break;

			//yield return 3;

			for (int i = 0; i < 100; i++)
			{
				yield return rnd.Next(70, 200);
			}
		}

		private static DateTime RandomStartDate()
		{
			DateTime start = new DateTime(2020, 1, 1);
			int range = (DateTime.Today - start).Days;
			return start.AddDays(rnd.Next(range)).AddHours(rnd.Next(24)).AddMinutes(rnd.Next(60)).AddSeconds(rnd.Next(60));
		}
	}

	internal class Training
	{
		public TimeSpan Duration { get; set; }
		public DateTime StartDate { get; set; }
		public double Distance { get; set; }
		public int Steps { get; set; }
		public int AveragePulse { get; set; }
	}

	
}