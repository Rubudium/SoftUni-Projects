namespace Sets_and_Dictionaries_Advanced
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			string firstInput = Console.ReadLine();

			var contestPassword = new Dictionary<string, string>();

			while (firstInput != "end of contests")
			{
				string[] tokens = firstInput.Split(":");
				string contest = tokens[0];
				string password = tokens[1];

				contestPassword.Add(contest, password);
				firstInput = Console.ReadLine();
			}

			string secondInput = Console.ReadLine();

			var submissions = new SortedDictionary<string, Dictionary<string, int>>();

			while (secondInput != "end of submissions")
			{
				string[] tokens = secondInput.Split("=>");
				string contest = tokens[0];
				string password = tokens[1];
				string username = tokens[2];
				int points = int.Parse(tokens[3]);

				if (!contestPassword.ContainsKey(contest) || contestPassword[contest] != password)
				{
					secondInput = Console.ReadLine();
					continue;
				}

				if (!submissions.ContainsKey(username))
				{
					submissions[username] = new Dictionary<string, int> { { contest, points } };
				}

				if (!submissions[username].ContainsKey(contest))
				{
					submissions[username].Add(contest, points);
				}

				if (submissions[username][contest] < points)
				{
					submissions[username][contest] = points;
				}

				secondInput = Console.ReadLine();
			}

			var userTotalPts = new Dictionary<string, int>();

			foreach (var kvp in submissions)
			{
				userTotalPts[kvp.Key] = kvp.Value.Values.Sum();
			}

			string bestCandidate = userTotalPts.Keys.Max();

			int bestPts = userTotalPts.Values.Max();

			foreach (var item in userTotalPts)
			{
				if (bestPts == item.Value)
				{
					Console.WriteLine($"Best candidate is {item.Key} with total {item.Value} points.");
				}
			}

			Console.WriteLine("Ranking:");

			foreach (var kvp in submissions)
			{
				Console.WriteLine(kvp.Key);
				Console.WriteLine(string.Join(Environment.NewLine, kvp.Value.OrderByDescending(x => x.Value).Select(a => $"#  {a.Key} -> {a.Value}")));
			}
		}
	}
}
