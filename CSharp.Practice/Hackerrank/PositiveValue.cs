using System;
using System.Collections;

namespace Hackerrank
{
	public class PositiveValue
	{
		public static int MinValue(int[] A)
		{
			int minPositive = 1;
			int maxPositive = 1;
			Hashtable hash = new Hashtable();
			for (int i = 0; i < A.Length; i++)
			{
				if (A[i] < minPositive)
				{
					minPositive = A[i];
				} else if (A[i] >= maxPositive)
				{
					maxPositive = A[i];
				}
				if (!hash.ContainsKey(A[i]))
				{
					hash.Add(A[i], true);
                }
            }

			if (maxPositive <= 0)
			{
				return 1;
			}

			for (int i = 1; i <= maxPositive; i++)
			{
				if (!hash.ContainsKey(i))
				{
					return i;
				}
			}

			return maxPositive + 1;
		}

		public static void Run()
		{
			//List<int> a = new List<int>() { 1, 3, 6, 4, 1, 2 };
            List<int> a = new List<int>() { 1, 6, 1000000 };
            //List<int> a = new List<int>() { 1, 2, 3 };
            //List<int> a = new List<int>() { -1, -3 };
            Console.WriteLine(MinValue(a.ToArray()));
		}
	}
}

