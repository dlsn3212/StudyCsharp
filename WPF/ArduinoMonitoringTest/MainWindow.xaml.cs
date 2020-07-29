using ArduinoMonitoringTest.Base;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows;

namespace ArduinoMonitoringTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        SerialPort serial;
        private short xCount = 200;
        private short maxPhotoVal = 1023;
        List<SensorData> photoDatas = new List<SensorData>();

        string strConnString = "Server=localhost;Port=3306;" +
            "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";
     
        Random rand = new Random();
        //Timer timer = new Timer();
        public bool IsSimulation { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitControls();
            InitChart();
        }

        private void InitChart()
        {
     

        }


        private void InitControls()     //포트 가져오는 함수
        {
            foreach (var item in SerialPort.GetPortNames())
            {
                CboSerialPort.Items.Add(item);
            }
            CboSerialPort.Text = "Select Port";

            PgbPhotoRegistor.Minimum = 0;
            PgbPhotoRegistor.Maximum = maxPhotoVal;

            BtnConnect.IsEnabled = BtnDisconnect.IsEnabled = false;

        }


        #region 이벤트핸들러

        private void CboSerialPort_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var portName = CboSerialPort.SelectedItem.ToString();
            serial = new SerialPort(portName);
            serial.DataReceived += Serial_DataReceived;

            BtnConnect.IsEnabled = true;
        }
        private void BtnConnect_Click(object sender, RoutedEventArgs e)     //Connect클릭시
        {
            serial.Open();
            LblConnectionTime.Text = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
            BtnConnect.IsEnabled = false;
            BtnDisconnect.IsEnabled = true;
        }

        private void BtnDisconnect_Click(object sender, RoutedEventArgs e)      //DisConnect클릭시
        {
            serial.Close();
            BtnConnect.IsEnabled = true;
            BtnDisconnect.IsEnabled = false;
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e) //시뮬레이션 시작클릭이벤트
        {

        }

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)  //시뮬레이션 중단클릭이벤트
        {

        }

        private void MenuSubItemExit_Click(object sender, System.Windows.RoutedEventArgs e) //종료 이벤트
        {
            this.Close();
        }

        #endregion



        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string sVal = serial.ReadLine();
            //this.BeginInvoke(new Action(delegate { DisplayValue(sVal); }));
        }

   



        /*private void DisplayValue(string sVal)      // 값 보여주는 함수
        {
            try
            {
                ushort v = ushort.Parse(sVal);
                if (v < 0 || v > maxPhotoVal)
                    return;

                SensorData data = new SensorData(DateTime.Now, v);
                photoDatas.Add(data);
                //InsertDataToDB(data);

                TxtSensorCount.Text = photoDatas.Count.ToString();
                PgbPhotoRegistor.Value = v;
                LblPhotoRegistor.Text = v.ToString();

                string item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{v}";

                RtbLog.AppendText($"{item}\n");
                RtbLog.ScrollToCaret();

                ChtSensorValues.Series[0].Points.Add(v);

                ChtSensorValues.ChartAreas[0].AxisX.Minimum = 0;
                ChtSensorValues.ChartAreas[0].AxisX.Maximum =
                    (photoDatas.Count >= xCount) ? photoDatas.Count : xCount;

                if (photoDatas.Count > xCount)
                    ChtSensorValues.ChartAreas[0].AxisX.ScaleView.Zoom(
                        photoDatas.Count - xCount, photoDatas.Count);
                else
                    ChtSensorValues.ChartAreas[0].AxisX.ScaleView.Zoom(0, xCount);

                if (IsSimulation == false)
                    BtnPortValue.Text = $"{serial.PortName}\n{sVal}";
                else
                    BtnPortValue.Text = $"{sVal}";
            }
            catch (Exception ex)
            {
                RtbLog.AppendText($"Error : {ex.Message}\n");
                RtbLog.ScrollToCaret();
            }
        }*/
    }
}
