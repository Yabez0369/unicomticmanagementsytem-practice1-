using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicomManageProject.DatabaseManager
{
    internal class DatabaseInitializer
    {
        private const string ConnectionString = "Data Source=users.db;Version=3;";

        public static void Initialize()
        {
            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();

                string[] tableCommands = new string[]
                {
                    // users table
                    @"CREATE TABLE IF NOT EXISTS users (
                        UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL,
                        isActivated INTEGER DEFAULT 0
                    );",
                    // students table
                    @"CREATE TABLE IF NOT EXISTS students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Address TEXT
                    );",

                    // staff table
                    @"CREATE TABLE IF NOT EXISTS staff (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Address TEXT
                    );",

                    // lecturers table
                    @"CREATE TABLE IF NOT EXISTS lecturers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Address TEXT
                    );",
                    // admin table
                    @"CREATE TABLE IF NOT EXISTS admin (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );",

                    // course table
                    @"CREATE TABLE IF NOT EXISTS course (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Duration TEXT NOT NULL
                    );",

                    // timetable table
                    @"CREATE TABLE IF NOT EXISTS timetable (
                        TimetableId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Room TEXT NOT NULL,
                        Timeslot TEXT NOT NULL,
                        Subject TEXT NOT NULL
                    );"
                };
                foreach (var command in tableCommands)
                {
                    using (var cmd = new SQLiteCommand(command, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                // Optional: Seed default admin if not present
                string checkAdmin = "SELECT COUNT(*) FROM users WHERE UserName = 'UnicomAdmin'";
                using (var cmd = new SQLiteCommand(checkAdmin, con))
                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count == 0)
                    {
                        string insertAdmin = @"INSERT INTO users (UserName, Password, Role, isActivated) 
                                               VALUES ('UnicomAdmin', 'Unicom0369', 'admin', 1);";
                        using (var insertCmd = new SQLiteCommand(insertAdmin, con))
                        {
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                con.Close();
            }
        }
    }
}
            

