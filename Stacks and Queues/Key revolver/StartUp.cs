using System;
using System.Collections.Generic;
using System.Linq;


namespace _11.Key_Revolver
{
	class Program
	{
		static void Main(string[] args)
		{
			int priceBullet = int.Parse(Console.ReadLine());
			int sizeGunBarrel = int.Parse(Console.ReadLine());

			var bullets = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			var locks = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int intelligence = int.Parse(Console.ReadLine());

			var stackBullets = new Stack<int>(bullets);
			var queueLocks = new Queue<int>(locks);

			int barrelCounter = 0;

			while (stackBullets.Count > 0 && queueLocks.Count > 0)
			{
				int bulletSize = stackBullets.Peek();
				int lockSize = queueLocks.Peek();

				if (bulletSize <= lockSize)
				{
					Console.WriteLine("Bang!");

					stackBullets.Pop();
					intelligence -= priceBullet;
					queueLocks.Dequeue();
					barrelCounter++;

					if (barrelCounter == sizeGunBarrel && stackBullets.Count > 0)
					{
						Console.WriteLine("Reloading!");
						barrelCounter = 0;
					}
				}
				else if (bulletSize > lockSize)
				{
					Console.WriteLine("Ping!");
					stackBullets.Pop();
					intelligence -= priceBullet;
					barrelCounter++;

					if (barrelCounter == sizeGunBarrel && stackBullets.Count > 0)
					{
						Console.WriteLine("Reloading!");
						barrelCounter = 0;
					}
				}
			}
			if (queueLocks.Count == 0)
			{
				Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${intelligence}");
			}
			else
			{
				Console.WriteLine($"Couldn't get through. Locks left: {queueLocks.Count}");
			}
		}
	}
}
