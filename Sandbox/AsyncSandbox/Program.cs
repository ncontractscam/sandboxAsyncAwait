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
            List<Task> tasks = Enumerable.Range(1, 10)
                .Select(z => Shared.Shared.PayloadSimulationWithException(1000, myBag, z)).ToList();
            
            var myTask = Task.WhenAll(tasks);

            try
            {
                myTask.Wait();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine($"We had {myTask.Exception.InnerExceptions.Count} exceptions thrown");
            }

            sw.Stop();


            foreach (var item in myBag)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"Grand Total Runtime: {sw.ElapsedMilliseconds}");
        }
    }
}