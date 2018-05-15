using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Columns;
using BenchmarkDotNet.Attributes.Exporters;
using BenchmarkDotNet.Attributes.Jobs;
using JsonBenchmark.TestDTOs;
using Newtonsoft.Json;
using System;
using System.IO;

namespace JsonBenchmark
{
    [ClrJob(isBaseline: true)]
    [RPlotExporter, RankColumn]
    [HtmlExporter]
    public class JsonDeserializersBenchmarks : JsonBenchmarkBase
    {
        [Benchmark]
        public ChuckRoot NewtonsoftJson_DeserializeChuck()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(AppContext.BaseDirectory, "TestFiles", "chucknorris.json")))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<ChuckRoot>(reader);
                // return JsonConvert.DeserializeObject<ChuckRoot>(JsonSampleStringChuck);
            }
        }

        [Benchmark]
        public RytmusRoot NewtonsoftJson_DeserializeRytmus()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(AppContext.BaseDirectory, "TestFiles", "rytmus.json")))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                JsonSerializer serializer = new JsonSerializer();
                return serializer.Deserialize<RytmusRoot>(reader);
                // return JsonConvert.DeserializeObject<RytmusRoot>(JsonSampleStringRytmus);
            }
        }

        [Benchmark]
        public ChuckRoot Utf8Json_DeserializeChuck()
        {
            return Utf8Json.JsonSerializer.Deserialize<ChuckRoot>(JsonSampleStringChuck);
        }

        [Benchmark]
        public RytmusRoot Utf8Json_DeserializeRytmus()
        {
            return Utf8Json.JsonSerializer.Deserialize<RytmusRoot>(JsonSampleStringRytmus);
        }
    }
}
