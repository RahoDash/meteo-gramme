using LiveCharts; //Core of the library
using LiveCharts.Configurations;
using LiveCharts.Wpf; //The WPF controls
using System;
//using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Media;

namespace meteo_gramme
{
    public partial class View : Form
    {
        Meteo meteo;

        public View()
        {
            InitializeComponent();

            CreateMeteogram();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            CreateMeteogram();
        }
        
        private void Weather_ValueChanged(object sender, EventArgs e)
        {
            CreateMeteogram();
        }

        private void KeyPressForDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') == 0))
            {
                e.Handled = true;
            }
        }

        private void CreateMeteogram()
        {
            meteo = new Meteo(Convert.ToDecimal(txtLat.Text), Convert.ToDecimal(txtLon.Text), Convert.ToDecimal(txtbAlt.Text), dtpWeather.Value);

            meteo.GetFirstDay(dtpWeather.Value);

            int PreviousDay = DateTime.Today.Day;
            this.dtpWeather.MaxDate = DateTime.Today.AddDays(9);
            this.dtpWeather.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, PreviousDay);

            cc1.Series = new SeriesCollection
            {

                new LineSeries
                {
                    Values = new ChartValues<decimal>(meteo.Temperature.TempMin),
                    Title = "C° (Min) :",
                    Fill = Brushes.Transparent,
                    DataLabels = false,
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Values = new ChartValues<decimal>(meteo.Temperature.TempMax),
                    Title = "C° (Max) :",
                    Fill = Brushes.Transparent,
                    DataLabels = false,
                    ScalesYAt = 0
                },
                new LineSeries
                {
                    Values = new ChartValues<decimal>(meteo.Temperature.Temp),
                    Title = "C° :",
                    Fill = Brushes.Transparent,
                    PointGeometry = null,
                    StrokeThickness = 4,
                    PointForeground = Brushes.Gray,
                    DataLabels = false,
                    ScalesYAt = 0
                },
                new ColumnSeries
                {
                    Values = new ChartValues<decimal>(meteo.Precipitation.Value),
                    Title = "Precipitation (mm) :",
                    DataLabels = false,
                    ScalesYAt = 1
                },
            };
            

            cc1.AxisX = new AxesCollection
            {
                new Axis{
                Title = "Temps (heures)",
                Labels = this.Hours(),
                
                },
            };
            cc1.AxisY = new AxesCollection
            {
                new Axis{
                Title = "Température (C°)",
                },

                new Axis{
                Title = "Précipitations (mm)",
                Position = AxisPosition.RightTop,
                LabelFormatter = value => value.ToString("N2"),
                MinValue = 0,
                },
            };
        }

        public List<string> Hours()
        {
            List<string> axixX = new List<string>();
            int count = 0;
            DateTime date = DateTime.Now.Date;
            int hourLimit = 0;

            date = date.AddDays(3);

            if (meteo.Temperature.Temp.Count == 9)
            {
                hourLimit = 6;
            }
            else if (meteo.Temperature.Temp.Count == 14)
            {
                hourLimit = 12;
            }
            else if (meteo.Temperature.Temp.Count == 19)
            {
                hourLimit = 18;
            }

            if (DateTime.Now.Date == dtpWeather.Value.Date)
            {
                count = 0;
                for (int i = 0; i < meteo.Temperature.Temp.Count; i++)
                {
                    count = 24 - meteo.Temperature.Temp.Count;
                    count += i;
                    axixX.Add(String.Format("{0}:00", count.ToString()));
                }
            }
            else if(dtpWeather.Value.Date == date)
            {
                count = 0;
                for (int i = 0; i < meteo.Temperature.Temp.Count; i++)
                {
                    if((meteo.Temperature.Temp.Count <= 9) && (i > hourLimit))
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
            else if (dtpWeather.Value.Date > date)
            {
                count = 0;
                for (int i = 0; i < meteo.Temperature.Temp.Count; i++)
                {
                    count = (i * 6);
                    axixX.Add(String.Format("{0}:00", count.ToString()));
                }
            }
            else
            {
                count = 0;
                for (int i = 0; i < meteo.Temperature.Temp.Count; i++)
                {
                    count = i;
                    axixX.Add(String.Format("{0}:00", count.ToString()));
                }
            }

            return axixX;
        }
    }
}