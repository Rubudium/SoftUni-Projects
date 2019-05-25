namespace Sets_and_Dictionaries_Advanced
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			var wardrobe = new Dictionary<string, Dictionary<string,int>>();

			int counter = int.Parse(Console.ReadLine());

			for (int i = 0; i < counter; i++)
			{
				string[] inputArgs = Console.ReadLine().Split(" -> ");

				string color = inputArgs[0];

				if (!wardrobe.ContainsKey(color))
				{
					wardrobe.Add(color, new Dictionary<string, int>());
				}

				string[] clothes = inputArgs[1].Split(',');

				foreach (var cloth in clothes)
				{
					if (!wardrobe[color].ContainsKey(cloth))
					{
						wardrobe[color].Add(cloth, 0);
					}

					wardrobe[color][cloth]++;
				}
			}

			string[] targetClothInfo = Console.ReadLine().Split();

			string targetColor = targetClothInfo[0];
			string targetCloth = targetClothInfo[1];

			foreach (var (color, clothes) in wardrobe)
			{
				Console.WriteLine($" {color} clothes:");

				foreach (var (cloth, count) in clothes)
				{
					string result = $"* {cloth} - {count}";

					if (color == targetColor && cloth == targetCloth)
					{
						result += " (found!)";
					}
					Console.WriteLine(result);
				}
			}
		}
	}
}
