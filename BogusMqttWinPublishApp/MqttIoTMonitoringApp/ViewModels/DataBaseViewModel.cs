using Caliburn.Micro;
using MqttIoTMonitoringApp.Helpers;
using uPLibrary.Networking.M2Mqtt;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Asn1;
using uPLibrary.Networking.M2Mqtt.Messages;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace MqttIoTMonitoringApp.ViewModels
{
    public class DataBaseViewModel:Conductor<object>
    {
        //IsConnected DbLog
        private string brokerUrl;
        public string BrokerUrl
        {
            get => brokerUrl;
            set
            {
                brokerUrl = value;
                NotifyOfPropertyChange(() => BrokerUrl);
            }
        }

        private string topic;
        public string Topic
        {
            get => topic;
            set
            {
                topic = value;
                NotifyOfPropertyChange(() => Topic);
            }
        }

        private string dbLog;
        public string DbLog
        {
            get => dbLog;
            set
            {
                dbLog = value;
                NotifyOfPropertyChange(() => DbLog);
            }
        }

        private string connString;
        public string ConnString
        {
            get => connString;
            set
            {
                connString = value;
                NotifyOfPropertyChange(() => ConnString);
            }
        }

        private bool isConnected;
        public bool IsConnected
        {
            get => isConnected;
            set
            {
                isConnected = value;
                NotifyOfPropertyChange(() => IsConnected);
            }
        }
        public DataBaseViewModel()
        {
            BrokerUrl = Commons.BROKERHOST;
            Topic = Commons.PUB_TOPIC;
            Commons.CONNSTRING = ConnString = "Server=localhost;Port=3306;" +
                                                                                   "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";
        }

        public void Connect()
        {
            if(IsConnected) //토글버튼 온
            {
                Commons.BROKERCLIENT = new MqttClient(BrokerUrl);
                
                try
                {
                    if(Commons.BROKERCLIENT.IsConnected != true)        //broker실행안했을때
                    {
                        Commons.BROKERCLIENT.MqttMsgPublishReceived += BROKERCLIENT_MqttMsgPublishReceived;
                        Commons.BROKERCLIENT.Connect("MqttMonitor");
                        Commons.BROKERCLIENT.Subscribe(new string[] { Commons.PUB_TOPIC },
                            new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                        UpDateText(">>> Message : Broker Connected");
                    }    
                }
                catch (Exception)
                {
                }
            }
            else //토글버튼ㅇ 오프
            {
                try
                {
                    if(Commons.BROKERCLIENT.IsConnected)
                    {
                        Commons.BROKERCLIENT.Disconnect();
                        UpDateText(">>> Message : Broker Disconnected");
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void BROKERCLIENT_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)  //메세지 들어왔을ㄸ ㅐ처리하는 구문
        {
            var message = Encoding.UTF8.GetString(e.Message);
            UpDateText($">>> Message : {message}");
            InsertDataBase(message);
        }

        private void InsertDataBase(string message)
        {
            // TODO
            var CurrDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);

            using (var conn = new MySqlConnection(Commons.CONNSTRING))
            {
                string strInsQuerry = "INSERT INTO smarthometbl " +
                                                 "( " +
                                                 "     Dev_Id, " +
                                                 "     Curr_Time, " +
                                                 "     Temp, " +
                                                 "     Humid, " +
                                                 "     Press) " +
                                                 " VALUES " +
                                                 " ( " +
                                                 "    @Dev_Id, " +
                                                 "    @Curr_Time, " +
                                                 "    @Temp, " +
                                                 "    @Humid, " +
                                                 "    @Press " +
                                                 " ) ";
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strInsQuerry, conn);

                    MySqlParameter paramDevId = new MySqlParameter("@Dev_Id", MySqlDbType.VarChar);
                    paramDevId.Value = CurrDatas["Dev_Id"];
                    cmd.Parameters.Add(paramDevId);

                    MySqlParameter paramCurrTime = new MySqlParameter("@Curr_Time", MySqlDbType.DateTime);
                    paramCurrTime.Value = DateTime.Parse(CurrDatas["Curr_Time"]);
                    cmd.Parameters.Add(paramCurrTime);

                    MySqlParameter paramTemp = new MySqlParameter("@Temp", MySqlDbType.Float);
                    paramTemp.Value = CurrDatas["Temp"];
                    cmd.Parameters.Add(paramTemp);

                    MySqlParameter paramHumid = new MySqlParameter("@Humid", MySqlDbType.Float);
                    paramHumid.Value = CurrDatas["Humid"];
                    cmd.Parameters.Add(paramHumid);

                    MySqlParameter paramPress = new MySqlParameter("@Press", MySqlDbType.Float);
                    paramPress.Value = CurrDatas["Press"];
                    cmd.Parameters.Add(paramPress);

                    if (cmd.ExecuteNonQuery() == 1)
                        UpDateText("[DB] Inserted");
                    else
                        UpDateText("[DB] Failed");
                }
                catch (Exception ex)
                {
                    UpDateText($">>> Message : {ex.Message}");
                }
            }
        }

        private void UpDateText(string message)
        {
            DbLog += $"{message}\n";
        }
    }
}
