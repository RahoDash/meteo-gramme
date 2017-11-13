using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meteo_gramme
{
    public class Temperature
    {
        public List<decimal> TempMin { get; set; }
        public List<decimal> TempMax { get; set; }
        public List<decimal> Temp { get; set; }

        public Temperature()
        {
            Temp = new List<decimal>();
            TempMax = new List<decimal>();
            TempMin = new List<decimal>();
        }
    }
}