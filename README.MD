```

BenchmarkDotNet v0.13.6, macOS Ventura 13.4 (22F66) [Darwin 22.5.0]
Apple M1 Pro, 1 CPU, 10 logical and 10 physical cores
.NET SDK 7.0.304
  [Host] : .NET 7.0.7 (7.0.723.27404), Arm64 RyuJIT AdvSIMD

Toolchain=InProcessEmitToolchain  

```

## Array Benchmarks

|                                      Method |        Mean |   Error |  StdDev | Ratio | RatioSD | Allocated | Alloc Ratio |
|-------------------------------------------- |------------:|--------:|--------:|------:|--------:|----------:|------------:|
|             LinqSequenceEqualArrayBenchmark |    121.4 ns | 0.13 ns | 0.25 ns |  1.00 |    0.00 |         - |          NA |
| GenericIndexableSequenceEqualArrayBenchmark |    474.6 ns | 0.11 ns | 0.10 ns |  3.91 |    0.00 |         - |          NA |
|  StructIndexableSequenceEqualArrayBenchmark |    474.5 ns | 0.12 ns | 0.11 ns |  3.91 |    0.00 |         - |          NA |
|        IndexableSequenceEqualArrayBenchmark |    475.4 ns | 0.12 ns | 0.11 ns |  3.92 |    0.00 |         - |          NA |
| IndexableSequenceEqualDefaultArrayBenchmark |    475.3 ns | 0.09 ns | 0.08 ns |  3.92 |    0.00 |         - |          NA |
|  IndexableSequenceEqualObjectArrayBenchmark | 11,554.9 ns | 7.62 ns | 7.13 ns | 95.28 |    0.09 |         - |          NA |
|              ForSequenceEqualArrayBenchmark |    324.7 ns | 0.15 ns | 0.13 ns |  2.68 |    0.00 |         - |          NA |

## Array Sum Benchmarks

