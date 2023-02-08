using System.Diagnostics;

namespace AsyncSwapi
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var sw = new Stopwatch();

            sw.Start();
            await Execute();
            sw.Stop();

            Console.WriteLine($"total runtime: {sw.ElapsedMilliseconds}");
        }

        static async Task Execute()
        {
            //todo: your code here
        }

    }
}