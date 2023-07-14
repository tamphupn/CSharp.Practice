using System;
using System.IO;

namespace CountingValleys
{
    class Result
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
            TextWriter textWriter = new StreamWriter(System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
            int steps = Convert.ToInt32(Console.ReadLine().Trim());
            string path = Console.ReadLine();
            int result = Result.CountingValleys(steps, path);
            textWriter.WriteLine(result);

            textWriter.Flush();
            textWriter.Close();
        }
    }
}

