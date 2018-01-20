using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.IO.Ports;

namespace Mouse_Escalator
{
    public partial class Form1 : Form
    {
        FileStream resultFile;
        SerialPort serialPort = new SerialPort();
        Series locationSeries = new Series("位置");
        Series speedSeries = new Series("速度");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            serialPortSelect.Items.AddRange(ports);

            serialPort.PortName = "COM1";
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.BaudRate = 9600;

            serialPort.Open();
            serialPort.DiscardOutBuffer();
            serialPort.DiscardInBuffer();
            serialPort.DataReceived += new SerialDataReceivedEventHandler(onSerialPortReceive);

            
            locationSeries.ChartType = SeriesChartType.Line;
            locationSeries.BorderWidth = 2;
            //locationSeries.Points.DataBindY(value);
            locationChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            locationChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            locationChart.ChartAreas[0].AxisX.Interval = 10;
            locationChart.ChartAreas[0].AxisY.Maximum = 10;
            locationChart.ChartAreas[0].AxisY.Interval = 1;
            locationChart.Series.Add(locationSeries);
            locationChart.Titles.Add("位置");

            speedSeries.ChartType = SeriesChartType.Line;
            speedSeries.BorderWidth = 2;
            //speedSeries.Points.DataBindY(value);
            speedChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            speedChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            speedChart.ChartAreas[0].AxisX.Interval = 10;
            speedChart.ChartAreas[0].AxisY.Maximum = 35;
            speedChart.ChartAreas[0].AxisY.Interval = 5;
            speedChart.Series.Add(speedSeries);
            speedChart.Titles.Add("速度");
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            try
            {
                resultFile = (System.IO.FileStream)resultFileDialog.OpenFile();
            }
            catch
            {
                resultFilePath.ForeColor = Color.Red;
                resultFilePath.Text = "File path error";
                return;
            }

            serialPort.PortName = serialPortSelect.Text;
            serialPort.DataBits = 8;
            serialPort.Parity = Parity.None;
            serialPort.StopBits = StopBits.One;
            serialPort.BaudRate = 9600;
            try
            {
                serialPort.Open();
                serialPort.DiscardOutBuffer();
                serialPort.DiscardInBuffer();
                serialPort.DataReceived += new SerialDataReceivedEventHandler(onSerialPortReceive);
                serialPortSelect.ForeColor = Color.Black;
            }
            catch
            {
                serialPortSelect.ForeColor = Color.Red;
                serialPortSelect.Text = "Port error";
                return;
            }

            startButton.Enabled = false;
            stopButton.Enabled = true;
            trainTime.Enabled = false;
            fileSelectButton.Enabled = false;
            controlTimer.Enabled = true;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            startButton.Enabled = true;
            stopButton.Enabled = false;
            trainTime.Enabled = true;
            fileSelectButton.Enabled = true;
            controlTimer.Enabled = false;
        }

        private void fileSelectButton_Click(object sender, EventArgs e)
        {
            resultFileDialog.ShowDialog();
        }

        private void resulfFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            resultFilePath.ForeColor = Color.Black;
            resultFilePath.Text = resultFileDialog.FileName;
        }

        private void serialPortSelectKeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void onSerialPortReceive(Object sender, SerialDataReceivedEventArgs e)
        {

        }
        private void controlTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
