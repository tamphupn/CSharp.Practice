using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DownloadFiles
{
    class Program
    {

        private static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("START DOWNLOADING");
            var tasks = new List<Task>()
            {
                DownloadFile("file01"), DownloadFile("file02"), DownloadFile("file03")
            };

            ProcessTask(tasks);
            
        }

        static async Task ProcessTask(List<Task> tasks)
        {
            Console.WriteLine("START DOWNLOADING PROCESS");
            await Task.WhenAll(tasks);
            Console.WriteLine("COMPLETED DOWNLOADING");
        }

        static async Task DownloadFile(string fileName)
        {
            Console.WriteLine($@"Downloading file {fileName}");
            int downloadTime = rnd.Next(1, 5);
            await Task.Delay(downloadTime);
            Console.WriteLine($@"Download completed file {fileName} - Execution time: {downloadTime}s");
        }
    }
}