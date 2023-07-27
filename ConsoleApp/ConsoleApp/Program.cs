using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // No heap allocation. The entire array (of int) is in stack (???)
            ReadOnlySpan<int> arr = stackalloc int[5] { 1, 2, 3, 4, 5 };

            Summary summary = BenchmarkRunner.Run<PerfTest>();
            Console.WriteLine(summary);
        }
    }
}