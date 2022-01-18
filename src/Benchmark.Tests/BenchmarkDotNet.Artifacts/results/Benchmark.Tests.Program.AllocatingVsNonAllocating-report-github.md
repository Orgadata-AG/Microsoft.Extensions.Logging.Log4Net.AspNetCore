``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i7-8559U CPU 2.70GHz (Coffee Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.101
  [Host]               : .NET Core 3.1.22 (CoreCLR 4.700.21.56803, CoreFX 4.700.21.57101), X64 RyuJIT
  .NET 5.0             : .NET 5.0.13 (5.0.1321.56516), X64 RyuJIT
  .NET 6.0             : .NET 6.0.1 (6.0.121.56705), X64 RyuJIT
  .NET Core 3.1        : .NET Core 3.1.22 (CoreCLR 4.700.21.56803, CoreFX 4.700.21.57101), X64 RyuJIT
  .NET Framework 4.6.1 : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  .NET Framework 4.6.2 : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  .NET Framework 4.7   : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  .NET Framework 4.7.1 : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  .NET Framework 4.7.2 : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT
  .NET Framework 4.8   : .NET Framework 4.8 (4.8.4420.0), X64 RyuJIT


```
|                      Method |                  Job |              Runtime |     Mean |    Error |  StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|---------------------------- |--------------------- |--------------------- |---------:|---------:|--------:|------:|--------:|-------:|----------:|
| NormalCallStackBoundaryType |             .NET 5.0 |             .NET 5.0 | 395.7 ns |  4.46 ns | 3.95 ns |  1.00 |    0.00 | 0.0629 |     264 B |
| CachedCallStackBoundaryType |             .NET 5.0 |             .NET 5.0 | 402.0 ns |  3.72 ns | 3.30 ns |  1.02 |    0.01 | 0.0629 |     264 B |
|                             |                      |                      |          |          |         |       |         |        |           |
| NormalCallStackBoundaryType |             .NET 6.0 |             .NET 6.0 | 294.4 ns |  1.90 ns | 1.77 ns |  1.00 |    0.00 | 0.0629 |     264 B |
| CachedCallStackBoundaryType |             .NET 6.0 |             .NET 6.0 | 291.4 ns |  3.32 ns | 2.59 ns |  0.99 |    0.01 | 0.0629 |     264 B |
|                             |                      |                      |          |          |         |       |         |        |           |
| NormalCallStackBoundaryType |        .NET Core 3.1 |        .NET Core 3.1 | 513.5 ns |  5.74 ns | 5.37 ns |  1.00 |    0.00 | 0.0629 |     264 B |
| CachedCallStackBoundaryType |        .NET Core 3.1 |        .NET Core 3.1 | 498.3 ns |  4.95 ns | 3.86 ns |  0.97 |    0.01 | 0.0629 |     264 B |
|                             |                      |                      |          |          |         |       |         |        |           |
| NormalCallStackBoundaryType | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 526.5 ns |  8.59 ns | 8.03 ns |  1.00 |    0.00 | 0.0687 |     289 B |
| CachedCallStackBoundaryType | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 533.9 ns |  5.93 ns | 5.26 ns |  1.01 |    0.02 | 0.0687 |     289 B |
|                             |                      |                      |          |          |         |       |         |        |           |
| NormalCallStackBoundaryType | .NET Framework 4.6.2 | .NET Framework 4.6.2 | 527.8 ns |  7.99 ns | 7.09 ns |  1.00 |    0.00 | 0.0687 |     289 B |
| CachedCallStackBoundaryType | .NET Framework 4.6.2 | .NET Framework 4.6.2 | 529.5 ns |  5.08 ns | 4.51 ns |  1.00 |    0.02 | 0.0687 |     289 B |
|                             |                      |                      |          |          |         |       |         |        |           |
| NormalCallStackBoundaryType |   .NET Framework 4.7 |   .NET Framework 4.7 | 531.4 ns |  6.13 ns | 5.74 ns |  1.00 |    0.00 | 0.0687 |     289 B |
| CachedCallStackBoundaryType |   .NET Framework 4.7 |   .NET Framework 4.7 | 531.4 ns |  4.63 ns | 4.10 ns |  1.00 |    0.01 | 0.0687 |     289 B |
|                             |                      |                      |          |          |         |       |         |        |           |
| NormalCallStackBoundaryType | .NET Framework 4.7.1 | .NET Framework 4.7.1 | 522.4 ns |  5.03 ns | 4.46 ns |  1.00 |    0.00 | 0.0687 |     289 B |
| CachedCallStackBoundaryType | .NET Framework 4.7.1 | .NET Framework 4.7.1 | 527.6 ns |  8.42 ns | 7.88 ns |  1.01 |    0.02 | 0.0687 |     289 B |
|                             |                      |                      |          |          |         |       |         |        |           |
| NormalCallStackBoundaryType | .NET Framework 4.7.2 | .NET Framework 4.7.2 | 523.1 ns |  4.22 ns | 3.74 ns |  1.00 |    0.00 | 0.0687 |     289 B |
| CachedCallStackBoundaryType | .NET Framework 4.7.2 | .NET Framework 4.7.2 | 523.5 ns |  8.39 ns | 7.85 ns |  1.00 |    0.02 | 0.0687 |     289 B |
|                             |                      |                      |          |          |         |       |         |        |           |
| NormalCallStackBoundaryType |   .NET Framework 4.8 |   .NET Framework 4.8 | 531.0 ns | 10.19 ns | 9.53 ns |  1.00 |    0.00 | 0.0687 |     289 B |
| CachedCallStackBoundaryType |   .NET Framework 4.8 |   .NET Framework 4.8 | 524.4 ns |  7.76 ns | 6.88 ns |  0.99 |    0.02 | 0.0687 |     289 B |
