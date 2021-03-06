﻿/*
 * Ruben Carvalho et Besmir Silka 
 * CFPT - T.IS-E2A
 * 20.11.2017
 * POO v4.0 - meteo-gramme
 */
using System;
using System.Windows.Forms;

namespace meteo_gramme
{
    public partial class View : Form
    {
        MeteoController meteo;

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
        private void tmr_update_Tick(object sender, EventArgs e)
        {
            this.UpdateView();
        }
        public void UpdateView()
        {
            try
            {
                meteo = new MeteoController(Convert.ToDecimal(txtLat.Text), Convert.ToDecimal(txtLon.Text),
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