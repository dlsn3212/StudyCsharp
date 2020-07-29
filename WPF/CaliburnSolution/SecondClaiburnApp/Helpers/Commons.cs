using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondClaiburnApp.Helpers
{
    public class Commons
    {
        public static string STRCONNSTRING =
            "Data Source=localhost;Port=3306;Database=testdb;Uid=root;password=mysql_p@ssw0rd";

        public static string SELECTPEOPLEQUERY =
            "SELECT Id, FirstName, LastName " +
            "   FROM peopletbl " +
            " ORDER BY id ";
    }
}
