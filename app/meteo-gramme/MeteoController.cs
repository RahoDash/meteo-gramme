/*
 * Ruben Carvalho et Besmir Silka 
 * CFPT - T.IS-E2A
 * 20.11.2017
 * POO v4.0 - meteo-gramme
 * Create the meteogram for the view
 */
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace meteo_gramme
{
    public class MeteoController
    {
        #region Fields
        private Temperature _temperature;
        private Precipitation _precipitation;
        Extractor data;
        View View;
        #endregion

        #region Properties
        internal Temperature Temperature { get => _temperature; set => _temperature = value; }
        internal Precipitation Precipitation { get => _precipitation; set => _precipitation = value; }
        #endregion

        #region Constructors
        public MeteoController(decimal lat, decimal lon, decimal alt, DateTime dateTime, View view)
        {
            this.View = view;
            try
            {
                data = new Extractor(Convert.ToDecimal(lat), Convert.ToDecimal(lon), Convert.ToDecimal(alt), dateTime);
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
        public void CreateMeteogram()
        {
            int PreviousDay = DateTime.Today.Day;
            this.View.dtpWeather.MaxDate = DateTime.Today.AddDays(9);
            this.View.dtpWeather.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, PreviousDay);

            this.View.cc1.Series = new SeriesCollection
            {

                new LineSeries
                {
                    Values = new ChartValues<decimal>(this.Temperature.TempMin),
                    Title = "C° (Min) :",
                    Fill = Brushes.Transparent,
                    DataLabels = false,
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Values = new ChartValues<decimal>(this.Temperature.TempMax),
                    Title = "C° (Max) :",
                    Fill = Brushes.Transparent,
                    DataLabels = false,
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Values = new ChartValues<decimal>(this.Temperature.Temp),
                    Title = "C° :",
                    Fill = Brushes.Transparent,
                    PointGeometry = null,
                    StrokeThickness = 4,
                    DataLabels = false,
                    ScalesYAt = 0
                },
                new ColumnSeries
                {
                    Values = new ChartValues<decimal>(this.Precipitation.Value),
                    Title = "Precipitation (mm) :",
                    DataLabels = false,
                    ScalesYAt = 1
                },
            };

            this.View.cc1.Background = new SolidColorBrush(Color.FromRgb(34, 46, 49));

            this.View.cc1.AxisX = new AxesCollection
            {
                new Axis{
                Title = "Temps (heures)",
                Labels = this.AxixX_Hours(),

                },
            };
            this.View.cc1.AxisY = new AxesCollection
            {
                new Axis{
                Separator = new Separator {
                    StrokeThickness = 1.5,
                    StrokeDashArray = new DoubleCollection(4),
                    Stroke = new SolidColorBrush(Color.FromRgb(64, 79, 86))
                },
                Title = "Température (C°)",
                },

                new Axis{
                Separator = new Separator {
                    StrokeThickness = 0,
                },
                Title = "Précipitations (mm)",
                Position = AxisPosition.RightTop,
                LabelFormatter = value => value.ToString("N2"),
                MinValue = 0,
                },
            };
        }

        private List<string> AxixX_Hours()
        {
            List<string> axixX = new List<string>();
            int count = 0;
            DateTime date = DateTime.Now.Date;
            int hourLimit = 0;

            date = date.AddDays(3);

            //For the third day we need to begin at hour 0
            //so basicly, the api will give us only the 6 first hour,
            //to 0 to 5 it will have a 9 value for the day,
            //because we count the hour 06:00, 12:00 and 18:00
            //counted as 3 more.
            if (this.Temperature.Temp.Count == 9)
            {
                hourLimit = 6;
            }

            //It's the same as befor but if we have only the 12 first hours
            //we will count the 12 and add the hour 12:00 and 18:00
            //in the end we have 14 count
            else if (this.Temperature.Temp.Count == 14)
            {
                hourLimit = 12;
            }

            //This time if we have the first 18 first hours
            //we will count the first 18 hours and add the hour 18:00
            //in the end we have 19 count
            else if (this.Temperature.Temp.Count == 19)
            {
                hourLimit = 18;
            }

            //The display for the current day 
            if (DateTime.Now.Date == this.View.dtpWeather.Value.Date)
            {
                count = 0;
                for (int i = 0; i < this.Temperature.Temp.Count; i++)
                {
                    count = 24 - this.Temperature.Temp.Count;
                    count += i;
                    axixX.Add(String.Format("{0}:00", count.ToString()));
                }
            }
            //The display for the third day
            else if (this.View.dtpWeather.Value.Date == date)
            {
                count = 0;
                for (int i = 0; i < this.Temperature.Temp.Count; i++)
                {
                    if ((this.Temperature.Temp.Count <= 9) && (i > hourLimit))
                    {
                        count += 6;
                    }
                    else
                    {
                        count = i;
                    }
                    axixX.Add(String.Format("{0}:00", count.ToString()));
                }
            }
            //The display after the third day
            else if (this.View.dtpWeather.Value.Date > date)
            {
                count = 0;
                for (int i = 0; i < this.Temperature.Temp.Count; i++)
                {
                    count = (i * 6);
                    axixX.Add(String.Format("{0}:00", count.ToString()));
                }
            }
            //The display for two days after today
            else
            {
                count = 0;
                for (int i = 0; i < this.Temperature.Temp.Count; i++)
                {
                    count = i;
                    axixX.Add(String.Format("{0}:00", count.ToString()));
                }
            }
            return axixX;
        }
        #endregion
    }
}