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
        long endTimestamp_counter;
        byte[] stopPacket = { 0x00, 0x00, 0xdd, 0xdd };//new byte[4];
        //stopPacket[0] = 0xdd;
        bool manualMode = false;
        long endTimestamp;
        int[] IR = new int[10];
        double speed;
        int?[] locationChartValue = new int?[150];
        int?[] speedChartValue = new int?[150];
        FileStream resultFileStream;
        StreamWriter resultStreamWriter;
        List<Byte> receiveDataList = new List<Byte>();
        SerialPort serialPort = new SerialPort();
        Series locationSeries = new Series("位置");
        Series speedSeries = new Series("速度");
        int? triggeredIR = null;

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
            manualStopButton.Enabled = false;

            //serialPort.PortName = "COM1"; following is for debug use
            //serialPort.DataBits = 8;
            //serialPort.Parity = Parity.None;
            //serialPort.StopBits = StopBits.One;
            //serialPort.BaudRate = 9600;

            //serialPort.Open();
            //serialPort.DiscardOutBuffer();
            //serialPort.DiscardInBuffer();
            //serialPort.DataReceived += new SerialDataReceivedEventHandler(onSerialPortReceive);


            locationSeries.ChartType = SeriesChartType.Point;
            locationSeries.BorderWidth = 2;
            //locationSeries.Points.DataBindY(value);
            locationChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            locationChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            locationChart.ChartAreas[0].AxisX.Interval = 10;
            locationChart.ChartAreas[0].AxisY.Maximum = 10;
            locationChart.ChartAreas[0].AxisY.Interval = 1;
            //locationChart.ChartAreas[0].AxisY.Minimum = 1;
            locationChart.Series.Add(locationSeries);
            locationChart.Titles.Add("位置");

            speedSeries.ChartType = SeriesChartType.Line;
            speedSeries.BorderWidth = 2;
            //speedSeries.Points.DataBindY(value);
            speedChart.ChartAreas[0].AxisX.IsMarginVisible = false;
            speedChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            speedChart.ChartAreas[0].AxisX.Interval = 10;
            speedChart.ChartAreas[0].AxisY.Maximum = 1000;
            //speedChart.ChartAreas[0].AxisY.Interval = 5;
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
            try
            {
                serialPort.PortName = serialPortSelect.Text;
                serialPort.DataBits = 8;
                serialPort.Parity = Parity.None;
                serialPort.StopBits = StopBits.One;
                serialPort.BaudRate = 9600;
            }
            catch
            {
                serialPortSelect.ForeColor = Color.Red;
                serialPortSelect.Text = "Port error";
                return;
            }
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
            //endTimestamp_counter = endTimestamp - 1;
            timeLeft.Clear();
            startButton.Enabled = false;
            stopButton.Enabled = true;
            trainTime.Enabled = false;
            fileSelectButton.Enabled = false;
            controlTimer.Enabled = true;
            timeLeftTimer.Enabled = true;
            monitorTimer.Enabled = true;
            serialPort.Write(stopPacket, 0, 4);
            
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            serialPort.Write(stopPacket, 0, 4);
            serialPort.Close();
            startButton.Enabled = true;
            stopButton.Enabled = false;
            trainTime.Enabled = true;
            fileSelectButton.Enabled = true;
            controlTimer.Enabled = false;
            timeLeftTimer.Enabled = false;
            monitorTimer.Enabled = false;
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
            try
            {
                Byte[] buffer = new Byte[32];
                int length = (sender as SerialPort).Read(buffer, 0, buffer.Length);
                for (int i = 0; i < length; i++)
                {
                    receiveDataList.Add(buffer[i]);
                }
            }
            catch
            {
                serialPort.Close();
            }
        }
        private void controlTimer_Tick(object sender, EventArgs e)
        {
            // DEBUG serialPort.Write(stopPacket, 0, 4);
            if (getCurrentTimestamp() >= endTimestamp && !manualMode)
            {
                serialPort.Write(stopPacket, 0, 4);
                timeLeftTimer.Enabled = false;
                monitorTimer.Enabled = false;
                timeLeft.Text = "0:0";
                controlTimer.Enabled = false;
                startButton.Enabled = true;
                stopButton.Enabled = false;
                trainTime.Enabled = true;
                fileSelectButton.Enabled = true;
                resultStreamWriter.Close();
                resultFileStream.Close();
                serialPort.Close();
            }
            else
            {
                for (int i = receiveDataList.Count - 5; i >= 1; i--)
                {
                    if (receiveDataList[i] == 0xFF && receiveDataList[i - 1] == 0xFF && i >= 5)
                    {
                        speed = (receiveDataList[i - 5] << 8) | receiveDataList[i - 4];
                        IR[0] = (receiveDataList[i - 3] >> 1) & 1;
                        IR[1] = receiveDataList[i - 3] & 1;
                        IR[2] = receiveDataList[i - 2] & 1;
                        IR[3] = (receiveDataList[i - 2] >> 1) & 1;
                        IR[4] = (receiveDataList[i - 2] >> 2) & 1;
                        IR[5] = (receiveDataList[i - 2] >> 3) & 1;
                        IR[6] = (receiveDataList[i - 2] >> 4) & 1;
                        IR[7] = (receiveDataList[i - 2] >> 5) & 1;
                        IR[8] = (receiveDataList[i - 2] >> 6) & 1;
                        IR[9] = (receiveDataList[i - 2] >> 7) & 1;

                        
                        for (int j = IR.Length - 1; j >= 1; j--)
                        {
                            if (IR[j] == 1)
                            {
                              
                                if (!manualMode) // since we are not in manual mode
                                 {
                                //String str = "speedSelect" + j.ToString();
                                
                                    int targetSpeed = Decimal.ToInt32(((NumericUpDown)Controls.Find("speedSelect" + (j + 1).ToString(), true)[0]).Value) /* * 1000 */;
                                    byte[] dacValue = new byte[4];
                                    switch (targetSpeed) /* since maximum of 10 bits is 4092, so we now devide it into 7 equal parts, whereas 1 part is 584, we believe that there has better way to solve this. */
                                    {
                                        case 0:
                                            {
                                                dacValue[0] = 0x00;
                                                dacValue[1] = 0x00;
                                                break;
                                            }
                                        case 10:
                                            {
                                                dacValue[0] = 0x33;
                                                dacValue[1] = 0x40;
                                                break;
                                            }
                                        case 20:
                                            {
                                                dacValue[0] = 0x4C;
                                                dacValue[1] = 0xC0;
                                                break;
                                            }
                                        case 30:
                                            {
                                                dacValue[0] = 0x66;
                                                dacValue[1] = 0x0;
                                                break;
                                            }
                                        case 40:
                                            {
                                                dacValue[0] = 0x7F;
                                                dacValue[1] = 0xC0;
                                                break;
                                            }
                                        case 50:
                                            {
                                                dacValue[0] = 0x99;
                                                dacValue[1] = 0x80;
                                                break;
                                            }
                                        case 60:
                                            {
                                                dacValue[0] = 0xB3;
                                                dacValue[1] = 0x0;
                                                break;
                                            }
                                        case 70:
                                            {
                                                dacValue[0] = 0xCC;
                                                dacValue[1] = 0x80;
                                                break;
                                            }
                                        case 80:
                                            {
                                                dacValue[0] = 0xE6;
                                                dacValue[1] = 0x0;
                                                break;
                                            }
                                        case 90:
                                            {
                                                dacValue[0] = 0xFF;
                                                dacValue[1] = 0xC0;
                                                break;
                                            }
                                    }


                                    /* backup: dacValue[0] = (byte)(targetSpeed >> 8); */
                                    /* high byte */ //(byte)(targetSpeed & 0xC0); /* if something wrong, maybe is sequence problem, change header to [0] */
                                    /* low byte *///(byte)((targetSpeed >> 8) & 0xFF);//dacValue[1] = (byte)((targetSpeed << 6) & 0xC0);
                                    dacValue[2] = 0xDD;
                                    dacValue[3] = 0xDD;
                                    serialPort.Write(dacValue, 0, 4); /* the packet's sending sequence is from 0 to MAX length, so here exist a harmless bug which the first byte sent is the speed high byte. */
                                }
                                
                                triggeredIR = j;
                                break;
                            }
                        }

                        resultStreamWriter.WriteLine("Speed: " + (speed / 10).ToString() + " cm/min");
                        resultStreamWriter.WriteLine("IR: " + string.Join(",", IR));
                        resultStreamWriter.WriteLine();
                        resultStreamWriter.Flush();
                        

                        receiveDataList.Clear();
                        break; 
                    }
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
                
            

        }

        private void manualStartButton_Click(object sender, EventArgs e)
        {
            manualStartButton.Enabled = false;
            manualStopButton.Enabled = true;
            manualMode = true;
            try
            {
                resultFileStream = (System.IO.FileStream)resultFileDialog.OpenFile();
                resultStreamWriter = new StreamWriter(resultFileStream);
            }
            catch
            {
                resultFilePath.ForeColor = Color.Red;
                resultFilePath.Text = "File path error";
                manualStartButton.Enabled = true;
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
                manualStartButton.Enabled = true;
                serialPort.Close();
                return;
            }
            receiveDataList.Clear();
            startButton.Enabled = false;
            stopButton.Enabled = false;
            monitorTimer.Enabled = true;
            trainTime.Enabled = false;
            fileSelectButton.Enabled = false;
            controlTimer.Enabled = true;
        }

        private void manualStopButton_Click(object sender, EventArgs e)
        {
            controlTimer.Enabled = false;
            startButton.Enabled = true;
            stopButton.Enabled = false;
            trainTime.Enabled = true;
            monitorTimer.Enabled = false;
            fileSelectButton.Enabled = true;
            resultStreamWriter.Close();
            resultFileStream.Close();
            manualStopButton.Enabled = false;
            manualMode = false;
            serialPort.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void timeLeftTimer_Tick(object sender, EventArgs e)
        {
                timeLeft.Text = ((endTimestamp - getCurrentTimestamp()) / 60).ToString() + ":" + ((endTimestamp - getCurrentTimestamp()) % 60).ToString();
        }

        private void monitorTimer_Tick(object sender, EventArgs e)
        {
            for (int j = 0; j < speedChartValue.Length - 1; j++)
            {
                speedChartValue[j] = speedChartValue[j + 1];
            }
            speedChartValue[speedChartValue.Length - 1] = (int)speed;
            speedSeries.Points.DataBindY(speedChartValue);

            for (int j = 0; j < locationChartValue.Length - 1; j++)
            {
               locationChartValue[j] = locationChartValue[j + 1];
            }
            locationChartValue[locationChartValue.Length - 1] = triggeredIR;
            locationSeries.Points.DataBindY(locationChartValue);

        }
    }
}
