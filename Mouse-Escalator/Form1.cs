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
        long endTimestamp;
        int[] IR = new int[10];
        int speed;
        int?[] locationChartValue = new int?[250];
        int?[] speedChartValue = new int?[250];
        FileStream resultFileStream;
        StreamWriter resultStreamWriter;
        List<Byte> receiveDataList = new List<Byte>();
        SerialPort serialPort = new SerialPort();
        Series locationSeries = new Series("位置");
        Series speedSeries = new Series("速度");

        static public long getCurrentTimestamp()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
        }

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
                resultFileStream = (System.IO.FileStream)resultFileDialog.OpenFile();
                resultStreamWriter = new StreamWriter(resultFileStream);
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
            receiveDataList.Clear();
            
            endTimestamp = getCurrentTimestamp() + long.Parse(trainTime.Text) * 60;
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
            resultStreamWriter.Close();
            resultFileStream.Close();
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
            Byte[] buffer = new Byte[32];
            int length = (sender as SerialPort).Read(buffer, 0, buffer.Length);
            for (int i = 0; i < length; i++)
            {
                receiveDataList.Add(buffer[i]);
            }
            
        }
        private void controlTimer_Tick(object sender, EventArgs e)
        {
            if (getCurrentTimestamp() >= endTimestamp)
            {
                controlTimer.Enabled = false;
                startButton.Enabled = true;
                stopButton.Enabled = false;
                trainTime.Enabled = true;
                fileSelectButton.Enabled = true;
                resultStreamWriter.Close();
                resultFileStream.Close();
            }
            else
            {
                for (int i = receiveDataList.Count - 5; i >= 1; i--)
                {
                    if (receiveDataList[i] == 0xFF && receiveDataList[i - 1] == 0xFF)
                    {
                        speed = (receiveDataList[i - 2] << 8) | receiveDataList[i - 3];
                        IR[0] = receiveDataList[i - 5] & 1;
                        IR[1] = (receiveDataList[i - 5] >> 1) & 2;
                        IR[2] = receiveDataList[i - 4] & 1;
                        IR[3] = (receiveDataList[i - 4] >> 1) & 2;
                        IR[4] = (receiveDataList[i - 4] >> 2) & 4;
                        IR[5] = (receiveDataList[i - 4] >> 3) & 8;
                        IR[6] = (receiveDataList[i - 4] >> 4) & 16;
                        IR[7] = (receiveDataList[i - 4] >> 5) & 32;
                        IR[8] = (receiveDataList[i - 4] >> 6) & 64;
                        IR[9] = (receiveDataList[i - 4] >> 7) & 128;

                        int? triggeredIR = null;
                        for (int j = IR.Length - 1; j >= 0; j--)
                        {
                            if (IR[j] == 1)
                            {
                                int targetSpeed = Decimal.ToInt32(((NumericUpDown)this.Controls.Find("speedSelect" + j.ToString(), true)[0]).Value) * 1000;
                                byte[] dacValue = new byte[2];
                                dacValue[0] = (byte)(targetSpeed >> 8);
                                dacValue[1] = (byte)((targetSpeed << 6) & 0xC0);
                                serialPort.Write(dacValue, 0, 2);
                                triggeredIR = j;
                                break;
                            }
                        }

                        resultStreamWriter.WriteLine("Speed: " + speed.ToString());
                        resultStreamWriter.WriteLine("IR: " + string.Join(",", IR));
                        resultStreamWriter.WriteLine();
                        resultStreamWriter.Flush();

                        for (int j = 0; j < speedChartValue.Length - 1; j++)
                        {
                            speedChartValue[i] = speedChartValue[i + 1];
                        }
                        speedChartValue[speedChartValue.Length - 1] = speed;
                        speedSeries.Points.DataBindY(speedChartValue);

                        for (int j = 0; j < locationChartValue.Length - 1; j++)
                        {
                            locationChartValue[i] = locationChartValue[i + 1];
                        }
                        locationChartValue[locationChartValue.Length - 1] = triggeredIR;
                        locationSeries.Points.DataBindY(locationChartValue);

                        receiveDataList.Clear();
                        break; 
                    }
                }
            }
        }
    }
}
