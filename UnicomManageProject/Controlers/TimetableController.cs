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
    internal class TimetableController
    {
        public DataTable GetAllTimetables()
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

        public bool AddTimetable(string subject, string room, string timeslot)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "INSERT INTO timetable (Subject, Room, Timeslot) VALUES (@subject, @room, @timeslot)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", subject);
                    cmd.Parameters.AddWithValue("@room", room);
                    cmd.Parameters.AddWithValue("@timeslot", timeslot);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool UpdateTimetable(int id, string subject, string room, string timeslot)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE timetable 
                                 SET Subject = @subject, Room = @room, Timeslot = @timeslot 
                                 WHERE TimetableId = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", subject);
                    cmd.Parameters.AddWithValue("@room", room);
                    cmd.Parameters.AddWithValue("@timeslot", timeslot);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteTimetable(int id)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "DELETE FROM timetable WHERE TimetableId = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

    }
}
