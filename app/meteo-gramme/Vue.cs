using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers

namespace meteo_gramme
{
    public partial class Vue : Form
    {
        DATA data;
        Temperature temperature;

        public Vue()
        {
            InitializeComponent();

            

            int PreviousDay = DateTime.Today.Day;
            this.dtpWeather.MaxDate = DateTime.Today.AddDays(9);
            this.dtpWeather.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, PreviousDay);
            
            


            cc1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Précipitation",
                    Values = new ChartValues<decimal> {5, 6, 2, 7, 3},
                },
                new LineSeries
                {
                    Title = "Température",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7},
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometrySize = 1
                }
            };
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            data = new DATA(txtLat.Text, txtLon.Text);
            temperature= data.Temperature;
            string date = ConvertDateToKey(dtpWeather.Value);
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(temperature.Temp[date + i.ToString()].ToString());
            }
        }
        -
        private void dtpWeather_ValueChanged(object sender, EventArgs e)
        {
            cc1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Précipitation",
                    Values = new ChartValues<decimal> {5, 6, 2, 7, 3},
                },
                new LineSeries
                {
                    Title = "Température",
                    Values = new ChartValues<double> {4, 6, 5, 2, 7},
                    Fill = System.Windows.Media.Brushes.Transparent,
                    PointGeometrySize = 1
                }
            };
        }

        public string ConvertDateToKey(DateTime d)
        {
            string date = d.ToString("yyyy-MM-dd"+"T"+"HH:mm:ss" + "Z" );
            return date;
        }
    }
}
