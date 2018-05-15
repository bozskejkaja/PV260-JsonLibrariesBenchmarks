using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonBenchmark.TestDTOs
{
    public class RytmusRoot
    {
        public int total { get; set; }
        public RytmusResult[] result { get; set; }
    }
}
