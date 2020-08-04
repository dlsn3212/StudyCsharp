﻿using Caliburn.Micro;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;
using System.ComponentModel;

namespace MvvmArduino.ViewModels
{
    internal class MainViewModel : Conductor<object>
    {
        #region 변수부분
        SerialPort serial;
        private short maxPhotoVal = 1023;                   //포터레지스터 max변수


        List<SensorData> photoDatas = new List<SensorData>();

        List<int> x = new List<int>();

        List<int> value = new List<int>();                          //아두이노 연결시 데이터 저장
        List<int> clear = new List<int>();

        Random rand = new Random();
        public DispatcherTimer Timer = new DispatcherTimer();
        #endregion

        public void LoadInfo()
        {
           // ActivateItem(new InfoViewModel());         //display<>~하는거랑 같음
        }

        #region Base부분
        public class SensorData
        {
            public DateTime Date { get; set; }
            public ushort Value { get; set; }

            public SensorData(DateTime date, ushort value)
            {
                Date = date;
                Value = value;
            }
        }
        #endregion

        string lblConnectionTime;
        public string LblConnectionTime
        {
            get => lblConnectionTime;
            set
            {
                lblConnectionTime = value;
                NotifyOfPropertyChange(() => lblConnectionTime);                 //값 변경 알림
            }
        }

        public bool IsSimulation { get; set; }

        public void openFileClick()                                 //파일 열기 클릭시
        {
            String filePath = "D:\\";
            Process.Start(filePath);
        }

        public void closeFileClick()                                //파일 저장 클릭시
        {
            String filePath = "D:\\";
            Process.Start(filePath);
        }

        public void MenuSubItemExit()                       //끝내기 클릭시
        {
            Environment.Exit(0);

        }

        private void Start()                                            //시뮬레이션 시작클릭이벤트
        {
            IsSimulation = true;
            Timer.Interval =
            Timer.Interval = TimeSpan.FromMilliseconds(1000);    //시간간격 설정
            Timer.Tick += new EventHandler(Timer_Tick1);
            Timer.Start();
            //BtnDisconnect_Click(sender, e);
        }

        private void BtnConnect()     //Connect클릭시
        {
            serial.Open();
            LblConnectionTime.ToString = $"연결시간 : {DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")}";
            //BtnConnect.IsEnabled = false;
            //BtnDisconnect.IsEnabled = true;
        }

        private void Timer_Tick1(object sender, EventArgs e)        //보여주기 위해서 계속 부름 Display
        {
            ushort value = (ushort)rand.Next(1, 1024);
            //DisplayValue(value.ToString());
        }
        #region 키 누르면 동작하는 함수
        //private void OpenCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)  //파일 오픈
        //{
        //    String filePath = "D:\\";
        //    Process.Start(filePath);
        //}
        //private void SaveAsCommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)    //파일 저장
        //{
        //    String filePath = "D:\\";
        //    Process.Start(filePath);
        //}
        //private void FinishBinding_Executed(object sender, ExecutedRoutedEventArgs e)           //끝내기
        //{
        //    Environment.Exit(0);
        //}

        //private void StartBinding_Executed(object sender, ExecutedRoutedEventArgs e)         //시뮬레이션 시작
        //{
        //    //LblConnectionTime.Text = " ";
        //    //IsSimulation = true;
        //    //Timer.Interval = 1000;
        //    //Timer.Tick += Timer_Tick1;
        //    //Timer.Start();
        //}

        //private void StopBinding_Executed(object sender, ExecutedRoutedEventArgs e)         //시뮬레이션 중단
        //{
        //    //Timer.Stop();
        //    //IsSimulation = false;
        //    //InitChart();
        //}
        #endregion
    }
}
