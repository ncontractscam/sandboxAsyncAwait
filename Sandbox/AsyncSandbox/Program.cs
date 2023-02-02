using Shared;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSandbox
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var myBag = new ConcurrentBag<string>();
            myBag.Add("Starting Process");

            var sw = new Stopwatch();
            sw.Start();
            List<Task> tasks = Enumerable.Range(1, 10000)
                .Select(z => Shared.Shared.PayloadSimulation(1000, myBag, z)).ToList();

            await Task.WhenAll(tasks);
            sw.Stop();

            var path = "C:/dev/testData.txt";
            using (FileStream fs = File.Create(path))

                foreach (var item in myBag)
                {
                    var value = item + "\n";
                    byte[] info = new UTF8Encoding(true).GetBytes(value);
                    fs.Write(info, 0, info.Length);                    
                }

            Console.WriteLine($"Grand Total Runtime: {sw.ElapsedMilliseconds}");
        }
    }
}