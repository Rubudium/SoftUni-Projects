namespace Matrix_Shuffling
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			int[] rowsCols = Console.ReadLine()
				.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(int.Parse)
				.ToArray();

			int rows = rowsCols[0];
			int cols = rowsCols[1];

			string[,] matrix = new string[rows, cols];

			for (int row = 0; row < rows; row++)
			{
				string[] items = Console.ReadLine()
				.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				for (int col = 0; col < cols; col++)
				{
					matrix[row, col] = items[col];
				}
			}

			string command = Console.ReadLine();

			while(command != "END")
			{
				string[] tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

				if (!tokens.Contains("swap") || tokens.Length < 5 || tokens.Length > 5)
				{
					Console.WriteLine("Invalid input!");
					command = Console.ReadLine();
					continue;
				}

				int startRow = int.Parse(tokens[1]);
				int startCol = int.Parse(tokens[2]);
				int endRow = int.Parse(tokens[3]);
				int endCol = int.Parse(tokens[4]);

				if (startRow >= 0 && startRow < rows && endCol >= 0 && endCol < cols)
				{
					string save = matrix[endRow, endCol];

					matrix[endRow, endCol] = matrix[startRow, startCol];
					matrix[startRow, startCol] = save;

					for (int row = 0; row < rows; row++)
					{
						for (int col = 0; col < cols; col++)
						{
							Console.Write(matrix[row,col] + " ");
						}

						Console.WriteLine();
					}
				}
				else
				{
					Console.WriteLine("Invalid input!");
				}
				command = Console.ReadLine();
			}
		}
	}
}
