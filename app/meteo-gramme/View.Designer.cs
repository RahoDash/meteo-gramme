namespace meteo_gramme
{
    partial class View
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
            this.components = new System.ComponentModel.Container();
            this.txtLat = new System.Windows.Forms.TextBox();
            this.txtLon = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.cc1 = new LiveCharts.WinForms.CartesianChart();
            this.dtpWeather = new System.Windows.Forms.DateTimePicker();
            this.txtbAlt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmr_update = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtLat
            // 
            this.txtLat.Location = new System.Drawing.Point(13, 34);
            this.txtLat.Name = "txtLat";
            this.txtLat.Size = new System.Drawing.Size(100, 20);
            this.txtLat.TabIndex = 0;
            this.txtLat.Text = "46.2043907";
            this.txtLat.TextChanged += new System.EventHandler(this.TextBox_Changed);
            this.txtLat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForDecimal);
            // 
            // txtLon
            // 
            this.txtLon.Location = new System.Drawing.Point(119, 34);
            this.txtLon.Name = "txtLon";
            this.txtLon.Size = new System.Drawing.Size(100, 20);
            this.txtLon.TabIndex = 1;
            this.txtLon.Text = "6.1431577";
            this.txtLon.TextChanged += new System.EventHandler(this.TextBox_Changed);
            this.txtLon.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForDecimal);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(331, 28);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 31);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Charger";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.Load_Click);
            // 
            // cc1
            // 
            this.cc1.Location = new System.Drawing.Point(13, 71);
            this.cc1.Name = "cc1";
            this.cc1.Size = new System.Drawing.Size(710, 369);
            this.cc1.TabIndex = 3;
            this.cc1.Text = "cartesianChart1";
            // 
            // dtpWeather
            // 
            this.dtpWeather.CustomFormat = "yyyy-MMM-dd HH:mm:ss";
            this.dtpWeather.Location = new System.Drawing.Point(523, 34);
            this.dtpWeather.Name = "dtpWeather";
            this.dtpWeather.Size = new System.Drawing.Size(200, 20);
            this.dtpWeather.TabIndex = 4;
            this.dtpWeather.ValueChanged += new System.EventHandler(this.Weather_ValueChanged);
            // 
            // txtbAlt
            // 
            this.txtbAlt.Location = new System.Drawing.Point(225, 34);
            this.txtbAlt.Name = "txtbAlt";
            this.txtbAlt.Size = new System.Drawing.Size(100, 20);
            this.txtbAlt.TabIndex = 5;
            this.txtbAlt.Text = "375";
            this.txtbAlt.TextChanged += new System.EventHandler(this.TextBox_Changed);
            this.txtbAlt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPressForDecimal);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Latitude";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(116, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Longitude";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(225, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Altitude";
            // 
            // tmr_update
            // 
            this.tmr_update.Interval = 600000;
            this.tmr_update.Tick += new System.EventHandler(this.tmr_update_Tick);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(733, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbAlt);
            this.Controls.Add(this.dtpWeather);
            this.Controls.Add(this.cc1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.txtLon);
            this.Controls.Add(this.txtLat);
            this.Name = "View";
            this.Text = "MeteoGramme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtLat;
        public System.Windows.Forms.TextBox txtLon;
        private System.Windows.Forms.Button btnLoad;
        public LiveCharts.WinForms.CartesianChart cc1;
        public System.Windows.Forms.DateTimePicker dtpWeather;
        public System.Windows.Forms.TextBox txtbAlt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmr_update;
    }
}

