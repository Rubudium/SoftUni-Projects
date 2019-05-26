namespace Snake_moves
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			int[] dimension = Console.ReadLine()
				.Split()
				.Select(int.Parse)
				.ToArray();

			int rows = dimension[0];
			int cols = dimension[1];

			char[,] matrix = new char[rows,cols];

			string snake = Console.ReadLine();

			int counter = 0;

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					if (counter >=  snake.Length)
					{
						counter = 0;
					}

					matrix[row, col] = snake[counter++];
				}
			}

			for (int row = 0; row < matrix.GetLength(0); row++)
			{
				for (int col = 0; col < matrix.GetLength(1); col++)
				{
					Console.Write(matrix[row,col]);
				}
				Console.WriteLine();
			}
		}
	}
}
