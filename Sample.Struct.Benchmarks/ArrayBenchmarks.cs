using System.Linq;
using BenchmarkDotNet.Attributes;
using Sample.Struct.Enumerables;
using Sample.Struct.Equatables;
using Sample.Struct.Indexables;
using Sample.Struct.Summators;

namespace Sample.Struct.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Runtimes))]
    public class ArrayBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void IEnumerableIntSequenceEqualArrayBenchmark() => _array.SequenceEqual(_array2);

        [Benchmark]
        public void GenericIndexableSequenceEqualArrayBenchmark() => _array.AsGenericIndexable().SequenceEqual(_array2.AsGenericIndexable(), default(IntComparer));

        [Benchmark]
        public void StructIndexableSequenceEqualArrayBenchmark() => _array.AsStructIndexable().SequenceEqual(_array2.AsStructIndexable(), default(IntComparer));

        [Benchmark]
        public void IndexableSequenceEqualArrayBenchmark() => _array.AsIndexable().SequenceEqual(_array2.AsIndexable(), default(IntComparer));

        [Benchmark]
        public void IndexableSequenceEqualDefaultArrayBenchmark() => _array.AsIndexable().SequenceEqual(_array2.AsIndexable(), default(DefaultComparer<int>));

        [Benchmark]
        public void IndexableSequenceEqualObjectArrayBenchmark() => _objArray.AsIndexable().SequenceEqual(_objArray2.AsIndexable(), default(ObjectComparer));

        [Benchmark]
        public void ForSequenceEqualArrayBenchmark() => ForSequenceEqual(_array, _array2);

        public bool ForSequenceEqual(int[] left, int[] right)
        {
            if (left == right)
                return true;
            if (left == null || right == null || left.Length != right.Length)
                return false;
            for (var c = 0; c < left.Length; c++)
            {
                if (left[c] != right[c])
                    return false;
            }

            return true;
        }

        [Benchmark(Baseline = true)]
        public void IEnumerableIntSumArrayBenchmark() => _array.Sum();

        [Benchmark]
        public void ForEachSumArrayBenchmark() => ForeachSum(_array);

        [Benchmark]
        public void ForSumArrayBenchmark() => ForSum(_array);

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

        static int[] _array = Enumerable.Range(0, 1000).ToArray();

        static int[] _array2 = Enumerable.Range(0, 999).Concat(new int[] { 0 }).ToArray();

        static object[] _objArray = _array.Cast<object>().ToArray();

        static object[] _objArray2 = _objArray.ToArray();

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
