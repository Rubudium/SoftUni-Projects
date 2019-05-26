namespace Diagonal_Difference
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			int input = int.Parse(Console.ReadLine());

			int leftDiagonal = 0;
			int rightDiagonal = 0;

			for (int row = 0; row < input; row++)
			{
				int[] numbers = Console.ReadLine()
					.Split()
					.Select(int.Parse)
					.ToArray();

				for (int col = 0; col < input; col++)
				{
					if (row == col)
					{
						rightDiagonal += numbers[col];
					}

					if (row + col == input - 1)
					{
						leftDiagonal += numbers[col];
					}
				}
			}

			Console.WriteLine(Math.Abs(rightDiagonal-leftDiagonal));
		}
	}
}
