namespace Sample.Struct.Benchmarks;

using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Enumerables;
using Indexables;
using Summators;

[MemoryDiagnoser]
[Config(typeof(Runtimes))]
public class ArraySumBenchmarks
{
    private static readonly int[] Array = Enumerable.Range(0, 1000).ToArray();

    [Benchmark(Baseline = true)]
    public void LinqSumArrayBenchmark()
    {
        Array.Sum();
    }

    [Benchmark]
    public void AggregateSumArrayBenchmark()
    {
        Array.Aggregate((l, r) => l + r);
    }

    [Benchmark]
    public void ForSumArrayBenchmark()
    {
        ForSum(Array);
    }

    [Benchmark]
    public void GenericSumArrayBenchmark()
    {
        Array.Sum<int>(0, new IntSummator());
    }

    [Benchmark]
    public void Generic2SumArrayBenchmark()
    {
        Array.Sum2(0, new IntSummator());
    }

    [Benchmark]
    public void Generic3SumArrayBenchmark()
    {
        Array.Sum<int, IntSummator>(0);
    }

    [Benchmark]
    public void Generic4SumArrayBenchmark()
    {
        Array.Sum(0.AsAdditive2());
    }

    [Benchmark]
    public void Generic5SumArrayBenchmark()
    {
        Array.Sum(0.AsAdditive());
    }

    [Benchmark]
    public void GenericCheckedSumArrayBenchmark()
    {
        Array.Sum(0.AsCheckedAdditive());
    }

    [Benchmark]
    public void GenericLongSumArrayBenchmark()
    {
        Array.Sum(0L.AsAccumulator());
    }

    [Benchmark]
    public void GenericIndexableSumArrayBenchmark()
    {
        Array.AsGenericIndexable().Sum(0L.AsAccumulator());
    }

    [Benchmark]
    public void Generic2IndexableSumArrayBenchmark()
    {
        Array.AsIndexable().Sum(0L.AsAccumulator());
    }

    [Benchmark]
    public void Generic2IndexableDefaultSumArrayBenchmark()
    {
        Array.AsIndexable().Sum(0L.AsAccumulator(0));
    }

    [Benchmark]
    public void Generic2EnumerableSumArrayBenchmark()
    {
        Array.AsStructEnumerable().Sum(0L.AsAccumulator());
    }

    [Benchmark]
    public void Generic2EnumerableSumMemoryBenchmark()
    {
        Array.AsMemory().AsStructEnumerable().Sum(0L.AsAccumulator());
    }

    [Benchmark]
    public void Generic2EnumerableFoldSumArrayBenchmark()
    {
        Array.AsStructEnumerable().Fold(0L, default(LongIntSummator));
    }

    [Benchmark]
    public void IEnumerableIntSumArrayBenchmark()
    {
        Sum(Array);
    }

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
    public void ForEachSumArrayBenchmark()
    {
        ForeachSum(Array);
    }

    [Benchmark]
    public void ForEachSpanSumArrayBenchmark()
    {
        SpanSum(Array.AsSpan());
    }

    [Benchmark]
    public void ForEachSpanEnumerableSumArrayBenchmark()
    {
        EnumerableSpanForeachSum(Array.AsSpan().AsSpanEnumerable());
    }

    [Benchmark]
    public void SpanEnumerableSumArrayBenchmark()
    {
        EnumerableSpanSum(Array.AsSpan());
    }

    [Benchmark]
    public void GenericIEnumerableIntSumArrayBenchmark()
    {
        Array.AsEnumerable().AsStructEnumerable().Sum();
    }

    [Benchmark]
    public void GenericEnumerableIntSumArrayBenchmark()
    {
        Array.AsStructEnumerable().Sum();
    }

    [Benchmark]
    public void GenericEnumerableIntCheckedSumArrayBenchmark()
    {
        Array.AsStructEnumerable().Sum(0.AsCheckedAdditive());
    }

    [Benchmark]
    public void GenericEnumerableSumArrayBenchmark()
    {
        Array.AsStructEnumerable().Sum(0.AsAdditive());
    }

    [Benchmark]
    public void GenericEnumerableSelectSumArrayBenchmark()
    {
        Array.Select(n => n + 5).Sum();
    }

    [Benchmark]
    public void Generic2EnumerableSelectSumArrayBenchmark()
    {
        Array.AsStructEnumerable().Select(n => n + 5).Sum();
    }

    [Benchmark]
    public void Generic3EnumerableSelectSumArrayBenchmark()
    {
        Array.AsStructLinqable().Select(n => n + 5).Sum();
    }

    public static int SpanSum(Span<int> span)
    {
        int sum = 0;
        foreach (int n in span)
            sum += n;
        return sum;
    }

    public static int EnumerableSpanForeachSum(SpanEnumerable<int> se)
    {
        int sum = 0;
        foreach (int n in se)
            sum += n;
        return sum;
    }

    public static int EnumerableSpanSum(Span<int> span)
    {
        int sum = 0;
        for (Span<int>.Enumerator e = span.GetEnumerator(); e.MoveNext();)
            sum += e.Current;
        return sum;
    }

    public static int ForeachSum(int[] array)
    {
        int sum = 0;
        foreach (int n in array)
            sum += n + 5;
        return sum;
    }

    public static long ForSum(int[] array)
    {
        long sum = 0L;
        for (int i = 0; i < array.Length; i++)
            sum += array[i];
        return sum;
    }
}
