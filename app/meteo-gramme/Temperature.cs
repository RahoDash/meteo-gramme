using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meteo_gramme
{
    class Temperature
    {
        public Dictionary<string, string> TempMin { get; set; }
        public Dictionary<string, string> TempMax { get; set; }
        public Dictionary<string, string> Temp { get; set; }

        public Temperature()
        {
            Temp = new Dictionary<string, string>();
            TempMax = new Dictionary<string, string>();
            TempMin = new Dictionary<string, string>();
        }
    }
}