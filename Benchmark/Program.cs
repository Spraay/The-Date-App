﻿// Program.cs

using BenchmarkDotNet.Running;

namespace Benchmarks
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<ExploreControllerResponseBenchmark>();
        }
    }
}