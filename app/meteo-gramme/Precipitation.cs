/*
 * Ruben Carvalho et Besmir Silka 
 * CFPT - T.IS-E2A
 * 20.11.2017
 * POO v4.0 - meteo-gramme
 * Contains the precipitations
 */
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