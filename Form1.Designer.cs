
namespace MapyGPS
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.gMapMap = new GMap.NET.WindowsForms.GMapControl();
            this.buttonShowOnMap = new System.Windows.Forms.Button();
            this.textBoxLong = new System.Windows.Forms.TextBox();
            this.textBoxLati = new System.Windows.Forms.TextBox();
            this.labelLong = new System.Windows.Forms.Label();
            this.labelLati = new System.Windows.Forms.Label();
            this.buttonComPort = new System.Windows.Forms.Button();
            this.NMEAlabel = new System.Windows.Forms.Label();
            this.comboBoxCOMPORT = new System.Windows.Forms.ComboBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.buttonBTDevices = new System.Windows.Forms.Button();
            this.listBoxBT = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(569, 518);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // gMapMap
            // 
            this.gMapMap.Bearing = 0F;
            this.gMapMap.CanDragMap = true;
            this.gMapMap.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapMap.GrayScaleMode = false;
            this.gMapMap.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapMap.LevelsKeepInMemory = 5;
            this.gMapMap.Location = new System.Drawing.Point(12, 12);
            this.gMapMap.MarkersEnabled = true;
            this.gMapMap.MaxZoom = 2;
            this.gMapMap.MinZoom = 2;
            this.gMapMap.MouseWheelZoomEnabled = true;
            this.gMapMap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapMap.Name = "gMapMap";
            this.gMapMap.NegativeMode = false;
            this.gMapMap.PolygonsEnabled = true;
            this.gMapMap.RetryLoadTile = 0;
            this.gMapMap.RoutesEnabled = true;
            this.gMapMap.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapMap.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapMap.ShowTileGridLines = false;
            this.gMapMap.Size = new System.Drawing.Size(540, 494);
            this.gMapMap.TabIndex = 1;
            this.gMapMap.Zoom = 0D;
            // 
            // buttonShowOnMap
            // 
            this.buttonShowOnMap.Location = new System.Drawing.Point(575, 68);
            this.buttonShowOnMap.Name = "buttonShowOnMap";
            this.buttonShowOnMap.Size = new System.Drawing.Size(208, 35);
            this.buttonShowOnMap.TabIndex = 2;
            this.buttonShowOnMap.Text = "show location on map";
            this.buttonShowOnMap.UseVisualStyleBackColor = true;
            this.buttonShowOnMap.Click += new System.EventHandler(this.buttonShowOnMap_Click);
            // 
            // textBoxLong
            // 
            this.textBoxLong.Location = new System.Drawing.Point(647, 38);
            this.textBoxLong.Name = "textBoxLong";
            this.textBoxLong.Size = new System.Drawing.Size(125, 22);
            this.textBoxLong.TabIndex = 3;
            this.textBoxLong.TextChanged += new System.EventHandler(this.textBoxLong_TextChanged);
            // 
            // textBoxLati
            // 
            this.textBoxLati.Location = new System.Drawing.Point(647, 14);
            this.textBoxLati.Name = "textBoxLati";
            this.textBoxLati.Size = new System.Drawing.Size(125, 22);
            this.textBoxLati.TabIndex = 4;
            // 
            // labelLong
            // 
            this.labelLong.AutoSize = true;
            this.labelLong.Location = new System.Drawing.Point(572, 38);
            this.labelLong.Name = "labelLong";
            this.labelLong.Size = new System.Drawing.Size(66, 17);
            this.labelLong.TabIndex = 5;
            this.labelLong.Text = "longitude";
            // 
            // labelLati
            // 
            this.labelLati.AutoSize = true;
            this.labelLati.Location = new System.Drawing.Point(572, 14);
            this.labelLati.Name = "labelLati";
            this.labelLati.Size = new System.Drawing.Size(54, 17);
            this.labelLati.TabIndex = 6;
            this.labelLati.Text = "latidute";
            // 
            // buttonComPort
            // 
            this.buttonComPort.Location = new System.Drawing.Point(575, 440);
            this.buttonComPort.Name = "buttonComPort";
            this.buttonComPort.Size = new System.Drawing.Size(208, 36);
            this.buttonComPort.TabIndex = 8;
            this.buttonComPort.Text = "beginCom";
            this.buttonComPort.UseVisualStyleBackColor = true;
            this.buttonComPort.Click += new System.EventHandler(this.buttonOpenSerial);
            // 
            // NMEAlabel
            // 
            this.NMEAlabel.AutoSize = true;
            this.NMEAlabel.Location = new System.Drawing.Point(589, 420);
            this.NMEAlabel.Name = "NMEAlabel";
            this.NMEAlabel.Size = new System.Drawing.Size(183, 17);
            this.NMEAlabel.TabIndex = 9;
            this.NMEAlabel.Text = "NMEA STRING UNAVIABLE";
            // 
            // comboBoxCOMPORT
            // 
            this.comboBoxCOMPORT.FormattingEnabled = true;
            this.comboBoxCOMPORT.Location = new System.Drawing.Point(575, 482);
            this.comboBoxCOMPORT.Name = "comboBoxCOMPORT";
            this.comboBoxCOMPORT.Size = new System.Drawing.Size(208, 24);
            this.comboBoxCOMPORT.TabIndex = 10;
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // buttonBTDevices
            // 
            this.buttonBTDevices.Location = new System.Drawing.Point(579, 282);
            this.buttonBTDevices.Name = "buttonBTDevices";
            this.buttonBTDevices.Size = new System.Drawing.Size(204, 39);
            this.buttonBTDevices.TabIndex = 11;
            this.buttonBTDevices.Text = "BTDevices";
            this.buttonBTDevices.UseVisualStyleBackColor = true;
            this.buttonBTDevices.Click += new System.EventHandler(this.buttonBTDevices_Click);
            // 
            // listBoxBT
            // 
            this.listBoxBT.FormattingEnabled = true;
            this.listBoxBT.ItemHeight = 16;
            this.listBoxBT.Location = new System.Drawing.Point(579, 161);
            this.listBoxBT.Name = "listBoxBT";
            this.listBoxBT.Size = new System.Drawing.Size(203, 100);
            this.listBoxBT.TabIndex = 12;
            this.listBoxBT.SelectedIndexChanged += new System.EventHandler(this.listBoxBT_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 518);
            this.Controls.Add(this.listBoxBT);
            this.Controls.Add(this.buttonBTDevices);
            this.Controls.Add(this.comboBoxCOMPORT);
            this.Controls.Add(this.NMEAlabel);
            this.Controls.Add(this.buttonComPort);
            this.Controls.Add(this.labelLati);
            this.Controls.Add(this.labelLong);
            this.Controls.Add(this.textBoxLati);
            this.Controls.Add(this.textBoxLong);
            this.Controls.Add(this.buttonShowOnMap);
            this.Controls.Add(this.gMapMap);
            this.Controls.Add(this.splitter1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private GMap.NET.WindowsForms.GMapControl gMapMap;
        private System.Windows.Forms.Button buttonShowOnMap;
        private System.Windows.Forms.TextBox textBoxLong;
        private System.Windows.Forms.TextBox textBoxLati;
        private System.Windows.Forms.Label labelLong;
        private System.Windows.Forms.Label labelLati;
        private System.Windows.Forms.Button buttonComPort;
        private System.Windows.Forms.Label NMEAlabel;
        private System.Windows.Forms.ComboBox comboBoxCOMPORT;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button buttonBTDevices;
        private System.Windows.Forms.ListBox listBoxBT;
    }
}

