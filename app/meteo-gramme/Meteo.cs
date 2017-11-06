using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meteo_gramme
{
    class Meteo
    {
        Temperature temperature;
        Precipitation precipitation;
        DATA data;

        public Meteo(string lat, string lon)
        {
            data = new DATA(lat, lon);
            temperature = new Temperature();
            precipitation = new Precipitation();
        }


    }
}