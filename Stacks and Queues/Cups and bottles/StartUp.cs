using System;
using System.Collections.Generic;
using System.Linq;


namespace _12._Cups_and_Bottles
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputCups = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			var cups = new LinkedList<int>(inputCups);

			var inputBottles = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			var bottles = new LinkedList<int>(inputBottles);

			int wastedWater = 0;

			while (cups.Count > 0 && bottles.Count > 0)
			{
				int currentCupCapacity = cups.First();
				int currentBottleCapacity = bottles.Last();

				if (cups.First() <= bottles.Last())
				{
					wastedWater += bottles.Last() - cups.First();
					cups.RemoveFirst();
					bottles.RemoveLast();
				}

				else if (cups.First() > bottles.Last())
				{
					while (true)
					{
						if (cups.First() > bottles.Last())
						{
							currentBottleCapacity = bottles.Last();
							currentCupCapacity -= currentBottleCapacity;
							bottles.RemoveLast();
							cups.RemoveFirst();
							cups.AddFirst(currentCupCapacity);
						}

						else if (cups.First() <= bottles.Last())
						{
							wastedWater += bottles.Last() - cups.First();
							cups.RemoveFirst();
							bottles.RemoveLast();
							break;
						}
					}
				}
			}

			if (bottles.Count > 0)
			{
				Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
				Console.WriteLine($"Wasted litters of water: {wastedWater}");
			}
			else if (cups.Count > 0)
			{
				Console.WriteLine($"Cups: {string.Join(" ", cups)}");
				Console.WriteLine($"Wasted litters of water: {wastedWater}");
			}
		}
	}
}
