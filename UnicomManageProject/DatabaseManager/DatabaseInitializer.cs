using System;
using System.Data.SQLite;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Net;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml.Linq;
using UnicomManageProject.Models;

namespace UnicomManageProject.DatabaseManager
{
    internal class DatabaseInitializer
    {
        private const string ConnectionString = "Data Source=UnciomTicDB.db;Version=3;";

        public static void Initialize()
        {
            using (var con = new SQLiteConnection(ConnectionString))
            {
                con.Open();

                // Enable foreign keys explicitly in SQLite
                using (var pragmaCmd = new SQLiteCommand("PRAGMA foreign_keys = ON;", con))
                {
                    pragmaCmd.ExecuteNonQuery();
                }

                string[] tableCommands = new string[]
                {
                    // admin
                    @"CREATE TABLE IF NOT EXISTS admin (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL
                    );",

                    // users
                    @"CREATE TABLE IF NOT EXISTS users (
                        UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL,
                        isActivated INTEGER DEFAULT 0
                    );",

                    // course
                    @"CREATE TABLE IF NOT EXISTS course (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL UNIQUE,
                        Duration TEXT NOT NULL,
                        Description TEXT NOT NULL
                    );",

                    // timetable
                    @"CREATE TABLE IF NOT EXISTS timetable (
                        TimetableId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Room TEXT NOT NULL,
                        Timeslot TEXT NOT NULL,
                        Subject TEXT NOT NULL
                    );",
                      
                    // students
                    @"CREATE TABLE IF NOT EXISTS students (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Address TEXT,
                        PhoneNumber TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        CourseName TEXT NOT NULL,
                        FOREIGN KEY (CourseName) REFERENCES course(Name)
                    );",
                    

                    // marks
                    @"CREATE TABLE IF NOT EXISTS marks (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentId TEXT NOT NULL,
                        StudentName TEXT NOT NULL,
                        Subject TEXT NOT NULL,
                        Exam TEXT NOT NULL,
                        Score TEXT NOT NULL
                    );",

                    // staff
                    @"CREATE TABLE IF NOT EXISTS staff (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserName TEXT NOT NULL UNIQUE,
                        Password TEXT NOT NULL,
                        Address TEXT NOT NULL,
                        Position TEXT NOT NULL
                    );",

                    // lecturers
                    @"CREATE TABLE IF NOT EXISTS lecturers (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        LecturerName TEXT NOT NULL,                    
                        Address TEXT NOT NULL,
                        Phone TEXT NOT NULL,
                        Course TEXT NOT NULL,
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

                // Optional: Seed default admin
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
