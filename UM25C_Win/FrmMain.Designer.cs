namespace UM25C_Win
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cbCOM = new System.Windows.Forms.ComboBox();
            this.chartVoltage = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.lblTemperatureHeader = new System.Windows.Forms.Label();
            this.lblTemperature = new System.Windows.Forms.Label();
            this.lblImpedanceHeader = new System.Windows.Forms.Label();
            this.lblImpedance = new System.Windows.Forms.Label();
            this.lblPowerHeader = new System.Windows.Forms.Label();
            this.lblPower = new System.Windows.Forms.Label();
            this.lblCurrentHeader = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.lblVoltageHeader = new System.Windows.Forms.Label();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.chartCurrent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPower = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rtbDataDump = new System.Windows.Forms.RichTextBox();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartVoltage)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPower)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblError);
            this.pnlTop.Controls.Add(this.btnConnect);
            this.pnlTop.Controls.Add(this.cbCOM);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(914, 30);
            this.pnlTop.TabIndex = 0;
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblError.Location = new System.Drawing.Point(200, 0);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(714, 30);
            this.lblError.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnConnect.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.btnConnect.FlatAppearance.BorderSize = 0;
            this.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnConnect.Location = new System.Drawing.Point(109, 0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(91, 30);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // cbCOM
            // 
            this.cbCOM.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbCOM.FormattingEnabled = true;
            this.cbCOM.Location = new System.Drawing.Point(0, 0);
            this.cbCOM.Name = "cbCOM";
            this.cbCOM.Size = new System.Drawing.Size(109, 28);
            this.cbCOM.TabIndex = 0;
            // 
            // chartVoltage
            // 
            chartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea1.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea1.Name = "chaVoltage";
            this.chartVoltage.ChartAreas.Add(chartArea1);
            this.chartVoltage.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Name = "Legend1";
            this.chartVoltage.Legends.Add(legend1);
            this.chartVoltage.Location = new System.Drawing.Point(200, 30);
            this.chartVoltage.Name = "chartVoltage";
            series1.ChartArea = "chaVoltage";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Green;
            series1.Legend = "Legend1";
            series1.LegendText = "Voltage [V]";
            series1.Name = "serVoltage";
            series1.XValueMember = "Time";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "Value";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartVoltage.Series.Add(series1);
            this.chartVoltage.Size = new System.Drawing.Size(714, 253);
            this.chartVoltage.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.lblTemperatureHeader);
            this.panelLeft.Controls.Add(this.lblTemperature);
            this.panelLeft.Controls.Add(this.lblImpedanceHeader);
            this.panelLeft.Controls.Add(this.lblImpedance);
            this.panelLeft.Controls.Add(this.lblPowerHeader);
            this.panelLeft.Controls.Add(this.lblPower);
            this.panelLeft.Controls.Add(this.lblCurrentHeader);
            this.panelLeft.Controls.Add(this.lblCurrent);
            this.panelLeft.Controls.Add(this.lblVoltageHeader);
            this.panelLeft.Controls.Add(this.lblVoltage);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 30);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(200, 938);
            this.panelLeft.TabIndex = 2;
            // 
            // lblTemperatureHeader
            // 
            this.lblTemperatureHeader.Location = new System.Drawing.Point(12, 191);
            this.lblTemperatureHeader.Name = "lblTemperatureHeader";
            this.lblTemperatureHeader.Size = new System.Drawing.Size(182, 13);
            this.lblTemperatureHeader.TabIndex = 9;
            this.lblTemperatureHeader.Text = "Temperature";
            this.lblTemperatureHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTemperature
            // 
            this.lblTemperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTemperature.Location = new System.Drawing.Point(12, 204);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(182, 34);
            this.lblTemperature.TabIndex = 8;
            this.lblTemperature.Text = "0°C";
            this.lblTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImpedanceHeader
            // 
            this.lblImpedanceHeader.Location = new System.Drawing.Point(12, 144);
            this.lblImpedanceHeader.Name = "lblImpedanceHeader";
            this.lblImpedanceHeader.Size = new System.Drawing.Size(182, 13);
            this.lblImpedanceHeader.TabIndex = 7;
            this.lblImpedanceHeader.Text = "Impedance";
            this.lblImpedanceHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblImpedance
            // 
            this.lblImpedance.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblImpedance.Location = new System.Drawing.Point(12, 157);
            this.lblImpedance.Name = "lblImpedance";
            this.lblImpedance.Size = new System.Drawing.Size(182, 34);
            this.lblImpedance.TabIndex = 6;
            this.lblImpedance.Text = "00,000Ω";
            this.lblImpedance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPowerHeader
            // 
            this.lblPowerHeader.Location = new System.Drawing.Point(12, 97);
            this.lblPowerHeader.Name = "lblPowerHeader";
            this.lblPowerHeader.Size = new System.Drawing.Size(182, 13);
            this.lblPowerHeader.TabIndex = 5;
            this.lblPowerHeader.Text = "Power";
            this.lblPowerHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPower
            // 
            this.lblPower.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPower.Location = new System.Drawing.Point(12, 110);
            this.lblPower.Name = "lblPower";
            this.lblPower.Size = new System.Drawing.Size(182, 34);
            this.lblPower.TabIndex = 4;
            this.lblPower.Text = "00,000W";
            this.lblPower.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentHeader
            // 
            this.lblCurrentHeader.Location = new System.Drawing.Point(12, 50);
            this.lblCurrentHeader.Name = "lblCurrentHeader";
            this.lblCurrentHeader.Size = new System.Drawing.Size(182, 13);
            this.lblCurrentHeader.TabIndex = 3;
            this.lblCurrentHeader.Text = "Current";
            this.lblCurrentHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrent
            // 
            this.lblCurrent.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblCurrent.Location = new System.Drawing.Point(12, 63);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(182, 34);
            this.lblCurrent.TabIndex = 2;
            this.lblCurrent.Text = "0,0000A";
            this.lblCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVoltageHeader
            // 
            this.lblVoltageHeader.Location = new System.Drawing.Point(12, 3);
            this.lblVoltageHeader.Name = "lblVoltageHeader";
            this.lblVoltageHeader.Size = new System.Drawing.Size(182, 13);
            this.lblVoltageHeader.TabIndex = 1;
            this.lblVoltageHeader.Text = "Voltage";
            this.lblVoltageHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblVoltage
            // 
            this.lblVoltage.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblVoltage.Location = new System.Drawing.Point(12, 16);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(182, 34);
            this.lblVoltage.TabIndex = 0;
            this.lblVoltage.Text = "00,000V";
            this.lblVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // chartCurrent
            // 
            chartArea2.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea2.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea2.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea2.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea2.Name = "chaCurrent";
            this.chartCurrent.ChartAreas.Add(chartArea2);
            this.chartCurrent.Dock = System.Windows.Forms.DockStyle.Top;
            legend2.Name = "Legend1";
            this.chartCurrent.Legends.Add(legend2);
            this.chartCurrent.Location = new System.Drawing.Point(200, 283);
            this.chartCurrent.Name = "chartCurrent";
            series2.ChartArea = "chaCurrent";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.LegendText = "Current [A]";
            series2.Name = "serCurrent";
            series2.XValueMember = "Time";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "Value";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartCurrent.Series.Add(series2);
            this.chartCurrent.Size = new System.Drawing.Size(714, 253);
            this.chartCurrent.TabIndex = 3;
            // 
            // chartPower
            // 
            chartArea3.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea3.AxisX.IntervalOffsetType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Minutes;
            chartArea3.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Seconds;
            chartArea3.AxisX.LabelStyle.Format = "HH:mm:ss";
            chartArea3.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            chartArea3.Name = "chaPower";
            this.chartPower.ChartAreas.Add(chartArea3);
            this.chartPower.Dock = System.Windows.Forms.DockStyle.Top;
            legend3.Name = "Legend1";
            this.chartPower.Legends.Add(legend3);
            this.chartPower.Location = new System.Drawing.Point(200, 536);
            this.chartPower.Name = "chartPower";
            series3.ChartArea = "chaPower";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Black;
            series3.Legend = "Legend1";
            series3.LegendText = "Power [W]";
            series3.Name = "serPower";
            series3.XValueMember = "Time";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueMembers = "Value";
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chartPower.Series.Add(series3);
            this.chartPower.Size = new System.Drawing.Size(714, 253);
            this.chartPower.TabIndex = 4;
            // 
            // rtbDataDump
            // 
            this.rtbDataDump.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDataDump.Location = new System.Drawing.Point(200, 789);
            this.rtbDataDump.Name = "rtbDataDump";
            this.rtbDataDump.Size = new System.Drawing.Size(714, 179);
            this.rtbDataDump.TabIndex = 5;
            this.rtbDataDump.Text = "";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 968);
            this.Controls.Add(this.rtbDataDump);
            this.Controls.Add(this.chartPower);
            this.Controls.Add(this.chartCurrent);
            this.Controls.Add(this.chartVoltage);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.pnlTop);
            this.Name = "FrmMain";
            this.Text = "UM25C Reader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartVoltage)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartCurrent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPower)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.ComboBox cbCOM;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVoltage;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label lblImpedanceHeader;
        private System.Windows.Forms.Label lblImpedance;
        private System.Windows.Forms.Label lblPowerHeader;
        private System.Windows.Forms.Label lblPower;
        private System.Windows.Forms.Label lblCurrentHeader;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Label lblVoltageHeader;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblTemperatureHeader;
        private System.Windows.Forms.Label lblTemperature;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCurrent;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPower;
        private System.Windows.Forms.RichTextBox rtbDataDump;
    }
}

