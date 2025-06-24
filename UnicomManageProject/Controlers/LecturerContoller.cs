using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomManageProject.DatabaseManager;
using static UnicomManageProject.Controlers.AdminController;

namespace UnicomManageProject.Controlers
{
    internal class LecturerContoller
    {
        public DataTable GetAllLecturers()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, LecturerName, Address, Phone, Email, Course, Subject FROM lecturers";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool AddLecturer(string name, string address, string phone, string course, string subject)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            using (var tran = con.BeginTransaction())
            {
                try
                {
                    string insertQuery = @"INSERT INTO lecturers 
                                   (LecturerName, Address, Phone, Course, Subject) 
                                   VALUES (@name, @address, @phone, @course, @subject)";
                    using (var cmd = new SQLiteCommand(insertQuery, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@course", course);
                        cmd.Parameters.AddWithValue("@subject", subject);
                        cmd.ExecuteNonQuery();
                    }

                    // Create user login
                    UserManager.CreateUser(con, tran, name, "Lecturer123", "Lecturer");

                    tran.Commit();
                    return true;
                }
                catch
                {
                    tran.Rollback();
                    return false;
                }
            }
        }

        public bool UpdateLecturer(int id, string name, string address, string phone, string course, string subject)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE lecturers SET 
                                 LecturerName = @name,
                                 Address = @address,
                                 Phone = @phone,
                                 Course = @course,
                                 Subject = @subject 
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@course", course);
                    cmd.Parameters.AddWithValue("@subject", subject);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteLecturer(int id)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "DELETE FROM lecturers WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
