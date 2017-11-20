/*
 * Ruben Carvalho et Besmir Silka 
 * CFPT - T.IS-E2A
 * 20.11.2017
 * POO v4.0 - meteo-gramme
 * Extract the data of the site http://api.met.no/weatherapi/
 */
using System;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace meteo_gramme
{
    public class Extractor
    {

        #region Const
        // This will be the url to access the data we need.
        private const string DEFAULT_URL = "http://api.met.no/weatherapi/locationforecast/1.9/?";
        private const int NUMBER_PRECIPITATION_FOR_ONE_HOUR = 4;
        private const int NONE_DETAILED_DAY = 4;
        public const decimal DEFAULT_LAT = 46.2043907M;
        public const decimal DEFAULT_LON = 6.1431577M;
        public const decimal DEFAULT_ALT = 375M;
        #endregion

        #region Fields
        // Declaration of fields
        private decimal _latitude;
        private decimal _longitude;
        private decimal _altitude;
        public Temperature Temperature;
        public Precipitation Precipitation;
        private int IterrationOfPrecipitation;
        private DateTime oldDateTime;
        private DateTime StateDateTime;
        #endregion

        #region Properties
        public decimal Latitude { get => _latitude; set => _latitude = value; }
        public decimal Longitude { get => _longitude; set => _longitude = value; }
        public decimal Altitude { get => _altitude; set => _altitude = value; }
        public string Url { get => DEFAULT_URL + "lat=" + Latitude.ToString() + ";lon=" + Longitude.ToString() + "&msl=" + Altitude.ToString(); }
        #endregion

        #region Constructor
        public Extractor() : this(DEFAULT_LAT, DEFAULT_LON, DEFAULT_ALT, DateTime.Now)
        {
        }
        /// <summary>
        /// constructor designated
        /// </summary>
        /// <param name="lat">This will be the latitude of the location in string</param>
        /// <param name="lon">This will be the longitude of the location in string</param>
        public Extractor(decimal lat, decimal lon, decimal alt, DateTime dateTime)
        {
            this.Latitude = lat;
            this.Longitude = lon;
            this.Altitude = alt;
            this.Temperature = new Temperature();
            this.Precipitation = new Precipitation();
            ExtractData(dateTime);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Convert into date the day of the XML date format
        /// </summary>
        /// <param name="date">XML date from api.met.no</param>
        /// <returns>datetime</returns>
        private DateTime ConvertToDate(string date)
        {
            DateTime d;
            date = date.Remove(10);
            d = Convert.ToDateTime(date);
            return d;
        }

        /// <summary>
        /// Will test if the url is reponding
        /// </summary>
        /// <param name="url"></param>
        private bool CanRequest(string url)
        {
            bool result = false;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                MessageBox.Show("Aucune donnée pour la latitude : " + Latitude.ToString() + ", la longitude : " + Longitude.ToString() + " et pour l'altitude" + Altitude.ToString());
                result = false;
                return result;
            }

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
            if ((response.StatusCode == HttpStatusCode.OK))
            {
                result = true;
            }
            response.Dispose();
            return result;
        }

        /// <summary>
        /// Will read the xml file and extract the data and put them in the differente classes
        /// </summary>
        private void ExtractData(DateTime dateTime)
        {
            int daysIterration = 1;

            IterrationOfPrecipitation = 0;
            StateDateTime = dateTime.Date;

            if (CanRequest(Url))
            {
                try
                {
                    using (XmlReader reader = XmlReader.Create(Url))
                    {
                        while (reader.Read())
                        {
                            switch (reader.Name)
                            {
                                case "time":
                                    if (reader.MoveToAttribute("to"))
                                    {
                                        //Dispose de reader if the date is 
                                        if (StateDateTime < ConvertToDate(reader.Value))
                                        {
                                            reader.Dispose();
                                        }
                                        else
                                        {
                                            //Restart the counter of precipitation value
                                            //when we go after NUMBER_PRECIPITATION_FOR_ONE_HOUR
                                            //or we passed the fourth day
                                            if ((IterrationOfPrecipitation >= NUMBER_PRECIPITATION_FOR_ONE_HOUR) || (daysIterration > NONE_DETAILED_DAY))
                                            {
                                                IterrationOfPrecipitation = 0;
                                            }
                                            IterrationOfPrecipitation++;

                                            //init the date of the current reader date
                                            if (oldDateTime == DateTime.MinValue)
                                            {
                                                oldDateTime = ConvertToDate(reader.Value);
                                            }

                                            //We init the values because we changed day
                                            if (oldDateTime != ConvertToDate(reader.Value))
                                            {
                                                oldDateTime = ConvertToDate(reader.Value);
                                                this.Temperature = new Temperature();
                                                this.Precipitation = new Precipitation();
                                                IterrationOfPrecipitation = 0;
                                                daysIterration++;
                                            }
                                        }
                                    }
                                    break;
                                case "temperature":
                                    if (reader.MoveToAttribute("value"))
                                        Temperature.Temp.Add(Convert.ToDecimal(reader.Value));
                                    break;
                                case "precipitation":
                                    if (reader.MoveToAttribute("value") && (IterrationOfPrecipitation == 1))
                                    {
                                        Precipitation.Value.Add(Convert.ToDecimal(reader.Value));
                                    }
                                    break;
                                case "minTemperature":
                                    if (reader.MoveToAttribute("value"))
                                        Temperature.TempMin.Add(Convert.ToDecimal(reader.Value));
                                    break;
                                case "maxTemperature":
                                    if (reader.MoveToAttribute("value"))
                                        Temperature.TempMax.Add(Convert.ToDecimal(reader.Value));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    throw new Exception("Erreur lors de l'extraction");
                }
            }
        } 
        #endregion
    }
}