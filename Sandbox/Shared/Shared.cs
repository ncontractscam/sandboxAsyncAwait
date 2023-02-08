using System.Collections.Concurrent;
using System.Diagnostics;

namespace Shared
{
    public static class Shared
    {
        public static async Task PayloadSimulation(int miliseconds, ConcurrentBag<string> bag, int id = 0) 
        {
            var sw = new Stopwatch();
            sw.Start();
            await Task.Delay(miliseconds);
            sw.Stop();
            bag.Add($"Finished Payload. Expected Runtime: {miliseconds}, ActualRuntime: {sw.ElapsedMilliseconds}, Thread Name: {Thread.CurrentThread.ManagedThreadId}");
        }

        public static async Task PayloadSimulationWithException(int miliseconds, ConcurrentBag<string> bag, int exceptionNumber = 0) 
        {
            var sw = new Stopwatch();
            bag.Add("Running Payload");
            sw.Start();
            await Task.Delay(miliseconds);
            sw.Stop();

            switch (exceptionNumber)
            {
                case 0:
                    throw new Exception($"ERROR after: {sw.ElapsedMilliseconds}");    
                case 1:
                    throw new ArgumentException($"ERROR after: {sw.ElapsedMilliseconds}");    
                case 2:
                    throw new NullReferenceException($"ERROR after: {sw.ElapsedMilliseconds}");    
                case 3:
                    throw new OutOfMemoryException($"ERROR after: {sw.ElapsedMilliseconds}");
                default:
                    throw new DivideByZeroException($"ERROR after: {sw.ElapsedMilliseconds}");
            }
        }
    }
}