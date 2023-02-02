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

        public static async Task PayloadSimulationWithException(int miliseconds, ConcurrentBag<string> bag) 
        {
            var sw = new Stopwatch();
            bag.Add("Running Payload");
            sw.Start();
            await Task.Delay(miliseconds);
            sw.Stop();
            throw new Exception($"Finished Payload. Expected Runtime: {miliseconds}, ActualRuntime: {sw.ElapsedMilliseconds}");    
        }
    }
}