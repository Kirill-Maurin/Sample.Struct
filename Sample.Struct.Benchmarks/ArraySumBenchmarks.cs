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
    public class ArraySumBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void LinqSumArrayBenchmark() => _array.Sum();

        [Benchmark]
        public void AggregateSumArrayBenchmark() => _array.Aggregate((l, r) => l+r);

        [Benchmark]
        public void ForSumArrayBenchmark() => ForSum(_array);
                
        [Benchmark]
        public void GenericSumArrayBenchmark() => _array.Sum<int>(0, new IntSummator());

        [Benchmark]
        public void Generic2SumArrayBenchmark() => _array.Sum2(0, new IntSummator());

        [Benchmark]
        public void Generic3SumArrayBenchmark() => _array.Sum<int, IntSummator>(0);
        
        [Benchmark]
        public void Generic4SumArrayBenchmark() => _array.Sum(0.AsAdditive2());

        [Benchmark]
        public void Generic5SumArrayBenchmark() => _array.Sum(0.AsAdditive());

        [Benchmark]
        public void IEnumerableIntSumArrayBenchmark() => Sum(_array);

        public static int Sum(IEnumerable<int> source)
        {
            int sum = 0;
            checked
            {
                foreach (int v in source)
                    sum += v;
            }
            return sum;
        }

        [Benchmark]
        public void ForEachSumArrayBenchmark() => ForeachSum(_array);


        [Benchmark]
        public void GenericIEnumerableIntSumArrayBenchmark() => _array.AsEnumerable().AsStructEnumerable().Sum();

        [Benchmark]
        public void GenericEnumerableIntSumArrayBenchmark() => _array.AsStructEnumerable().Sum();

        [Benchmark]
        public void GenericEnumerableIntCheckedSumArrayBenchmark() => _array.AsStructEnumerable().Sum(0.AsCheckedAdditive());

        [Benchmark]
        public void GenericEnumerableSumArrayBenchmark() => _array.AsStructEnumerable().Sum(0.AsAdditive());

        [Benchmark]
        public void GenericEnumerableLongSumArrayBenchmark() => _array.AsStructEnumerable().Sum(0.AsAccumulator());

        [Benchmark]
        public void GenericIndexableSumArrayBenchmark() => _array.AsIndexable().Sum(0.AsAdditive());
        */
        static int[] _array = Enumerable.Range(0, 1000).ToArray();

        public static int ForeachSum(int[] array)
        {
            var sum = 0;
            foreach (var n in array)
                sum += n;
            return sum;
        }

        public static long ForSum(int[] array)
        {
            var sum = 0L;
            for (var i = 0; i < array.Length; i++)
                sum += array[i];
            return sum;
        }
    }
}
