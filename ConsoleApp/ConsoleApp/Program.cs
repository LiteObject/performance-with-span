using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Summary summary = BenchmarkRunner.Run<PerfTest>();
            Console.WriteLine(summary);
        }
    }
}