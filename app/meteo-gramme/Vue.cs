using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using System;
using System.Windows.Forms;
using LiveCharts.Configurations;
using System.Drawing;

namespace meteo_gramme
{
    public partial class Vue : Form
    {
        Meteo meteo;

        public Vue()
        {
            InitializeComponent();

            Update();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            Update();
            //for (int i = 0; i < 1; i++)
            //{
            //    Console.WriteLine(meteo.Temperature.Temp[date + i.ToString()]);
            //}
        }
        
        private void dtpWeather_ValueChanged(object sender, EventArgs e)
        {
            Update();

            //var mapper = Mappers.Xy<Meteo>()
            //    .X(model => Convert.ToDouble(model.GetFirstDay(DateTime.Now.Date)))   //use DateTime.Ticks as X
            //    .Y(model => Convert.ToDouble(model.Temperature.Temp));           //use the value property as Y

            //Charting.For<Meteo>(mapper);
            //ChartValues<Meteo> values = new ChartValues<Meteo>();
            //cc1.Series = new SeriesCollection
            //{
            //    new ColumnSeries
            //    {
            //        Values = new ChartValues<decimal>(meteo.Temperature.Temp),
            //        Title = "Précipitation",
            //        //Values = new ChartValues<decimal> {5, 6, 2, 7, 3},
            //    },
            //    new LineSeries
            //    {
            //        Title = "Température",
            //        //Values = new ChartValues<double> {4, 6, 5, 2, 7},
            //        Fill = System.Windows.Media.Brushes.Transparent,
            //        PointGeometrySize = 1
            //    }
            //};
        }

        public string ConvertDateToKey(DateTime d)
        {
            string date = d.ToString("yyyy-MM-dd"+"T"+"HH:00:00" + "Z" );
            return date;
        }

        private void keyPressForDecimal(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Update()
        {
            meteo = new Meteo(txtLat.Text, txtLon.Text, dtpWeather.Value);
            //meteo = new Meteo();
            string date = ConvertDateToKey(dtpWeather.Value);

            meteo.GetFirstDay(dtpWeather.Value);

            int PreviousDay = DateTime.Today.Day;
            this.dtpWeather.MaxDate = DateTime.Today.AddDays(9);
            this.dtpWeather.MinDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, PreviousDay);

            var mapper = Mappers.Xy<Meteo>()
                .X(model => Convert.ToDouble(model.GetFirstDay(DateTime.Now.Date)))   //use DateTime.Ticks as X
                .Y(model => Convert.ToDouble(model.Temperature.Temp));           //use the value property as Y

            cc1.Series = new SeriesCollection
            {
                
                new LineSeries
                {
                    Values = new ChartValues<decimal>(meteo.Temperature.TempMin),
                    Title = "C° (Min) :",
                    DataLabels = false
                },
                new LineSeries
                {
                    Values = new ChartValues<decimal>(meteo.Temperature.TempMax),
                    Title = "C° (Min) :",
                    DataLabels = false
                },
                new LineSeries
                {
                    Values = new ChartValues<decimal>(meteo.Temperature.Temp),
                    Title = "C° :",
                    PointGeometry = DefaultGeometries.Triangle,
                    StrokeThickness = 4,
                    DataLabels = false
                },
                new ColumnSeries
                {
                    Values = new ChartValues<decimal>(meteo.Precipitation.Value),
                    Title = "Precipitation (mm) :",
                    DataLabels = false
                },
            };
        }
    }
}