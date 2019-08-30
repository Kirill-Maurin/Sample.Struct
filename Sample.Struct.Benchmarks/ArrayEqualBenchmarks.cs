using System.Linq;
using BenchmarkDotNet.Attributes;
using Sample.Struct.Equatables;
using Sample.Struct.Indexables;

namespace Sample.Struct.Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(Runtimes))]
    public class ArrayBenchmarks
    {
        [Benchmark(Baseline = true)]
        public void LinqSequenceEqualArrayBenchmark() => _array.SequenceEqual(_array2);

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

        static int[] _array = Enumerable.Range(0, 1000).ToArray();

        static int[] _array2 = Enumerable.Range(0, 999).Concat(new int[] { 0 }).ToArray();

        static object[] _objArray = _array.Cast<object>().ToArray();

        static object[] _objArray2 = _objArray.ToArray();
    }
}
