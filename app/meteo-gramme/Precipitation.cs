using System.Collections.Generic;

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