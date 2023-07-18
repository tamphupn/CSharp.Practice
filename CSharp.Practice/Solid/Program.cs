using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DownloadFiles
{
    class FileDownload
    {
        private static Random rnd = new Random();
        private const int MIN_RND_TIME = 1;
        private const int MAX_RND_TIME = 5;
        private string FileName { get; set; }

        public FileDownload()
        {
            FileName = $@"FILE_{Guid.NewGuid()}";
        }

        public FileDownload(string fileName)
        {
            FileName = fileName;
        }

        public async Task ProcessDownloadAsync()
        {
            int totalDownloadSecond = rnd.Next(MIN_RND_TIME, MAX_RND_TIME);
            Console.WriteLine($@"Downloading file {FileName} - Started time: {DateTime.Now} - Estimate time: {totalDownloadSecond}s");
            await Task.Delay(totalDownloadSecond * 1000);
            Console.WriteLine($@"Download completed file {FileName} -Finished Time: {DateTime.Now} - Execution time: {totalDownloadSecond}s");
        }
    }

    class Program
    {
        private const int TOTAL_FILE = 6;

        static void Main(string[] args)
        {
            var taskFileResult = new List<Task>();
            var taskFiles = new List<FileDownload>();
            Console.WriteLine("----START DOWNLOADING----");

            for (int i = 0; i < TOTAL_FILE; i++)
            {
                taskFiles.Add(new FileDownload());
            }

            foreach (var taskFile in taskFiles)
            {
                taskFileResult.Add(taskFile.ProcessDownloadAsync());
            }
            Task.WhenAll(taskFileResult).Wait();
            Console.WriteLine("----All downloads finished----");

        }
    }
}