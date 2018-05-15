using System;
using System.IO;

namespace JsonBenchmark
{
    public abstract class JsonBenchmarkBase
    {
        private const string TestFilesFolder = "TestFiles";
        protected string JsonSampleStringChuck;
        protected string JsonSampleStringRytmus;

        protected JsonBenchmarkBase()
        {
            JsonSampleStringChuck = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "chucknorris.json"));
            JsonSampleStringRytmus = File.ReadAllText(Path.Combine(AppContext.BaseDirectory, TestFilesFolder, "rytmus.json"));
        }
    }
}
