namespace Sample.Struct.Benchmarks;

using System.Linq;
using BenchmarkDotNet.Attributes;
using Equatables;
using Indexables;

[MemoryDiagnoser]
[Config(typeof(Runtimes))]
public class ArrayBenchmarks
{
    private static readonly int[] Array = Enumerable.Range(0, 1000).ToArray();

    private static readonly int[] Array2 = Enumerable.Range(0, 999).Concat(new[] { 0 }).ToArray();

    private static readonly object[] ObjArray = Array.Cast<object>().ToArray();

    private static readonly object[] ObjArray2 = ObjArray.ToArray();

    [Benchmark(Baseline = true)]
    public void LinqSequenceEqualArrayBenchmark()
    {
        Array.SequenceEqual(Array2);
    }

    [Benchmark]
    public void GenericIndexableSequenceEqualArrayBenchmark()
    {
        Array.AsGenericIndexable().SequenceEqual(Array2.AsGenericIndexable(), default(IntComparer));
    }

    [Benchmark]
    public void StructIndexableSequenceEqualArrayBenchmark()
    {
        Array.AsStructIndexable().SequenceEqual(Array2.AsStructIndexable(), default(IntComparer));
    }

    [Benchmark]
    public void IndexableSequenceEqualArrayBenchmark()
    {
        Array.AsIndexable().SequenceEqual(Array2.AsIndexable(), default(IntComparer));
    }

    [Benchmark]
    public void IndexableSequenceEqualDefaultArrayBenchmark()
    {
        Array.AsIndexable().SequenceEqual(Array2.AsIndexable(), default(DefaultComparer<int>));
    }

    [Benchmark]
    public void IndexableSequenceEqualObjectArrayBenchmark()
    {
        ObjArray.AsIndexable().SequenceEqual(ObjArray2.AsIndexable(), default(ObjectComparer));
    }

    [Benchmark]
    public void ForSequenceEqualArrayBenchmark()
    {
        ForSequenceEqual(Array, Array2);
    }

    public bool ForSequenceEqual(int[] left, int[] right)
    {
        if (left == right)
            return true;
        if (left == null || right == null || left.Length != right.Length)
            return false;
        for (int c = 0; c < left.Length; c++)
            if (left[c] != right[c])
                return false;

        return true;
    }
}
