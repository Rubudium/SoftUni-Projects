using System;
using System.Collections.Generic;
using System.Linq;


namespace _05._Fashion_Boutique
{
	class Program
	{
		static void Main(string[] args)
		{
			var inputIntegers = Console.ReadLine()
				.Split()
				.Select(int.Parse);

			var stack = new Stack<int>(inputIntegers);

			int capacity = int.Parse(Console.ReadLine());

			int startCapacity = capacity;
			int totalRacks = 0;

			if (stack.Min() > 0)
			{
				totalRacks = 1;
			}

			while (stack.Count > 0)
			{
				if (capacity > stack.Peek())
				{
					capacity -= stack.Pop();
				}
				else if (capacity == stack.Peek())
				{
					if (stack.Count > 1)
					{
						stack.Pop();
						totalRacks++;
						capacity = startCapacity;
					}
				}
				else if (capacity < stack.Peek())
				{
					totalRacks++;
					capacity = startCapacity;
					continue;
				}
			}

			Console.WriteLine(totalRacks);
		}
	}
}
