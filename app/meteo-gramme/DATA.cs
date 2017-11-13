using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace meteo_gramme
{
    public class DATA
    {

        // This will be the url to access the data we need.
        private const string DEFAULT_URL = "http://api.met.no/weatherapi/locationforecast/1.9/?";
        private const decimal DEFAULT_LAT = 46.2043907M;
        private const decimal DEFAULT_LON = 6.1431577M;

        // Declaration of fields
        private decimal _latitude;
        private decimal _longitude;
        public Temperature Temperature;
        public Precipitation Precipitation;



        private int CountIterration;
        private DateTime oldDateTime;
        private DateTime StateDateTime;
        //private DateTime StateDate;

        /// <summary>
        /// Encapsulation of fields
        /// </summary>
        public decimal Latitude { get => _latitude; set
            {
                if (value < 1)
                {
                    _latitude = DEFAULT_LAT;
                }
                else
                {
                    _latitude = value;
                }
            }
        }
        public decimal Longitude
        {
            get => _longitude; set
            {
                if (value < 1)
                {
                    _longitude = DEFAULT_LON;
                }
                else
                {
                    _longitude = value;
                }
            }
        }
        public string Url { get => DEFAULT_URL + "lat=" + Latitude.ToString() + ";lon=" + Longitude.ToString(); }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="lat">This will be the latitude of the location in string</param>
        /// <param name="lon">This will be the longitude of the location in string</param>
        public DATA(decimal lat, decimal lon, DateTime dateTime)
        {
            Latitude = lat;
            Longitude = lon;
            this.Temperature = new Temperature();
            this.Precipitation = new Precipitation();
            ExtractData(dateTime);
        }

        /// <summary>
        /// Will read the xml file and extract the data and put them in the differente classes
        /// </summary>
        public void ExtractData(DateTime dateTime)
        {
            CountIterration = 0;
            int days = 1;
            StateDateTime = dateTime.Date;
            if (CanRequest(Url))
            {
                try
                {
                    //string attribute = "";           
                    using (XmlReader reader = XmlReader.Create(Url))
                    {
                        while (reader.Read())
                        {
                            switch (reader.Name)
                            {
                                case "model":

                                    //InitDateTime = Convert.ToDateTime(reader)
                                    //InitDateTime = reader.MoveToAttribute("from") ? ConvertToDateTime(reader.Value) : DateTime.Now;
                                    break;
                                case "time":
                                    if (reader.MoveToAttribute("to"))
                                    {
                                        if (StateDateTime < ConvertToDate(reader.Value))
                                        {
                                            reader.Dispose();   
                                        }
                                        else
                                        {
                                            if ((CountIterration >= 4) || (days > 4))
                                            {
                                                CountIterration = 0;
                                            }
                                            CountIterration++;
                                            
                                            if (oldDateTime == DateTime.MinValue)
                                            {
                                                oldDateTime = ConvertToDate(reader.Value);
                                            }

                                            if (oldDateTime.AddHours(1) != ConvertToDate(reader.Value).AddHours(1))
                                            {
                                                this.Temperature = new Temperature();
                                                this.Precipitation = new Precipitation();
                                                oldDateTime = ConvertToDate(reader.Value);
                                                CountIterration = 0;
                                                days++;
                                            }

                                        }

                                        //else
                                        //{
                                        //    indexIterration++;
                                        //    this.Precipitation[StateDateTime] = new Precipitation(); 
                                        //}
                                    }
                                    break;
                                case "temperature":
                                    if (reader.MoveToAttribute("value"))
                                        Temperature.Temp.Add(Convert.ToDecimal(reader.Value));
                                    break;
                                case "precipitation":
                                    if (reader.MoveToAttribute("value") && (CountIterration == 1)) {
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
                    throw;
                }
            }
        }

        public DateTime ConvertToDateTime(string date)
        {
            DateTime d;
            date = date.Replace('T',' ');
            date = date.Remove(date.Length-1);
            d = Convert.ToDateTime(date) ;
            return d;
        }
        public DateTime ConvertToDate(string date)
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
    }
}