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
    internal class LoginStudentController
    {
        public DataTable GetStudentProfile(string username)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"SELECT UserName, Address, PhoneNumber, Email, CourseName
                                 FROM students
                                 WHERE UserName = @username";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@username", username);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
