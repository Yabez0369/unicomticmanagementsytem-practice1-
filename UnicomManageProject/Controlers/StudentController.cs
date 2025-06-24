using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnicomManageProject.DatabaseManager;
using static UnicomManageProject.Controlers.AdminController;
using System.Xml.Linq;

namespace UnicomManageProject.Controlers
{
    internal class StudentController
    {
        public DataTable GetAllStudents()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"SELECT Id, UserName, Address, PhoneNumber, Email, CourseName FROM students";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public bool AddStudent(string username, string address, string phone, string email, string course)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            using (var tran = con.BeginTransaction())
            {
                try
                {
                    // Insert into students table
                    string studentInsert = @"INSERT INTO students 
                                     (Name, Address, PhoneNumber, Email, CourseName) 
                                     VALUES (@name, @address, @phone, @email, @course)";
                    using (var cmd = new SQLiteCommand(studentInsert, con, tran))
                    {
                        cmd.Parameters.AddWithValue("@name", username);
                        cmd.Parameters.AddWithValue("@address", address);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email", email);
                        cmd.Parameters.AddWithValue("@course", course);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert into users table
                    string defaultPassword = "Student123";
                    UserManager.CreateUser(con, tran, username, defaultPassword, "Student");

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

        public bool UpdateStudent(int id, string username, string address, string phone, string email, string course)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE students SET 
                                 UserName = @username,
                                 Address = @address,
                                 PhoneNumber = @phone,
                                 Email = @email,
                                 CourseName = @course 
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@course", course);
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteStudent(int id)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "DELETE FROM students WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }


    }
}
