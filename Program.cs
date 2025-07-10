using System;
using System.Collections.Generic;
using System.Linq;

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

		private static long KostyaRewriteNumbers() // partly done 
		{
			List<int> countAndOperations = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
			List<int> numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
			
			long sum = 0;
            List<long> allAdds = new();
			for (int i = 0; i < countAndOperations[0]; i++)
	        {
                int current = numbers[i], dim = 1;
                while (current > 0)
                {
                    int n = current % 10;
                    long diff = 9 - n;
                    if (diff > 0)
                        allAdds.Add(diff * dim);
                    current /= 10;
                    dim *= 10;
                }
			}

            if (!allAdds.Any())
                return 0;

            allAdds.Sort((a, b) => b.CompareTo(a));

            for (int i = 0; i < Math.Min(countAndOperations[1], allAdds.Count); i++)
            {
                sum += allAdds[i];
            }

            return sum;
		}
		
		static void Main(string[] args)
		{
			// Console.WriteLine(KostyaMobile());
			// Console.WriteLine(VanyaSlice());
			// Console.WriteLine(KatyaPapers());
            Console.WriteLine(KostyaRewriteNumbers());
		}
	}
}
