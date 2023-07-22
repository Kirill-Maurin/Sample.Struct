namespace Sample.Struct.Benchmarks;

using System;
using System.Linq;
using BenchmarkDotNet.Attributes;

[KeepBenchmarkFiles]
[MemoryDiagnoser]
[Config(typeof(Runtimes))]
public class NotNullBenchmarks
{
    [Params(10000)] public int ActionCount { get; set; }

    [Params(30)] public int CheckCount { get; set; }

    private static object[] TestObjects { get; } = Enumerable.Range(0, 1000000).Select(i => new object()).ToArray();

    [Benchmark(Baseline = true)]
    public void CheckNullBenchmark()
    {
        TestCheckNull(TestObjects, ActionCount, CheckCount);
    }

    [Benchmark]
    public void EnsureNotNullBenchmark()
    {
        TestEnsureNotNull(TestObjects, ActionCount, CheckCount);
    }

    [Benchmark]
    public void CannotBeNullBenchmark()
    {
        TestCannotBeNull(TestObjects, ActionCount, CheckCount);
    }

    private static void TestCheckNull(object[] objects, int wrapCount, int checkCount)
    {
        for (int i = 0; i < wrapCount; i++)
        {
            object o = objects[i];
            for (int _ = 0; _ < checkCount; _++)
            {
                CheckNull(o);
                o.ToString();
            }
        }
    }

    private static void CheckNull(object @object)
    {
        if (@object == null)
            throw new ArgumentNullException(nameof(@object));
    }

    private static void TestEnsureNotNull(object[] objects, int wrapCount, int checkCount)
    {
        for (int i = 0; i < wrapCount; i++)
        {
            NotNull<object> o = objects[i].EnsureNotNull();
            for (int _ = 0; _ < checkCount; _++) o.Value.ToString();
        }
    }

    private static void TestCannotBeNull(object[] objects, int wrapCount, int checkCount)
    {
        for (int i = 0; i < wrapCount; i++)
        {
            NotNull<object> o = objects[i].CannotBeNull();
            for (int _ = 0; _ < checkCount; _++) o.Value.ToString();
        }
    }
}
