using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomManageProject.DatabaseManager;

namespace UnicomManageProject.Controlers
{
    internal class AdminController
    {
        public static class UserManager
        {
            public static bool CreateUser(SQLiteConnection con, SQLiteTransaction tran, string username, string password, string role)
            {
                string insertQuery = @"INSERT INTO users (Username, Password, Role, IsActive)
                               VALUES (@username, @password, @role, 1)";
                using (var cmd = new SQLiteCommand(insertQuery, con, tran))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        public DataTable GetAllAdmins()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, UserName FROM admin";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool AddAdmin(string username, string password)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"INSERT INTO admin (UserName, Password) 
                                 VALUES (@username, @password)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateAdmin(int id, string username, string password)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE admin 
                                 SET UserName = @username, Password = @password 
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteAdmin(int id)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "DELETE FROM admin WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
