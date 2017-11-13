using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meteo_gramme
{
    public class Meteo
    {
        Temperature _temperature;
        Precipitation _precipitation;

        private const string DEFAULT_LAT = "46.2043907";
        private const string DEFAULT_LON = "6.1431577";

        DATA data;
   
        internal Temperature Temperature { get => _temperature; set => _temperature = value; }
        internal Precipitation Precipitation { get => _precipitation; set => _precipitation = value; }


        public Meteo(): this(DEFAULT_LAT,DEFAULT_LON , DateTime.Now){ }
        public Meteo(string lat, string lon, DateTime dateTime)
        {
            data = new DATA(Convert.ToDecimal(lat), Convert.ToDecimal(lon), dateTime);
            this.Temperature = data.Temperature;
            this.Precipitation = data.Precipitation;
        }

        public List<decimal> GetFirstDay(DateTime d)
        {
            List<decimal> result = new List<decimal>();

            string date = ConvertDateToKey(d);

            //foreach (string value in this.Temperature.Temp[])
            //{
            //    if ()
            //    {

            //    }
            //    if (d.Day == DateTime.Now.Day)
            //    {
            //        result.Add(Convert.ToDecimal(value));
            //    }
            //}

            return result;
        }

        public string ConvertDateToKey(DateTime d)
        {
            string date = d.ToString("yyyy-MM-dd" + "T" + "HH:00:00" + "Z");
            return date;
        }

        public string AddHoursInDate(DateTime d, int hours)
        {
            d = d.AddHours(hours);
            string date = d.ToString("yyyy-MM-dd" + "T" + "HH:00:00" + "Z");
            return date;
        }
    }
}