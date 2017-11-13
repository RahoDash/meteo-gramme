namespace meteo_gramme
{
    partial class Vue
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cc1 = new LiveCharts.WinForms.CartesianChart();
            this.dtpWeather = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(17, 15);
            this.txtLat.Margin = new System.Windows.Forms.Padding(4);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(132, 22);
            this.txtLat.TabIndex = 0;
            this.txtLat.Text = "46.2043907";
            this.txtLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressForDecimal);
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(159, 15);
            this.txtLon.Margin = new System.Windows.Forms.Padding(4);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(132, 22);
            this.txtLon.TabIndex = 1;
            this.txtLon.Text = "6.1431577";
            this.txtLon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.keyPressForDecimal);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(299, 9);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(100, 38);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.Load_Click);
            // 
            // cc1
            // 
            this.cc1.Location = new System.Drawing.Point(17, 87);
            this.cc1.Margin = new System.Windows.Forms.Padding(4);
            this.cc1.Name = "cc1";
            this.cc1.Size = new System.Drawing.Size(947, 454);
            this.cc1.TabIndex = 3;
            this.cc1.Text = "cartesianChart1";
            // 
            // dtpWeather
            // 
            this.dtpWeather.CustomFormat = "yyyy-MMM-dd HH:mm:ss";
            this.dtpWeather.Location = new System.Drawing.Point(571, 15);
            this.dtpWeather.Margin = new System.Windows.Forms.Padding(4);
            this.dtpWeather.Name = "dtpWeather";
            this.dtpWeather.Size = new System.Drawing.Size(265, 22);
            this.dtpWeather.TabIndex = 4;
            this.dtpWeather.ValueChanged += new System.EventHandler(this.dtpWeather_ValueChanged);
            // 
            // Vue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(977, 554);
            this.Controls.Add(this.dtpWeather);
            this.Controls.Add(this.cc1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtLon);
            this.Controls.Add(this.txtLat);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Vue";
            this.Text = "MeteoGramme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLat;
        private System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.Button btnLoad;
        private LiveCharts.WinForms.CartesianChart cc1;
        private System.Windows.Forms.DateTimePicker dtpWeather;
    }
}

