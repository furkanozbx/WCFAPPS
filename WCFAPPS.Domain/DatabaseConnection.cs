using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFAPPS.Domain
{
    public class DatabaseConnection
    {
        private static DatabaseConnection _databaseConnection;
        private static SqlConnection _sqlConnection;

        private DatabaseConnection()
        {

        }

        public static DatabaseConnection DatabaseConnectionInstance()
        {
            if (_databaseConnection == null)
                _databaseConnection = new DatabaseConnection();
            return _databaseConnection;
        }

        public static SqlConnection OpenSqlConnection()
        {
            var _sqlConnection = new SqlConnection(@"Data Source=SAHIN-PC\MSSQLSERVER2014;Initial Catalog=WCFDB;User Id=sa;Password=123;");


            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();
            return _sqlConnection;


        }

        public static void CloseConnection()
        {
            if (_sqlConnection != null && _sqlConnection.State == System.Data.ConnectionState.Open)
            {
                _sqlConnection.Close();
                _sqlConnection.Dispose();
            }
        }

    }
}
