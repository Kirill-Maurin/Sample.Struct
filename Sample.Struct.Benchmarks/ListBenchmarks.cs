using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Sample.Struct.Enumerables;
using Sample.Struct.Indexables;
using Sample.Struct.Summators;

namespace Sample.Struct.Benchmarks
{
    public class ListBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void SumListBenchmark() => _list.Sum();

        [Benchmark]
        public void ForEachSumListBenchmark() => ForEachSum(_list);

        static int ForEachSum(List<int> list)
        {
            var sum = 0;
            foreach (var n in list)
                sum += n;
            return sum;
        }

        [Benchmark]
        public void ForSumListBenchmark() => ForSum(_list);

        static int ForSum(List<int> list)
        {
            var sum = 0;
            for (var i = 0; i < list.Count; i++)
                sum += list[i];
            return sum;
        }

        [Benchmark]
        public void GenericIndexableSumListBenchmark() => _list.AsIndexable().Sum(0.AsAdditive());

        [Benchmark]
        public void GenericEnumerableSumListBenchmark() => _list.AsStructEnumerable().Sum();

        static List<int> _list = Enumerable.Range(0, 1000).ToList();
    }
}
