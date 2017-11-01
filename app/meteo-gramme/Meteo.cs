using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meteo_gramme
{
    class Meteo
    {
        private string _from;
        private string _to;
        private string _latitude;
        private string _longitude;

        //private string[,] details = 



        public Meteo(string form, string to, string lat, string lon)
        {
            DATA download = new DATA(lat, lon);

            throw new System.NotImplementedException();
        }

        public string From { get => _from; set => _from = value; }
        public string To { get => _to; set => _to = value; }
        public string Latitude { get => _latitude; set => _latitude = value; }
        public string Longitude { get => _longitude; set => _longitude = value; }
    }
}