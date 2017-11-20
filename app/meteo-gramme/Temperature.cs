/*
 * Ruben Carvalho et Besmir Silka 
 * CFPT - T.IS-E2A
 * 20.11.2017
 * POO v4.0 - meteo-gramme
 * Contains the temperatures
 */
using System.Collections.Generic;

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