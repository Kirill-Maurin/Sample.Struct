using BenchmarkDotNet.Running;

namespace Sample.Struct.Benchmarks
{
    public static partial class Program
    {
        public static void Main(string[] args) => BenchmarkRunner.Run<NotNullBenchmarks>();
    }
}
