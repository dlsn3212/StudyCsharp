namespace ArduinoMonitoringTest.Helpers
{
    class Commons
    {
        internal static readonly string CONSTRING =
           "Data source=localhost;Port=3306;Database=iot_sensordata;Uid=root;Password=mysql_p@ssw0rd;";

        public static string  strQuery = "INSERT INTO sensordatatbl " +
                                                             " (Date, Value) " +
                                                             " VALUES " +
                                                             " (@Date, @Value) ";
    }
}
