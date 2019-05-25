namespace Auto_repair_and_service
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			string[] carName = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

			var carQueue = new Queue<string>(carName);
			var servedCars = new Stack<string>();

			string[] carInfo = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);

			while (carInfo[0] != "End")
			{
				if (carInfo[0] == "Service")
				{
					if (carQueue.Count > 0)
					{
						string carServed = carQueue.Peek();
						servedCars.Push(carServed);
						Console.WriteLine($"Vehicle {carQueue.Dequeue()} got served.");
					}
				}
				if (carInfo[0] == "CarInfo")
				{
					string carToCheck = carInfo[1];

					if (servedCars.Contains(carToCheck))
					{
						Console.WriteLine("Served.");
					}
					else
					{
						Console.WriteLine("Still waiting for service.");
					}
				}
				if (carInfo[0] == "History")
				{
					if (servedCars.Count > 0)
					{
						Console.WriteLine($"{string.Join(", ", servedCars)}");
					}
				}
				carInfo = Console.ReadLine().Split('-', StringSplitOptions.RemoveEmptyEntries);
			}
			if (carQueue.Count > 0)
			{
				Console.WriteLine($"Vehicles for service: {string.Join(", ", carQueue)}");
			}
			Console.WriteLine($"Served vehicles: {string.Join(", ", servedCars)}");
		}
	}
}
