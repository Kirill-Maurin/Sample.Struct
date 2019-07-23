using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess;

namespace Sample.Struct.Benchmarks
{
    public sealed class Runtimes : ManualConfig
    {
        public Runtimes() => Add(Job.Default.With(InProcessToolchain.Instance));
    }
}
