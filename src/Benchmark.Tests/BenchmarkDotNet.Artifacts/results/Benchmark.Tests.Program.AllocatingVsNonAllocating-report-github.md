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
|        Method |                  Job |              Runtime |     Mean |   Error |  StdDev | Ratio | RatioSD |  Gen 0 | Allocated |
|-------------- |--------------------- |--------------------- |---------:|--------:|--------:|------:|--------:|-------:|----------:|
|    Allocating |             .NET 5.0 |             .NET 5.0 | 401.9 ns | 2.39 ns | 2.00 ns |  1.00 |    0.00 | 0.0782 |     328 B |
| NonAllocating |             .NET 5.0 |             .NET 5.0 | 398.3 ns | 2.03 ns | 1.80 ns |  0.99 |    0.01 | 0.0629 |     264 B |
|               |                      |                      |          |         |         |       |         |        |           |
|    Allocating |             .NET 6.0 |             .NET 6.0 | 302.2 ns | 3.11 ns | 2.91 ns |  1.00 |    0.00 | 0.0782 |     328 B |
| NonAllocating |             .NET 6.0 |             .NET 6.0 | 299.2 ns | 5.86 ns | 6.27 ns |  0.99 |    0.03 | 0.0629 |     264 B |
|               |                      |                      |          |         |         |       |         |        |           |
|    Allocating |        .NET Core 3.1 |        .NET Core 3.1 | 490.8 ns | 3.60 ns | 3.01 ns |  1.00 |    0.00 | 0.0782 |     328 B |
| NonAllocating |        .NET Core 3.1 |        .NET Core 3.1 | 490.2 ns | 3.17 ns | 2.65 ns |  1.00 |    0.01 | 0.0629 |     264 B |
|               |                      |                      |          |         |         |       |         |        |           |
|    Allocating | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 521.2 ns | 4.38 ns | 3.42 ns |  1.00 |    0.00 | 0.0839 |     353 B |
| NonAllocating | .NET Framework 4.6.1 | .NET Framework 4.6.1 | 516.7 ns | 3.61 ns | 3.01 ns |  0.99 |    0.01 | 0.0687 |     289 B |
|               |                      |                      |          |         |         |       |         |        |           |
|    Allocating | .NET Framework 4.6.2 | .NET Framework 4.6.2 | 515.3 ns | 6.61 ns | 6.19 ns |  1.00 |    0.00 | 0.0839 |     353 B |
| NonAllocating | .NET Framework 4.6.2 | .NET Framework 4.6.2 | 514.3 ns | 3.02 ns | 2.52 ns |  1.00 |    0.01 | 0.0687 |     289 B |
|               |                      |                      |          |         |         |       |         |        |           |
|    Allocating |   .NET Framework 4.7 |   .NET Framework 4.7 | 515.3 ns | 1.28 ns | 1.00 ns |  1.00 |    0.00 | 0.0839 |     353 B |
| NonAllocating |   .NET Framework 4.7 |   .NET Framework 4.7 | 513.7 ns | 1.82 ns | 1.42 ns |  1.00 |    0.00 | 0.0687 |     289 B |
|               |                      |                      |          |         |         |       |         |        |           |
|    Allocating | .NET Framework 4.7.1 | .NET Framework 4.7.1 | 520.1 ns | 5.52 ns | 4.89 ns |  1.00 |    0.00 | 0.0839 |     353 B |
| NonAllocating | .NET Framework 4.7.1 | .NET Framework 4.7.1 | 516.8 ns | 4.68 ns | 3.90 ns |  0.99 |    0.01 | 0.0687 |     289 B |
|               |                      |                      |          |         |         |       |         |        |           |
|    Allocating | .NET Framework 4.7.2 | .NET Framework 4.7.2 | 522.2 ns | 9.93 ns | 8.29 ns |  1.00 |    0.00 | 0.0839 |     353 B |
| NonAllocating | .NET Framework 4.7.2 | .NET Framework 4.7.2 | 517.6 ns | 1.60 ns | 1.34 ns |  0.99 |    0.01 | 0.0687 |     289 B |
|               |                      |                      |          |         |         |       |         |        |           |
|    Allocating |   .NET Framework 4.8 |   .NET Framework 4.8 | 522.9 ns | 1.33 ns | 1.11 ns |  1.00 |    0.00 | 0.0839 |     353 B |
| NonAllocating |   .NET Framework 4.8 |   .NET Framework 4.8 | 516.7 ns | 0.86 ns | 0.67 ns |  0.99 |    0.00 | 0.0687 |     289 B |
