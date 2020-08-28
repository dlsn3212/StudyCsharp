using Caliburn.Micro;
using MqttIoTMonitoringApp.Helpers;
using System;
using uPLibrary.Networking.M2Mqtt.Messages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MqttIoTMonitoringApp.ViewModels
{
    public class RealTimeViewModel :Conductor<object>
    {
        #region Living Room
        private double livingTempValue;         //double하니까 소수점 뒤에 더럽게 안나옴
        public double LivingTempValue
        {
            get => livingTempValue;
            set
            {
                livingTempValue = value;
                NotifyOfPropertyChange(() => LivingTempValue);
            }
        }
        private double livingHumidValue;
        public double LivingHumidValue
        {
            get => livingHumidValue;
            set
            {
                livingHumidValue = value;
                NotifyOfPropertyChange(() => LivingHumidValue);
            }
        }
        private double livingPreValue;
        public double LivingPreValue
        {
            get => livingPreValue;
            set
            {
                livingPreValue = value;
                NotifyOfPropertyChange(() => LivingPreValue);
            }
        }
        #endregion

        #region Dining Room
        private double diningTempValue;
        public double DiningTempValue
        {
            get => diningTempValue;
            set
            {
                diningTempValue = value;
                NotifyOfPropertyChange(() => DiningTempValue);
            }
        }
        private double diningHumidValue;
        public double DiningHumidValue
        {
            get => diningHumidValue;
            set
            {
                diningHumidValue = value;
                NotifyOfPropertyChange(() => DiningHumidValue);
            }
        }
        private double diningPreValue;
        public double DiningPreValue
        {
            get => diningPreValue;
            set
            {
                diningPreValue = value;
                NotifyOfPropertyChange(() => DiningPreValue);
            }
        }
        #endregion

        #region Bed Room
        private double bedTempValue;
        public double BedTempValue
        {
            get => bedTempValue;
            set
            {
                bedTempValue = value;
                NotifyOfPropertyChange(() => BedTempValue);
            }
        }
        private double bedHumidValue;
        public double BedHumidValue
        {
            get => bedHumidValue;
            set
            {
                bedHumidValue = value;
                NotifyOfPropertyChange(() => BedHumidValue);
            }
        }
        private double bedPreValue;
        public double BedPreValue
        {
            get => bedPreValue;
            set
            {
                bedPreValue = value;
                NotifyOfPropertyChange(() => BedPreValue);
            }
        }
        #endregion

        public RealTimeViewModel()
        {
            //Living 초기화
            LivingTempValue = 0f;               
            LivingHumidValue = 0f;
            LivingPreValue = 0f;
            //Dining초기화
            DiningTempValue = 0f;
            DiningHumidValue = 0f;
            DiningPreValue = 0f;
            //Bed초기화
            BedTempValue = 0f;
            BedHumidValue = 0f;
            BedPreValue = 0f;
            if (Commons.BROKERCLIENT != null && Commons.BROKERCLIENT.IsConnected)
                Commons.BROKERCLIENT.MqttMsgPublishReceived += BROKERCLIENT_MqttMsgPublishReceived;
        }

        private void BROKERCLIENT_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            var currDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);
            switch(currDatas["Dev_Id"].ToString())
            {
                case "LivingRoom":
                    LivingTempValue = double.Parse(currDatas["Temp"]);
                    LivingHumidValue = double.Parse(currDatas["Humid"]);
                    LivingPreValue = double.Parse(currDatas["Press"]);
                    break;
                case "DiningRoom":
                    DiningTempValue = double.Parse(currDatas["Temp"]);
                    DiningHumidValue = double.Parse(currDatas["Humid"]);
                    DiningPreValue = double.Parse(currDatas["Press"]);
                    break;
                case "BedRoom":
                    BedTempValue = double.Parse(currDatas["Temp"]);
                    BedHumidValue = double.Parse(currDatas["Humid"]);
                    BedPreValue = double.Parse(currDatas["Press"]);
                    break;

            }
        }
    }
}
