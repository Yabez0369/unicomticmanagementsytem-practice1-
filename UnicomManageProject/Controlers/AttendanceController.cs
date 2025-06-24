using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomManageProject.DatabaseManager;
using UnicomManageProject.Models;

namespace UnicomManageProject.Controlers
{
    internal class AttendanceController
    {
        public DataTable GetAllAttendance()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                
                string query = "SELECT Id, StudentId, StudentName, Subject, Date, Status FROM attendance";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }

            }
        }

        public bool AddAttendance(int studentId, string studentName, string subject, DateTime date, string status)

        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"INSERT INTO attendance 
                                 (StudentId, StudentName, Subject, Date, Status) 
                                 VALUES (@studentId, @studentName, @subject, @date, @status)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@studentName", studentName);
                    cmd.Parameters.AddWithValue("@subject", subject);
                    cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@status", status);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateAttendance(int id, int studentId, string studentName, string subject, DateTime date, string status)


        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE attendance 
                                 SET StudentId = @studentId,
                                     StudentName = @studentName,
                                     Subject = @subject,
                                     Date = @date,
                                     Status = @status
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);
                    cmd.Parameters.AddWithValue("@studentName", studentName);
                    cmd.Parameters.AddWithValue("@subject", subject);
                    cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteAttendance(int id)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "DELETE FROM attendance WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }   
    }
}
