using System;
using System.Text.RegularExpressions;

namespace ThirdCaliburnApp
{
    public class Commons
    {
        internal static readonly string CONSTRING = 
            "Data source=localhost;Port=3306;Database=testdb;Uid=root;Password=mysql_p@ssw0rd;";

        public class EmployeesTbl
        {
            public static string SELECT_EMPLOYEE = "SELECT ID, " +
                                                                                "              EmpName, " +
                                                                                "              Salary, " +
                                                                                "              DeptName, " +
                                                                                "              Destination " +
                                                                                " FROM employeestbl ";

            public static string UPDATE_EMPLOYEE = "UPDATE employeestbl " +
                                                                                      "    SET " +
                                                                                      "                    EmpName = @EmpName, " +
                                                                                      "                    Salary = @Salary, " +
                                                                                      "                    DeptName = @DeptName, " +
                                                                                      "                    Destination = @Destination " +
                                                                                      "                    WHERE ID = @id ";

            public static string INSERT_EMPLOYEE = "INSERT INTO employeestbl " +
                                                                          " ( " +
                                                                          "      EmpName, " +
                                                                          "      Salary, " +
                                                                          "      DeptName, " +
                                                                          "      Destination " +
                                                                          " ) " +
                                                                          "  VALUES " +
                                                                          " ( " +
                                                                          "    @EmpName, " +
                                                                          "    @Salary, " +
                                                                          "    @DeptName, " +
                                                                          "   @Destination " +
                                                                          " ) ";

            public static string DELETE_EMPLOYEE = "DELETE FROM employeestbl " +
                                                                                    "   WHERE id = @id ";
        }

        internal static bool IsNumeric(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }
    }
}