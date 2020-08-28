using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using uPLibrary.Networking.M2Mqtt;

namespace MqttIoTMonitoringApp.Helpers
{
    public class Commons
    {
        public static string BROKERHOST { get; set; }
        public static string PUB_TOPIC { get; set; }            //home/device/data
        public static MqttClient BROKERCLIENT { get; set; }
        public static string CONNSTRING { get; set; }
        public static bool ISCONNECT { get; set; }                 //접속되었는지 확인
    }

    public class NotEmptyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return string.IsNullOrWhiteSpace((value ?? "").ToString())      //값이 비어있으면 값을 채우라고 알려줌
                ? new ValidationResult(false, "Field is required.")
                : ValidationResult.ValidResult;
        }
    }
}
