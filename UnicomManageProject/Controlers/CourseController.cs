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
    internal class CourseController
    {
        public DataTable GetAllCourses()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, Name, Duration, Description FROM course";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool AddCourse(string name, string duration, string description)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"INSERT INTO course (Name, Duration, Description)
                                 VALUES (@name, @duration, @desc)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@desc", description);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateCourse(int id, string name, string duration, string description)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE course 
                                 SET Name = @name, Duration = @duration, Description = @desc 
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@duration", duration);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteCourse(int id)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "DELETE FROM course WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
