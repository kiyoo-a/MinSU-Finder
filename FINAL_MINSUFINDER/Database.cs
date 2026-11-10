using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace FINAL_MINSUFINDER
{
    public class DatabaseConnection
    {
        private string connectionString =
     @"Data Source=(LocalDB)\MSSQLLocalDB;
    AttachDbFilename=C:\Users\cj\OneDrive\Documents\DIRECTORY_minsufinder\MinSU-Finder\FINAL_MINSUFINDER\Database1.mdf;
    Integrated Security=True";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
    internal class Database
    {
    }
}
