using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace C16
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName;
            if(args.Length < 1)
                fileName = "urls.txt";
            else 
                fileName = args[0];
            
            var urls = File.ReadAllLines(fileName);

            Stopwatch s = new Stopwatch();
            s.Start();
            foreach(var url in urls)
            {
                var task = DownloadInOrder(url);
                task.Wait();
                Console.WriteLine(task.Result);
            }              
            s.Stop();
            System.Console.WriteLine($"\nelapsed time: {s.Elapsed}");
            s.Reset();

            System.Console.WriteLine("----------------------------------------\n");
            
            s.Start();
            Array.ForEach(DownloadParallel(urls).Result, System.Console.WriteLine);
            s.Stop();
            System.Console.WriteLine($"\nelapsed time: {s.Elapsed}");
        }

        private static async Task<string> DownloadInOrder(string url)
        {
            using HttpClient client = new HttpClient();
            var dl = await client.GetStringAsync(url);
            return  $"{url}: Downloaded. length: {dl.Length}\n";
        }

        private static async Task<string[]> DownloadParallel(string[] urls)
        {
            string[] Announce = new string[urls.Length];
            using HttpClient client = new HttpClient();
            for (int i = 0; i < urls.Length; i++)
            {
                var dl = client.GetStringAsync(urls[i]);
                Task<int> length = dl.ContinueWith((re) =>re.Result.Length);
                Announce[i] =  $"{urls[i]}: Done. length: {length.Result}";
            }
            return Announce;
        }
    }
}