|                                       Method |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |   Gen0 | Allocated | Alloc Ratio |
|--------------------------------------------- |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|----------:|------------:|
|                        LinqSumArrayBenchmark |   325.3 ns |  0.21 ns |  0.20 ns |   325.3 ns |  1.00 |    0.00 |      - |         - |          NA |
|                   AggregateSumArrayBenchmark | 3,450.3 ns |  3.14 ns |  2.62 ns | 3,449.9 ns | 10.61 |    0.01 | 0.0038 |      32 B |          NA |
|                         ForSumArrayBenchmark |   584.2 ns |  0.36 ns |  0.30 ns |   584.4 ns |  1.80 |    0.00 |      - |         - |          NA |
|                     GenericSumArrayBenchmark |   324.2 ns |  0.18 ns |  0.14 ns |   324.2 ns |  1.00 |    0.00 | 0.0038 |      24 B |          NA |
|                    Generic2SumArrayBenchmark |   320.7 ns |  0.13 ns |  0.12 ns |   320.7 ns |  0.99 |    0.00 |      - |         - |          NA |
|                    Generic3SumArrayBenchmark |   320.7 ns |  0.25 ns |  0.23 ns |   320.7 ns |  0.99 |    0.00 |      - |         - |          NA |
|                    Generic4SumArrayBenchmark |   320.5 ns |  0.65 ns |  0.58 ns |   320.6 ns |  0.99 |    0.00 |      - |         - |          NA |
|                    Generic5SumArrayBenchmark |   320.9 ns |  0.38 ns |  0.30 ns |   320.9 ns |  0.99 |    0.00 |      - |         - |          NA |
|              GenericCheckedSumArrayBenchmark |   323.8 ns |  2.56 ns |  2.27 ns |   322.6 ns |  1.00 |    0.01 |      - |         - |          NA |
|                 GenericLongSumArrayBenchmark |   588.5 ns |  6.77 ns |  6.33 ns |   586.2 ns |  1.81 |    0.02 |      - |         - |          NA |
|            GenericIndexableSumArrayBenchmark |   583.2 ns |  1.01 ns |  0.94 ns |   582.9 ns |  1.79 |    0.00 |      - |         - |          NA |
|           Generic2IndexableSumArrayBenchmark |   584.2 ns |  0.43 ns |  0.40 ns |   584.2 ns |  1.80 |    0.00 |      - |         - |          NA |
|    Generic2IndexableDefaultSumArrayBenchmark | 1,429.6 ns | 28.24 ns | 33.61 ns | 1,400.5 ns |  4.36 |    0.10 |      - |         - |          NA |
|          Generic2EnumerableSumArrayBenchmark |   594.6 ns |  0.42 ns |  0.39 ns |   594.7 ns |  1.83 |    0.00 |      - |         - |          NA |
|         Generic2EnumerableSumMemoryBenchmark | 1,486.4 ns |  1.43 ns |  1.34 ns | 1,486.6 ns |  4.57 |    0.01 |      - |         - |          NA |
|      Generic2EnumerableFoldSumArrayBenchmark |   594.7 ns |  0.49 ns |  0.45 ns |   594.8 ns |  1.83 |    0.00 |      - |         - |          NA |
|               EnumerableIntSumArrayBenchmark | 2,825.4 ns |  3.24 ns |  2.71 ns | 2,824.6 ns |  8.69 |    0.01 | 0.0038 |      32 B |          NA |
|                     ForEachSumArrayBenchmark |   611.4 ns |  0.46 ns |  0.40 ns |   611.5 ns |  1.88 |    0.00 |      - |         - |          NA |
|                 ForEachSpanSumArrayBenchmark |   321.2 ns |  0.37 ns |  0.33 ns |   321.2 ns |  0.99 |    0.00 |      - |         - |          NA |
|       ForEachSpanEnumerableSumArrayBenchmark |   849.9 ns |  0.41 ns |  0.34 ns |   850.0 ns |  2.61 |    0.00 |      - |         - |          NA |
|              SpanEnumerableSumArrayBenchmark |   718.8 ns |  0.37 ns |  0.35 ns |   718.8 ns |  2.21 |    0.00 |      - |         - |          NA |
|       GenericIEnumerableIntSumArrayBenchmark | 2,527.2 ns | 12.32 ns | 11.52 ns | 2,521.7 ns |  7.77 |    0.04 | 0.0038 |      32 B |          NA |
|        GenericEnumerableIntSumArrayBenchmark |   408.2 ns |  0.25 ns |  0.22 ns |   408.1 ns |  1.25 |    0.00 |      - |         - |          NA |
| GenericEnumerableIntCheckedSumArrayBenchmark |   332.5 ns |  0.19 ns |  0.17 ns |   332.6 ns |  1.02 |    0.00 |      - |         - |          NA |
|           GenericEnumerableSumArrayBenchmark |   397.0 ns |  0.33 ns |  0.30 ns |   397.2 ns |  1.22 |    0.00 |      - |         - |          NA |
|     GenericEnumerableSelectSumArrayBenchmark | 3,851.4 ns | 21.17 ns | 19.80 ns | 3,841.2 ns | 11.84 |    0.06 | 0.0076 |      48 B |          NA |
|    Generic2EnumerableSelectSumArrayBenchmark | 5,275.4 ns |  5.77 ns |  4.82 ns | 5,275.5 ns | 16.22 |    0.02 |      - |         - |          NA |
|    Generic3EnumerableSelectSumArrayBenchmark | 1,570.9 ns |  1.87 ns |  1.56 ns | 1,571.4 ns |  4.83 |    0.01 |      - |         - |          NA |

## List Benchmarks

|                            Method |     Mean |    Error |  StdDev | Ratio | RatioSD |
|---------------------------------- |---------:|---------:|--------:|------:|--------:|
|                  SumListBenchmark | 327.4 ns |  2.58 ns | 2.42 ns |  1.00 |    0.00 |
|           ForEachSumListBenchmark | 951.4 ns | 10.30 ns | 9.63 ns |  2.91 |    0.05 |
|               ForSumListBenchmark | 475.5 ns |  0.30 ns | 0.25 ns |  1.46 |    0.01 |
|  GenericIndexableSumListBenchmark | 475.5 ns |  0.31 ns | 0.29 ns |  1.45 |    0.01 |
| GenericEnumerableSumListBenchmark | 940.7 ns |  0.39 ns | 0.35 ns |  2.88 |    0.02 |

## Not Null Benchmarks

|                 Method | ActionCount | CheckCount |     Mean |     Error |    StdDev | Ratio | Allocated | Alloc Ratio |
|----------------------- |------------ |----------- |---------:|----------:|----------:|------:|----------:|------------:|
|     CheckNullBenchmark |       10000 |         30 | 1.375 ms | 0.0008 ms | 0.0006 ms |  1.00 |       4 B |        1.00 |
| EnsureNotNullBenchmark |       10000 |         30 | 1.372 ms | 0.0008 ms | 0.0008 ms |  1.00 |       4 B |        1.00 |
|  CannotBeNullBenchmark |       10000 |         30 | 1.373 ms | 0.0025 ms | 0.0022 ms |  1.00 |       4 B |        1.00 |