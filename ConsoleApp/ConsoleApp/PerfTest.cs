using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ConsoleApp
{
    [MinColumn]
    [MaxColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [MemoryDiagnoser]
    public class PerfTest
    {
        [Benchmark(Description = "Slice with ReadOnlySpan")]
        public void SliceWithSpan()
        {
            string input = "Hello World!";
            ReadOnlySpan<char> inputSpan = input.AsSpan();
            ReadOnlySpan<char> helloSpan = new[] { 'H', 'e', 'l', 'l', 'o' };

            _ = inputSpan.Slice(0, helloSpan.Length) == helloSpan;
        }

        [Benchmark(Description = "Slice with ReadOnlySpan and OrdinalIgnoreCase")]
        public void SliceWithSpanAndOrdinalIgnoreCase()
        {
            string input = "Hello World!";
            ReadOnlySpan<char> inputSpan = input.AsSpan();
            ReadOnlySpan<char> helloSpan = new[] { 'H', 'e', 'l', 'l', 'o' };

            _ = inputSpan.Slice(0, helloSpan.Length).Equals(helloSpan, StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark(Description = "Slice with StartsWith")]
        public void SliceWithStartsWith()
        {
            string input = "Hello World!";
            string hello = "Hello";

            _ = input.StartsWith(hello);
        }

        [Benchmark(Description = "Slice with StartsWith and OrdinalIgnoreCase")]
        public void SliceWithStartsWithAndOrdinalIgnoreCase()
        {
            string input = "Hello World!";
            string hello = "Hello";

            _ = input.StartsWith(hello, StringComparison.OrdinalIgnoreCase);
        }

        [Benchmark(Description = "Slice with Custom Code")]
        public void SliceWithCustomCode()
        {
            string input = "Hello World!";
            string hello = "Hello";

            int matchCount = 0;

            for (int i = 0; i < hello.Length; i++)
            {
                if (input[i] == hello[i])
                {
                    matchCount++;
                }
                else
                {
                    break;
                }
            }

            _ = matchCount == hello.Length;
        }

        [Benchmark(Description = "Slice with Substring and OrdinalIgnoreCase")]
        public void SliceWithSubstringAndEqualWithOrdinalIgnoreCase()
        {
            string input = "Hello World!";
            string hello = "Hello";

            _ = input.Substring(0, hello.Length).Equals(hello, StringComparison.OrdinalIgnoreCase);
        }
    }
}
