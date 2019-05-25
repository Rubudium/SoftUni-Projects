namespace Balanced_Parentheses
{
	using System;
	using System.Linq;
	using System.Collections.Generic;

	public class StartUp
	{
		public static void Main(string[] args)
		{
			var ParentesesStack = new Stack<char>();

			char[] input = Console.ReadLine().ToCharArray();

			char[] openParenteses = new char[] { '(', '{', '[' };

			bool isValid = true;

			foreach (var item in input)
			{
				if (openParenteses.Contains(item))
				{
					ParentesesStack.Push(item);
					continue;
				}

				if (ParentesesStack.Count == 0)
				{
					isValid = false;
					break;
				}

				if (ParentesesStack.Peek() == '(' && item == ')')
				{
					ParentesesStack.Pop();
				}
				else if (ParentesesStack.Peek() == '{' && item == '}')
				{
					ParentesesStack.Pop();
				}
				else if (ParentesesStack.Peek() == '[' && item == ']')
				{
					ParentesesStack.Pop();
				}
				else
				{
					isValid = false;
					break;
				}
			}
			if (isValid)
			{
				Console.WriteLine("YES");
			}
			else
			{
				Console.WriteLine("NO");
			}
		}
	}
}
