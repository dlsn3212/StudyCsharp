using ArduinoMonitoringTest.Base;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Windows.Forms;
using System.Windows;
using MySql.Data.MySqlClient;
using ArduinoMonitoringTest.Helpers;
using System.Windows.Input;
using System.Diagnostics;

namespace ArduinoMonitoringTest
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        

        #region 변수부분
        SerialPort serial;
        private short maxPhotoVal = 1023;                   //포터레지스터 max변수


        List<SensorData> photoDatas = new List<SensorData>();

        List<int> x = new List<int>();

        List<int> value = new List<int>();                          //아두이노 연결시 데이터 저장
        List<int> clear = new List<int>();
     
        Random rand = new Random();
        Timer Timer = new Timer();
        #endregion

        #region 생성자~~초기화
        public bool IsSimulation { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitControls();
            //InitChart();
        }

        private void InitChart()
        {
            linegraph.Plot(clear, clear);
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
        #endregion


        #region 이벤트핸들러

        private void CboSerialPort_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) //포트 번호 바꾸면
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
            InitChart();
        }

        private void openFileClick_Click(object sender, RoutedEventArgs e)      //열기클릭
        {
            String filePath = "D:\\";
            Process.Start(filePath);
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)         //저장클릭
        {
            String filePath = "D:\\";
            Process.Start(filePath);
        }

        private void MenuItem_Click(object sender, System.Windows.RoutedEventArgs e) //시뮬레이션 시작클릭이벤트
        {
            LblConnectionTime.Text = " ";
            IsSimulation = true;
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick1;
            Timer.Start();
            //BtnDisconnect_Click(sender, e);
        }

        private void Timer_Tick1(object sender, EventArgs e)        //보여주기 위해서 계속 부름 Display
        {
            ushort value = (ushort)rand.Next(1, 1024);
            DisplayValue(value.ToString());
        }

        private void MenuItem_Click_1(object sender, System.Windows.RoutedEventArgs e)  //시뮬레이션 중단클릭이벤트
        {
            Timer.Stop();
            IsSimulation = false;
            InitChart();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)                     //도움말
        {
            InfoProgram form = new InfoProgram();
            form.ShowDialog();
        }


        private void Button_Click(object sender, RoutedEventArgs e)     //view all 클릭시
        {
            //linegraph.Plot(0, photoDatas);
        }

        private void MenuSubItemExit_Click(object sender, System.Windows.RoutedEventArgs e) //종료 이벤트
        {
            this.Close();
        }


        #endregion


        #region 사용자 함수
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)              //아두이노로부터 데이터 받으면
        {
            string sVal = serial.ReadLine();
            this.BeginInvoke(new Action(delegate { DisplayValue(sVal); }));
        }

        private void DisplayValue(string sVal)      // 값 보여주는 함수
        {
            try
            {
                ushort v = ushort.Parse(sVal);
                if (v < 0 || v > maxPhotoVal)           //예외처리
                    return;

                SensorData data = new SensorData(DateTime.Now, v);
                photoDatas.Add(data);
                InsertDataToDB(data);
                int Time = photoDatas.Count;        //x축 시간 변수, y축 데이터 변수
                x.Add(Time);
                value.Add(v);
                linegraph.Plot(x, value);

                TxtSensorCount.Text = photoDatas.Count.ToString();
                PgbPhotoRegistor.Value = v;
                LblPhotoRegistor.Text = v.ToString();

                string item = $"{DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}\t{v}";

                RtbLog.AppendText($"{item}\n");
                RtbLog.ScrollToEnd();

                if (IsSimulation == false)
                    BtnPortValue.Content = $"\n{serial.PortName} : {sVal}";
                else
                    BtnPortValue.Content = $"{sVal}";


            }
            catch (Exception ex)
            {
                RtbLog.AppendText($"Error : {ex.Message}\n");
            }
        }

        private void InsertDataToDB(SensorData data)            //DB에 데이터 저장하는 함수
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.CONSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.strQuery, conn);
                MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
                {
                    Value = data.Date
                };
                cmd.Parameters.Add(paramDate);
                MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
                {
                    Value = data.Value
                };
                cmd.Parameters.Add(paramValue);
                cmd.ExecuteNonQuery();
            }
        }
        //키 누르면 동작하는 함수
        private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)  //파일 오픈
        {
            String filePath = "D:\\";
            Process.Start(filePath);
        }
        private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)    //파일 저장
        {
            String filePath = "D:\\";
            Process.Start(filePath);
        }
        private void FinishBinding_Executed(object sender, ExecutedRoutedEventArgs e)           //끝내기
        {
            this.Close();
        }

        private void StartBinding_Executed(object sender, ExecutedRoutedEventArgs e)         //시뮬레이션 시작
        {
            LblConnectionTime.Text = " ";
            IsSimulation = true;
            Timer.Interval = 1000;
            Timer.Tick += Timer_Tick1;
            Timer.Start();
        }

        private void StopBinding_Executed(object sender, ExecutedRoutedEventArgs e)         //시뮬레이션 중단
        {
            Timer.Stop();
            IsSimulation = false;
            InitChart();
        }

        #endregion


    }
}
