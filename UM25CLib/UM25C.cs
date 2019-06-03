using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UM25C
{
    /// <summary>
    /// Class for communicatin with UM25C
    /// https://www.aliexpress.com/item/32855845265.html?spm=a2g0s.9042311.0.0.58ca4c4dekJj63
    /// </summary>
    public class UM25C
    {
        #region Public members
        /// <summary>
        /// Maximal timeout to receive 130bytes of data with data dump
        /// </summary>
        public const int RESPONSE_TIMEOUT_MS = 3000;
        /// <summary>
        /// Dataset with tables with measured data
        /// </summary>
        public System.Data.DataSet dtsData;
        /// <summary>
        /// enable/disable logging data to dataset
        /// </summary>
        public bool LogDataToDataSet = false;
        /// <summary>
        /// How many datarows are kept in tables with data
        /// </summary>
        public int KeepRowsInDataSets = 300;
        /// <summary>
        /// Last exception (serial port etc...)
        /// </summary>
        public Exception LastException;
        /// <summary>
        /// Last exception message
        /// </summary>
        public string LastError => LastException?.Message;
        #endregion

        #region Measured values
        /// <summary>
        /// Voltage in Volts
        /// </summary>
        public double Voltage { get; private set; }
        /// <summary>
        /// Current in Amps
        /// </summary>
        public double Current { get; private set; }
        /// <summary>
        /// Power in Watts
        /// </summary>
        public double Power { get; private set; }
        /// <summary>
        /// Temperature in Celsius
        /// </summary>
        public double TemperatureC { get; private set; }
        /// <summary>
        /// Temperature in Fahrenheit
        /// </summary>
        public double TemperatureF { get; private set; }
        /// <summary>
        /// USB +DataLine voltage in Volts
        /// </summary>
        public double USBDataLineVoltagePositive { get; private set; }
        /// <summary>
        /// USB -DataLine voltage in Volts
        /// </summary>
        public double USBDataLineVoltageNegative { get; private set; }
        /// <summary>
        /// Charging mode
        /// </summary>
        public byte ChargingMode { get; private set; }
        /// <summary>
        /// Capacity record in mAh
        /// </summary>
        public double CapacityRecord { get; private set; }
        /// <summary>
        /// Energy record in mWh
        /// </summary>
        public double EnergyRecord { get; private set; }
        /// <summary>
        /// Current to stop recording in Amps
        /// </summary>
        public double RecordingStopCurrent { get; private set; }
        /// <summary>
        /// Duration of recording in Seconds
        /// </summary>
        public uint RecordingSeconds { get; private set; }
        /// <summary>
        /// Duration of recording as timespan 00:00:00
        /// </summary>
        public TimeSpan RecordingTime => TimeSpan.FromSeconds(RecordingSeconds);
        /// <summary>
        /// Active/inactive recording
        /// </summary>
        public bool RecordingActive { get; private set; }
        /// <summary>
        /// Screen timeout in Minutes to turn backlight off
        /// </summary>
        public double ScreenTimeoutMinutes { get; private set; }
        /// <summary>
        /// Level of backlight
        /// </summary>
        public double ScreenBacklight { get; private set; }
        /// <summary>
        /// Impedance in Ohms
        /// </summary>
        public double Impedance { get; private set; }
        /// <summary>
        /// Current screen 0-5
        /// </summary>
        public byte CurrentScreen { get; private set; }
        /// <summary>
        /// Dicstionary with all measured values
        /// </summary>
        public Dictionary<string, object> DictAllValues;
        #endregion

        #region Commands
        //# Commands to send:
        //F0 - Request new data dump; this triggers a 130-byte response
        //F1 - (device control) Go to next screen
        //F2 - (device control) Rotate screen
        //F3 - (device control) Switch to next data group
        //F4 - (device control) Clear data group
        //Bx - (configuration) Set recording threshold to a value between 0.00 and 0.15 A(where 'x' in the byte is 4 bits representing the value after the decimal point, eg.B7 to set it to 0.07 A)
        //Cx - (configuration) Same as Bx, but for when you want to set it to a value between 0.16 and 0.30 A(16 subtracted from the value behind the decimal point, eg. 0.19 A == C3)
        //Dx - (configuration) Set device backlight level; 'x' must be between 0 and 5 (inclusive)
        //Ex - (configuration) Set screen timeout('screensaver'); 'x' is in minutes and must be between 0 and 9 (inclusive), where 0 disables the screensaver
        public const byte GET_DATA_DUMP = 0xF0;
        public const byte NEXT_SCREEN = 0xF1;
        public const byte ROTATE_SCREEN = 0xF2;
        public const byte NEXT_DATA_GROUP = 0xF3;
        public const byte CLEAR_DATA_GROUP = 0xF4;
        #endregion

        #region DataDump response indexes
        //# Response format:
        //All byte offsets are in decimal, and inclusive.All values are big-endian and unsigned.
        //0   - 1   Start marker (always 0x0963)
        //2   - 3   Voltage(in mV, divide by 1000 to get V)
        //4   - 5   Amperage(in mA, divide by 1000 to get A)
        //6   - 9   Wattage(in mW, divide by 1000 to get W)
        //10  - 11  Temperature(in celsius)
        //12  - 13  Temperature(in fahrenheit)
        //14        Unknown(not used in app)
        //15        Currently selected data group
        //16  - 95  Array of main capacity data groups(where the first one, group 0, is the ephemeral one)
        //            -- for each data group: 4 bytes mAh, 4 bytes mWh
        //96  - 97  USB data line voltage(positive) in centivolts(divide by 100 to get V)
        //98  - 99  USB data line voltage(negative) in centivolts(divide by 100 to get V)
        //100       Charging mode; this is an enum, where 0 = unknown/standard, 1 = QC2.0, and presumably 2 = QC3.0 (but I haven't verified this)
        //101       Unknown(not used in app)
        //102 - 105 mAh from threshold-based recording
        //106 - 109 mWh from threshold-based recording
        //110 - 111 Currently configured threshold for recording
        //112 - 115 Duration of recording, in seconds since start
        //116       Recording active(1 if recording)
        //117       Unknown(not used in app)
        //118 - 119 Current screen timeout setting
        //120 - 121 Current backlight setting
        //122 - 125 Resistance in deci-ohms(divide by 10 to get ohms)
        //126       Unknown
        //127       Current screen(same order as on device)
        //128 - 129 Stop marker(always 0xfff1)
        public const int INDEX_VOLTAGE = 2;
        public const int INDEX_CURRENT = 4;
        public const int INDEX_POWER = 6;
        public const int INDEX_TEMPERATURE_C = 10;
        public const int INDEX_TEMPERATURE_F = 12;
        public const int INDEX_USB_DATALINE_VOLTAGE_POSITIVE = 96;
        public const int INDEX_USB_DATALINE_VOLTAGE_NEGATIVE = 98;
        public const int INDEX_CHARGING_MODE = 100;
        public const int INDEX_CAPACITY_RECORD = 102;
        public const int INDEX_ENERGY_RECORD = 106;
        public const int INDEX_RECORDING_STOP_CURRENT = 110;
        public const int INDEX_RECORDING_SECONDS = 112;
        public const int INDEX_RECORDING_ACTIVE = 116;
        public const int INDEX_SCREEN_TIMEOUT_MINUTES = 118;
        public const int INDEX_SCREEN_BACKLIGHT = 120;
        public const int INDEX_IMPEDANCE = 122;
        public const int INDEX_CURRENT_SCREEN = 127;

        #endregion

        #region Dividers
        /// <summary>
        /// Divide by ten
        /// </summary>
        public const double DIVIDE_TEN = 10.0;
        /// <summary>
        /// divide by hundred
        /// </summary>
        public const double DIVIDE_HUNDRED = 100.0;
        /// <summary>
        /// Divide by thousand
        /// </summary>
        public const double DIVIDE_THOUSAND = 1000.0;
        /// <summary>
        /// Divide by ten thousands
        /// </summary>
        public const double DIVIDE_TEN_THOUSAND = 10000.0;
        #endregion

        #region Private members
        private readonly SerialPort serial;
        private string recvData = string.Empty;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor of the class
        /// </summary>
        /// <param name="COMName">COM port name (COM1, COM2 etc.)</param>
        /// <param name="BaudRate">Speed</param>
        /// <param name="Parity">Parity</param>
        /// <param name="DataBits">Number of DataBits</param>
        /// <param name="StopBits">Number of StopBits</param>
        public UM25C(string COMName, int BaudRate = 9600, Parity Parity = Parity.None, int DataBits = 8, StopBits StopBits = StopBits.One)
        {
            this.serial = new SerialPort()
            {
                PortName = COMName,
                BaudRate = BaudRate,
                Parity = Parity,
                DataBits = DataBits,
                StopBits = StopBits,
            };
            serial.DataReceived += Serial_DataReceived;

            DictAllValues = new Dictionary<string, object>();
            this.dtsData = new System.Data.DataSet();
            System.Data.DataTable t = new System.Data.DataTable();
            t.Columns.Add(new System.Data.DataColumn("Time", typeof(DateTime)));
            t.Columns.Add(new System.Data.DataColumn("Value", typeof(double)));

            var tblVoltage = t.Clone();
            tblVoltage.TableName = "Voltage";

            var tblCurrent = t.Clone();
            tblCurrent.TableName = "Current";

            var tblTemperature = t.Clone();
            tblTemperature.TableName = "Power";

            this.dtsData.Tables.AddRange(new System.Data.DataTable[] { tblVoltage, tblCurrent, tblTemperature });
        }
        #endregion

        #region Methods
        /// <summary>
        /// Reads DataDump (130B) from device
        /// </summary>
        /// <returns>ok/nok</returns>
        public bool ReadData()
        {
            bool ret = false;
            if (SendCommand(new byte[1] { GET_DATA_DUMP }))
            {
                DateTime writeD = DateTime.Now.AddMilliseconds(RESPONSE_TIMEOUT_MS);
                while (recvData.Length < 130)
                {
                    if (writeD > DateTime.Now)
                    {
                        this.LastException = new TimeoutException("Response timeout!");
                        recvData = string.Empty;
                        break;
                    }
                }

                if (ParseData(Encoding.ASCII.GetBytes(recvData)))
                {
                    ret = true;
                }
                recvData = string.Empty;
            }

            return ret;
        }
        /// <summary>
        /// Sends command to device
        /// </summary>
        /// <param name="Command">Command to send, see Commands region</param>
        /// <returns>ok/nok</returns>
        private bool SendCommand(byte[] Command)
        {
            bool ret = false;
            try
            {
                if (!this.serial.IsOpen)
                {
                    this.serial.Open();
                }
                this.serial.Write(Command, 0, Command.Length);
                ret = true;
            }
            catch (Exception e)
            {
                this.LastException = e;
            }
            return ret;
        }
        /// <summary>
        /// Returns all data from device as string, ie. for console output
        /// </summary>
        /// <returns>data dump</returns>
        public string GetDataDump()
        {
            string ret = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + (LogDataToDataSet ? $"\tLogging ENABLED keeping: {KeepRowsInDataSets} rows" : "Logging DISABLED") + Environment.NewLine + Environment.NewLine;
            foreach (KeyValuePair<string, object> k in this.DictAllValues)
            {
                ret += k.Key.PadRight(100, ' ') + "" + k.Value + Environment.NewLine;
            }
            return ret;
        }

        /// <summary>
        /// Parse data from device and fill properties
        /// </summary>
        /// <param name="data">Data returned from device</param>
        /// <returns>ok/nok</returns>
        public bool ParseData(byte[] data)
        {
            bool ret = false;
            if (data.Length >= 130)
            {
                Voltage = GetValue(data, INDEX_VOLTAGE, typeof(ushort)) / DIVIDE_THOUSAND;
                Current = GetValue(data, INDEX_CURRENT, typeof(ushort)) / DIVIDE_TEN_THOUSAND;
                Power = GetValue(data, INDEX_POWER, typeof(uint)) / DIVIDE_THOUSAND;
                TemperatureC = GetValue(data, INDEX_TEMPERATURE_C, typeof(ushort));
                TemperatureF = GetValue(data, INDEX_TEMPERATURE_F, typeof(ushort));
                USBDataLineVoltagePositive = GetValue(data, INDEX_USB_DATALINE_VOLTAGE_POSITIVE, typeof(ushort)) / DIVIDE_HUNDRED;
                USBDataLineVoltageNegative = GetValue(data, INDEX_USB_DATALINE_VOLTAGE_NEGATIVE, typeof(ushort)) / DIVIDE_HUNDRED;
                ChargingMode = data[INDEX_CHARGING_MODE];
                CapacityRecord = GetValue(data, INDEX_CAPACITY_RECORD, typeof(uint));
                EnergyRecord = GetValue(data, INDEX_ENERGY_RECORD, typeof(uint));
                RecordingStopCurrent = GetValue(data, INDEX_RECORDING_STOP_CURRENT, typeof(ushort)) / DIVIDE_HUNDRED;
                RecordingSeconds = GetValue(data, INDEX_RECORDING_SECONDS, typeof(uint));
                RecordingActive = GetValue(data, INDEX_RECORDING_ACTIVE, typeof(bool));
                ScreenTimeoutMinutes = GetValue(data, INDEX_SCREEN_TIMEOUT_MINUTES, typeof(ushort));
                ScreenBacklight = GetValue(data, INDEX_SCREEN_BACKLIGHT, typeof(ushort));
                Impedance = GetValue(data, INDEX_IMPEDANCE, typeof(uint)) / DIVIDE_TEN;
                CurrentScreen = data[INDEX_CURRENT_SCREEN];
                FillDictionary();

                if (LogDataToDataSet)
                    AddDataToTables();

                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// Add last values to data dables in dataset
        /// </summary>
        private void AddDataToTables()
        {
            AddToDataTable("Voltage", Voltage);
            AddToDataTable("Current", Current);
            AddToDataTable("Power", Power);
        }

        /// <summary>
        /// Add value to datatable
        /// </summary>
        /// <param name="TableName">DataTable name in dataset</param>
        /// <param name="Value">Value to add to datatable</param>
        private void AddToDataTable(string TableName, object Value)
        {
            if (this.dtsData.Tables[TableName].Rows.Count > KeepRowsInDataSets)
            {
                this.dtsData.Tables[TableName].Rows.RemoveAt(0);
            }
            var r = this.dtsData.Tables[TableName].NewRow();
            r["Time"] = DateTime.Now;
            r["Value"] = Value;
            this.dtsData.Tables[TableName].Rows.Add(r);
        }
        /// <summary>
        /// Fills dictionary with all values from device
        /// </summary>
        private void FillDictionary()
        {
            AddOrUpdateDictionary("Voltage", Voltage);
            AddOrUpdateDictionary("Current", Current);
            AddOrUpdateDictionary("Power", Power);
            AddOrUpdateDictionary("TemperatureC", TemperatureC);
            AddOrUpdateDictionary("TemperatureF", TemperatureF);
            AddOrUpdateDictionary("USBDataLineVoltagePositive", USBDataLineVoltagePositive);
            AddOrUpdateDictionary("USBDataLineVoltageNegative", USBDataLineVoltageNegative);
            AddOrUpdateDictionary("ChargingMode", ChargingMode);
            AddOrUpdateDictionary("CapacityRecord", CapacityRecord);
            AddOrUpdateDictionary("EnergyRecord", EnergyRecord);
            AddOrUpdateDictionary("RecordingStopCurrent", RecordingStopCurrent);
            AddOrUpdateDictionary("RecordingSeconds", RecordingSeconds);
            AddOrUpdateDictionary("RecordingTime", RecordingTime);
            AddOrUpdateDictionary("RecordingActive", RecordingActive);
            AddOrUpdateDictionary("ScreenTimeoutMinutes", ScreenTimeoutMinutes);
            AddOrUpdateDictionary("ScreenBacklight", ScreenBacklight);
            AddOrUpdateDictionary("Impedance", Impedance);
            AddOrUpdateDictionary("CurrentScreen", CurrentScreen);
        }
        /// <summary>
        /// Add or update key value in dictionary
        /// </summary>
        /// <param name="Key">Key</param>
        /// <param name="Value">Value to add</param>
        private void AddOrUpdateDictionary(string Key, object Value)
        {
            if (this.DictAllValues.ContainsKey(Key))
                this.DictAllValues[Key] = Value;
            else
                this.DictAllValues.Add(Key, Value);
        }

        /// <summary>
        /// Returns parsed big-endian value
        /// </summary>
        /// <param name="data">All data from device</param>
        /// <param name="index">Index where to begin</param>
        /// <param name="dataType">DataType to return</param>
        /// <returns>value</returns>
        private dynamic GetValue(byte[] data, int index, Type dataType)
        {
            dynamic ret = null;

            if (dataType == typeof(ushort))
            {
                Array.Reverse(data, index, 2);
                ret = BitConverter.ToUInt16(data, index);
            }
            else if (dataType == typeof(uint))
            {
                Array.Reverse(data, index, 4);
                ret = BitConverter.ToUInt32(data, index);
            }
            else if (dataType == typeof(bool))
            {
                ret = data[index] > 0 ? true : false;
            }
            return ret;
        }
        #endregion

        #region Events
        /// <summary>
        /// Fires when any data received from device on COM port
        /// </summary>
        /// <param name="sender">COM port</param>
        /// <param name="e">arguments</param>
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (this.serial.BytesToRead > 0)
            {
                recvData += this.serial.ReadExisting();
            }
        }
        #endregion

    }
}
