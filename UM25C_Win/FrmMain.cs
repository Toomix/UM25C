using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UM25C_Win
{
    public partial class FrmMain : Form
    {
        UM25C.UM25C um25c;
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.cbCOM.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (this.cbCOM.Items.Count > 0)
                this.cbCOM.Text = "COM35";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();

            this.Text = "UM25C Reader " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");

            if (um25c.ReadDataDump())
            {
                this.lblVoltage.Text = um25c.Voltage + "V";
                this.lblCurrent.Text = um25c.Current + "A";
                this.lblPower.Text = um25c.Power + "W";
                this.lblImpedance.Text = um25c.Impedance + "Ω";
                this.lblTemperature.Text = um25c.TemperatureC + "°C";
                this.lblError.Text = string.Empty;
                this.chartVoltage.DataBind();
                this.chartCurrent.DataBind();
                this.chartPower.DataBind();
                this.rtbDataDump.Text = um25c.GetDataDump();
            }
            else
            {
                this.lblError.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + " " + um25c.LastError;
            }

            timer.Start();
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            this.um25c = new UM25C.UM25C(this.cbCOM.SelectedItem.ToString())
            {
                LogDataToDataSet = true
            };
            this.chartVoltage.DataSource = um25c.dtsData.Tables["Voltage"];
            this.chartCurrent.DataSource = um25c.dtsData.Tables["Current"];
            this.chartPower.DataSource = um25c.dtsData.Tables["Power"];
            this.timer.Start();
        }
    }
}
