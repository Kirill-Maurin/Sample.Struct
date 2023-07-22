using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;

namespace Sample.Struct.Benchmarks
{
    using BenchmarkDotNet.Toolchains.InProcess.NoEmit;

    public sealed class Runtimes : ManualConfig
    {
        public Runtimes() => AddJob(Job.Default.WithToolchain(InProcessNoEmitToolchain.Instance));
    }
}
