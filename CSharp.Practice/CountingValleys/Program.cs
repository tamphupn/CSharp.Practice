using System;

namespace CountingValleys
{
    class Hiker
    {
        public static int CountingValleys(int steps, string path)
        {
            int totalValley = 0, step = 0;
            foreach (char character in path)
            {
                if (character == 'D')
                {
                    step--;
                }
                else
                {
                    if (step == -1)
                    {
                        totalValley++;
                    }
                    step++;
                }
            }

            return totalValley;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int steps = Convert.ToInt32(Console.ReadLine().Trim());
            string path = Console.ReadLine();
            int result = Hiker.CountingValleys(steps, path);
            Console.WriteLine(result);
        }
    }
}