using System;
namespace Hackerrank
{
	public class Brackets
	{
        public static string isBalanced(string s)
        {
            if (s.Length == 0)
            {
                return "YES";
            }

            List<char> openBrakets = new List<char>() { '(', '[', '{' };
            List<char> closeBrakets = new List<char>() { ')', ']', '}' };
            Stack<char> brakets = new Stack<char>();
            foreach (var character in s)
            {
                if (openBrakets.Contains(character))
                {
                    brakets.Push(character);
                }
                else
                {
                    int closeBraketType = closeBrakets.IndexOf(character);
                    char openBraket;
                    var peek = brakets.TryPeek(out openBraket);
                    if (peek)
                    {
                        int openBraketType = openBrakets.IndexOf(openBraket);

                        if (closeBraketType == openBraketType)
                        {
                            char a;
                            var res = brakets.TryPop(out a);
                        }
                        else
                        {
                            return "NO";
                        }
                    }
                }
            }

            return brakets.Count > 0 ? "NO" : "YES";
        }
    }
}

