using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meteo_gramme
{
    public class Precipitation
    {
        public List<decimal> Value { get; set; }

        public Precipitation()
        {
            Value = new List<decimal>();
        }
    }
}