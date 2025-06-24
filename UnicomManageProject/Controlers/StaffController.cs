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
    internal class StaffController
    {
        public DataTable GetAllStaff()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, StaffName, Address, Phone, Position FROM staff";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetTimetable()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT TimetableId, Subject, Room, Timeslot FROM timetable";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public DataTable GetMarks()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT StudentId, StudentName, Subject, Exam, Score FROM marks";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool AddStaff(string name, string address, string phone, string position)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            using (var tran = con.BeginTransaction())
            {
                try
                {
                    string insertQuery = @"INSERT INTO staff 
                                   (StaffName, Address, Phone, Position) 
                                   VALUES (@name, @address, @phone, @position)";
                    using (var cmd = new SQLiteCommand(insertQuery, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@position", position);
                        cmd.ExecuteNonQuery();
                    }

                    // Create user login
                    UserManager.CreateUser(con, tran, name, "Staff123", "Staff");

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

        public bool UpdateStaff(int id, string name, string address, string phone, string position)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE staff SET 
                                 StaffName = @name, 
                                 Address = @address, 
                                 Phone = @phone, 
                                 Position = @position 
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@position", position);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteStaff(int id)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "DELETE FROM staff WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
