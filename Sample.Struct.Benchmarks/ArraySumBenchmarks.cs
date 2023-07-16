using System;
using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Sample.Struct;
using Sample.Struct.Enumerables;
using Sample.Struct.Indexables;
using Sample.Struct.Summators;

namespace Sample.Struct.Benchmarks;

[MemoryDiagnoser]
[Config(typeof(Runtimes))]
public class ArraySumBenchmarks
{
    static readonly int[] _array = Enumerable.Range(0, 1000).ToArray();

    [Benchmark(Baseline = true)]
    public void LinqSumArrayBenchmark() => _array.Sum();

    [Benchmark]
    public void AggregateSumArrayBenchmark() => _array.Aggregate((l, r) => l + r);

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
    public void GenericCheckedSumArrayBenchmark() => _array.Sum(0.AsCheckedAdditive());

    [Benchmark]
    public void GenericLongSumArrayBenchmark() => _array.Sum(0L.AsAccumulator());

    [Benchmark]
    public void GenericIndexableSumArrayBenchmark() => _array.AsGenericIndexable().Sum(0L.AsAccumulator());

    [Benchmark]
    public void Generic2IndexableSumArrayBenchmark() => _array.AsIndexable().Sum(0L.AsAccumulator());

    [Benchmark]
    public void Generic2IndexableDefaultSumArrayBenchmark() => _array.AsIndexable().Sum(0L.AsAccumulator(0));

    [Benchmark]
    public void Generic2EnumerableSumArrayBenchmark() => _array.AsStructEnumerable().Sum(0L.AsAccumulator());

    [Benchmark]
    public void Generic2EnumerableSumMemoryBenchmark() =>
        _array.AsMemory().AsStructEnumerable().Sum(0L.AsAccumulator());

    [Benchmark]
    public void Generic2EnumerableFoldSumArrayBenchmark() =>
        _array.AsStructEnumerable().Fold(0L, default(LongIntSummator));

    [Benchmark]
    public void EnumerableIntSumArrayBenchmark() => Sum(_array);

    public static int Sum(IEnumerable<int> source)
    {
        var sum = 0;
        checked
        {
            foreach (var v in source)
                sum += v;
        }

        return sum;
    }

    [Benchmark]
    public void ForEachSumArrayBenchmark() => ForeachSum(_array);

    [Benchmark]
    public void ForEachSpanSumArrayBenchmark() => SpanSum(_array.AsSpan());

    [Benchmark]
    public void ForEachSpanEnumerableSumArrayBenchmark() =>
        EnumerableSpanForeachSum(_array.AsSpan().AsSpanEnumerable());

    [Benchmark]
    public void SpanEnumerableSumArrayBenchmark() => EnumerableSpanSum(_array.AsSpan());

    [Benchmark]
    public void GenericIEnumerableIntSumArrayBenchmark() => _array.AsEnumerable().AsStructEnumerable().Sum();

    [Benchmark]
    public void GenericEnumerableIntSumArrayBenchmark() => _array.AsStructEnumerable().Sum();

    [Benchmark]
    public void GenericEnumerableIntCheckedSumArrayBenchmark() =>
        _array.AsStructEnumerable().Sum(0.AsCheckedAdditive());

    [Benchmark]
    public void GenericEnumerableSumArrayBenchmark() => _array.AsStructEnumerable().Sum(0.AsAdditive());

    [Benchmark]
    public void GenericEnumerableSelectSumArrayBenchmark() => _array.Select(n => n + 5).Sum();

    [Benchmark]
    public void Generic2EnumerableSelectSumArrayBenchmark() => _array.AsStructEnumerable().Select(n => n + 5).Sum();

    [Benchmark]
    public void Generic3EnumerableSelectSumArrayBenchmark() => _array.AsStructLinqable().Select(n => n + 5).Sum();

    public static int SpanSum(Span<int> span)
    {
        var sum = 0;
        foreach (var n in span)
            sum += n;
        return sum;
    }

    public static int EnumerableSpanForeachSum(SpanEnumerable<int> se)
    {
        var sum = 0;
        foreach (var n in se)
            sum += n;
        return sum;
    }

    public static int EnumerableSpanSum(Span<int> span)
    {
        var sum = 0;
        for (var e = span.GetEnumerator(); e.MoveNext();)
            sum += e.Current;
        return sum;
    }

    public static int ForeachSum(int[] array)
    {
        var sum = 0;
        foreach (var n in array)
            sum += n + 5;
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