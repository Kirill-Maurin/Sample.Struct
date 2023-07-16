using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.InProcess;
using BenchmarkDotNet.Toolchains.InProcess.Emit;

namespace Sample.Struct.Benchmarks;

public sealed class Runtimes : ManualConfig
{
    public Runtimes() => AddJob(Job.Default.WithToolchain(InProcessEmitToolchain.Instance));
}