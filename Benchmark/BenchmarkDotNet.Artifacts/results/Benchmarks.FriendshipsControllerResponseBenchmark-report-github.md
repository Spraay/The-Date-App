``` ini

BenchmarkDotNet=v0.11.3, OS=Windows 10.0.17763.1 (1809/October2018Update/Redstone5)
Intel Core i5-4670K CPU 3.40GHz (Haswell), 1 CPU, 4 logical and 4 physical cores
.NET Core SDK=2.2.101
  [Host] : .NET Core 2.2.0 (CoreCLR 4.6.27110.04, CoreFX 4.6.27110.04), 64bit RyuJIT

Job=InProcess  Toolchain=InProcessToolchain  

```
|          Method |     Mean |    Error |   StdDev |   Median | Gen 0/1k Op | Gen 1/1k Op | Gen 2/1k Op | Allocated Memory/Op |
|---------------- |---------:|---------:|---------:|---------:|------------:|------------:|------------:|--------------------:|
| GetResponseTime | 49.50 us | 1.856 us | 5.474 us | 51.38 us |      0.1831 |           - |           - |             6.05 KB |
