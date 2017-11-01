using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meteo_gramme
{
    class Precipitation
    {
        public Dictionary<string, string> Number { get; set; }
        public Dictionary<string, string> Value { get; set; }

        public Precipitation()
        {
            Number = new Dictionary<string, string>();
            Value = new Dictionary<string, string>();
        }
    }
}