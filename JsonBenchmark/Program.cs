﻿using BenchmarkDotNet.Running;

namespace JsonBenchmark
{
    class Program
    {
        static void Main(string[] args) 
        {
            //BenchmarkRunner.Run<JsonSerializersBenchmarks>();
            BenchmarkRunner.Run<JsonDeserializersBenchmarks>();
        }
    }
}
