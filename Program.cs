using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace algorithms_practice
{
	class Program
	{
		private static long KostyaMobile() //done
		{
			Dictionary<string, long> MobilePlan = new();
			var splittedResponse = Console.ReadLine().Split(' ');

			MobilePlan["Cost"] = Convert.ToInt64(splittedResponse[0]);
			MobilePlan["Mb"] = Convert.ToInt64(splittedResponse[1]);
			MobilePlan["NextMbCost"] = Convert.ToInt64(splittedResponse[2]);
			MobilePlan["AmountMbLost"] = Convert.ToInt64(splittedResponse[3]);

			if (MobilePlan["AmountMbLost"] > MobilePlan["Mb"])
			{
				var lost = MobilePlan["AmountMbLost"] - MobilePlan["Mb"];
				return MobilePlan["Cost"] + (lost * MobilePlan["NextMbCost"]);
			}
			else
			{
				return MobilePlan["Cost"];
			}
		}

		private static long VanyaSlice() //done
		{
			var slices = Convert.ToInt64(Console.ReadLine());

			long slice = 1, i = 0;
			while (slice < slices)
			{
				slice *= 2;
				i++;
			}
			
			return i > 0 ? i : slice;
		}

		private static int KatyaPapers() // partly done
		{
			List<int> floorsAndTime = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
			List<int> people = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
			int quickColleague = Convert.ToInt32(Console.ReadLine());
			int bestTime = 0;
			for (int i = 0; i < floorsAndTime[0]; i++)
			{
				int currentTime = 0;
				int floor = i, startFloor = i;
				int countPassedFloors = 0;
				bool quickColleagueFailed = false, gotEnd = false;
				while (countPassedFloors < floorsAndTime[0] - 1 && !quickColleagueFailed)
				{
					if (startFloor != 0)
					{
						if (floor == quickColleague - 1 && currentTime > floorsAndTime[1]) quickColleagueFailed = true;
						else
						{
							if (floor > 0 && gotEnd == false)
							{
								currentTime += people[floor] - people[floor - 1];
								--floor;
								countPassedFloors++;
							}
							else if (floor == 0 && gotEnd == false)
							{
								gotEnd = true;
								floor = startFloor + 1;
								if (floor < people.Count() - 1)
								{
									currentTime += people[floor] - people[0];
									countPassedFloors++;
								}
								else
								{
									currentTime += people[floor] - people[0];
									countPassedFloors++;
									break;
								}
							}
							else if (gotEnd == true)
							{
								if (floor <= people.Count() - 2)
								{
									currentTime += people[floor + 1] - people[floor];
									floor++;
									countPassedFloors++;
								}
								else countPassedFloors++;
							}
						}
					}
					else
					{
						if (floor == quickColleague - 1 && currentTime > floorsAndTime[1]) quickColleagueFailed = true;
						else 
						{
							if (floor <= floorsAndTime[0] - 2)
							{
								currentTime += people[floor + 1] - people[floor];
								floor++;
							}
							else break;	
						}
					}
				}
				if (i == 0 && !quickColleagueFailed) bestTime = currentTime;
				else if (bestTime > currentTime && !quickColleagueFailed) bestTime = currentTime;
				else if (bestTime == 0 && !quickColleagueFailed) bestTime = currentTime;
			}

			return bestTime;
		}

		private static long KostyaRewriteNumbers() 
		{
			List<int> countAndOperations = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
			List<int> numbers = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToList();
			
			// TODO: руками через for заполняем массив складывая все в dictionary of lists для каждого разряда
			// затем сортируем и поубыванию проверяем есть ли разряд и так же по убывани в каждом разряде меняем знаки до момента когда у нас не кончатся операции или или данные
			
			long initialSum = numbers.Sum(x => x);
			numbers.Sort();
			
			for (int i = countAndOperations[0] - 1; i >= 0 && countAndOperations[1] > 0; i--)
			{
				StringBuilder sb = new StringBuilder(numbers[i].ToString());
				for (int j = 0; j < sb.Length; j++)
				{
					if (sb[j] != '9') sb[j] = '9';
				}

				numbers[i] = Convert.ToInt32(sb.ToString());
			}
			
			long resultSum = numbers.Sum(x => x);
		}
		
		static void Main(string[] args)
		{
			// Console.WriteLine(KostyaMobile());
			// Console.WriteLine(VanyaSlice());
			Console.WriteLine(KatyaPapers());
		}
	}
}