using Shared;
using System.Collections.Concurrent;

namespace AsyncSyncronously
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var myBag = new ConcurrentBag<string>();
            myBag.Add("StartingProcess");

            var task = Shared.Shared.PayloadSimulationWithException(1000, myBag);

            if (!task.Wait(1200))
            {
                myBag.Add("Time Out");
            }
            
            foreach (var item in myBag)
            {
                Console.WriteLine(item);
            }
        }
    }
}