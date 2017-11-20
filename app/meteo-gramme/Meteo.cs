using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace meteo_gramme
{
    public class Meteo
    {

        #region Constant
        private const decimal DEFAULT_LAT = 46.2043907M;
        private const decimal DEFAULT_LON = 6.1431577M;
        private const decimal DEFAULT_ALT = 375M;
        #endregion

        #region Fields
        Temperature _temperature;
        Precipitation _precipitation;
        #endregion

        #region Variables
        DATA data;
        #endregion

        #region Properties
        internal Temperature Temperature { get => _temperature; set => _temperature = value; }
        internal Precipitation Precipitation { get => _precipitation; set => _precipitation = value; }
        #endregion

        #region Constructors
        public Meteo() : this(DEFAULT_LAT, DEFAULT_LON, DEFAULT_ALT, DateTime.Now) { }
        public Meteo(decimal lat, decimal lon, decimal alt, DateTime dateTime)
        {
            try
            {
                data = new DATA(Convert.ToDecimal(lat), Convert.ToDecimal(lon), Convert.ToDecimal(alt), dateTime);
            }
            catch (Exception)
            {
                MessageBox.Show("Les données ne sont pas valides");
            }
            this.Temperature = data.Temperature;
            this.Precipitation = data.Precipitation;
        }
        #endregion

        #region Methods
        public List<decimal> GetFirstDay(DateTime d)
        {
            List<decimal> result = new List<decimal>();

            string date = ConvertDateToKey(d);

            return result;
        }

        public string ConvertDateToKey(DateTime d)
        {
            string date = d.ToString("yyyy-MM-dd" + "T" + "HH:00:00" + "Z");
            return date;
        } 
        #endregion
    }
}