using System;
using System.Windows.Forms;

namespace meteo_gramme
{
    public partial class View : Form
    {
        Meteo meteo;

        public View()
        {
            InitializeComponent();

            this.UpdateView();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            this.UpdateView();
        }
        
        private void Weather_ValueChanged(object sender, EventArgs e)
        {
            this.UpdateView();
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

        public void UpdateView()
        {
            try
            {
                meteo = new Meteo(Convert.ToDecimal(txtLat.Text), Convert.ToDecimal(txtLon.Text),
                    Convert.ToDecimal(txtbAlt.Text), dtpWeather.Value, this);
                meteo.CreateMeteogram();
            }
            catch (Exception)
            {
                MessageBox.Show("Données invalides !");
            }           
            
        }

        private void TextBox_Changed(object sender, EventArgs e)
        {
            if(txtLat.Text == "" || txtLon.Text == "" || txtbAlt.Text == "")
            {
                btnLoad.Enabled = false;
            }
            else
            {
                btnLoad.Enabled = true;
            }
        }
    }
}