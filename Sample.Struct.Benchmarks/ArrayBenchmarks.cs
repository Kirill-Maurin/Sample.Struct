using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Sample.Struct.Enumerables;
using Sample.Struct.Indexables;
using Sample.Struct.Summators;

namespace Sample.Struct.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Runtimes))]
    public class ArrayBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void IEnumerableIntSumArrayBenchmark() => _array.Sum();

        [Benchmark]
        public void ForEachSumArrayBenchmark() => ForeachSum(_array);

        [Benchmark]
        public void ForSumArrayBenchmark() => ForSum(_array);

        [Benchmark]
        public void GenericIEnumerableIntSumArrayBenchmark() => _array.AsEnumerable().AsStructEnumerable().Sum();

        [Benchmark]
        public void GenericIEnumerableSumArrayBenchmark() => _array.AsEnumerable().AsStructEnumerable().Sum();

        [Benchmark]
        public void GenericEnumerableIntSumArrayBenchmark() => _array.AsStructEnumerable().Sum();

        [Benchmark]
        public void GenericEnumerableSumArrayBenchmark() => _array.AsStructEnumerable().Sum(0.AsAdditive());

        [Benchmark]
        public void GenericIndexableSumArrayBenchmark() => _array.AsIndexable().Sum(0.AsAdditive());

        static int[] _array = Enumerable.Range(0, 1000).ToArray();

        public static int ForeachSum(int[] array)
        {
            var sum = 0;
            foreach (var n in array)
                sum += n;
            return sum;
        }

        public static int ForSum(int[] array)
        {
            var sum = 0;
            for (var i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }
    }
}
