using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomManageProject.DatabaseManager
{
    internal class DatabaseConfiguration
    {
        private static string ConnectionString = "Data Source=users.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
    

