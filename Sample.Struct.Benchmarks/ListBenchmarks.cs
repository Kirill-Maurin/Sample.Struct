namespace Sample.Struct.Benchmarks;

using System.Collections.Generic;
using System.Linq;
using BenchmarkDotNet.Attributes;
using Enumerables;
using Indexables;
using Summators;

public class ListBenchmarks
{
    private static readonly List<int> List = Enumerable.Range(0, 1000).ToList();

    [Benchmark(Baseline = true)]
    public void SumListBenchmark()
    {
        List.Sum();
    }

    [Benchmark]
    public void ForEachSumListBenchmark()
    {
        ForEachSum(List);
    }

    private static int ForEachSum(List<int> list)
    {
        int sum = 0;
        foreach (int n in list)
            sum += n;
        return sum;
    }

    [Benchmark]
    public void ForSumListBenchmark()
    {
        ForSum(List);
    }

    private static int ForSum(List<int> list)
    {
        int sum = 0;
        for (int i = 0; i < list.Count; i++)
            sum += list[i];
        return sum;
    }

    [Benchmark]
    public void GenericIndexableSumListBenchmark()
    {
        List.AsIndexable().Sum(0.AsAdditive());
    }

    [Benchmark]
    public void GenericEnumerableSumListBenchmark()
    {
        List.AsStructEnumerable().Sum();
    }
}
