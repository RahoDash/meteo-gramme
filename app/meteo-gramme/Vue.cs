using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace meteo_gramme
{
    public partial class Vue : Form
    {
        DATA data;

        public Vue()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            data = new DATA(txtLat.Text, txtLon.Text);
        }
    }
}
