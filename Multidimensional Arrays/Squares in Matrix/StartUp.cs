namespace Diagonal_Difference
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			int[] rowsCols = Console.ReadLine()
				.Split(new[] { ' ' },StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int rows = rowsCols[0];
			int cols = rowsCols[1];

			char[,] matrix = new char[rows, cols];

			for (int row = 0; row < rows; row++)
			{
				char[] symbols = Console.ReadLine()
					.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
					.Select(char.Parse)
					.ToArray();

				for (int col = 0; col < cols; col++)
				{
					matrix[row, col] = symbols[col];
				}
			}

			int squareMatrix = 0;

			for (int row = 0; row < rows - 1; row++)
			{
				for (int col = 0; col < cols - 1; col++)
				{
					char currentSymbol = matrix[row, col];

					if (currentSymbol == matrix[row,col +1] 
						&& currentSymbol == matrix[row + 1, col] 
						&& currentSymbol == matrix[row +1, col +1])
					{
						squareMatrix++;
					}
				}
			}

			Console.WriteLine(squareMatrix);
		}
	}
}
