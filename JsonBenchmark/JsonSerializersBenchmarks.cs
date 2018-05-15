using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonSerializersBenchmarks : JsonBenchmarkBase
    {

        private ChuckRoot chuckRoot;
        private RytmusRoot rytmusRoot;
        
        [GlobalSetup]
        public void GlobalSetup()
        {
            chuckRoot = JsonConvert.DeserializeObject<ChuckRoot>(JsonSampleStringChuck);
            rytmusRoot = JsonConvert.DeserializeObject<RytmusRoot>(JsonSampleStringRytmus);
        }
        [Benchmark]
        public string NewtonsoftJson_SerializeChuck()
        {
             return JsonConvert.SerializeObject(chuckRoot);
        }

        [Benchmark]
        public string NewtonSoftJson_SerializeRytmus()
        {
            return JsonConvert.SerializeObject(rytmusRoot);
        }

        [Benchmark]
        public byte[] Utf8Json_SerializeChuck()
        {
            return Utf8Json.JsonSerializer.Serialize(chuckRoot);
        }

        [Benchmark]
        public byte[] Utf8Json_SerializeRytmus()
        {
            return Utf8Json.JsonSerializer.Serialize(rytmusRoot);
        }
    }
}