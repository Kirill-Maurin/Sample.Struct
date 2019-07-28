using BenchmarkDotNet.Attributes;
using System;
using System.Linq;

namespace Sample.Struct.Benchmarks
{
    [KeepBenchmarkFiles]
    [MemoryDiagnoser]
    [Config(typeof(Runtimes))]
    public class NotNullBenchmarks
    {
        [Params(10000)]
        public int ActionCount { get; set; }

        [Params(30)]
        public int CheckCount { get; set; }

        [Benchmark(Baseline = true)]
        public void CheckNullBenchmark()
            => TestCheckNull(TestObjects, ActionCount, CheckCount);

        [Benchmark]
        public void EnsureNotNullBenchmark()
            => TestEnsureNotNull(TestObjects, ActionCount, CheckCount);

        [Benchmark]
        public void CannotBeNullBenchmark()
            => TestCannotBeNull(TestObjects, ActionCount, CheckCount);

        static object[] TestObjects { get; } = Enumerable.Range(0, 1000000).Select(i => new object()).ToArray();

        static void TestCheckNull(object[] objects, int wrapCount, int checkCount)
        {
            for (var i = 0; i < wrapCount; i++)
            {
                var o = objects[i];
                for (var _ = 0; _ < checkCount; _++)
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

        static void TestEnsureNotNull(object[] objects, int wrapCount, int checkCount)
        {
            for (var i = 0; i < wrapCount; i++)
            {
                var o = objects[i].EnsureNotNull();
                for (var _ = 0; _ < checkCount; _++)
                {
                    o.Unwrap.ToString();
                }
            }
        }

        static void TestCannotBeNull(object[] objects, int wrapCount, int checkCount)
        {
            for (var i = 0; i < wrapCount; i++)
            {
                var o = objects[i].CannotBeNull();
                for (var _ = 0; _ < checkCount; _++)
                {
                    o.Unwrap.ToString();
                }
            }
        }
    }
}

