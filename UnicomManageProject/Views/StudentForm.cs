using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomManageProject.Controlers;
using UnicomManageProject.DatabaseManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnicomManageProject.Views
{
    public partial class StudentForm : Form
    {
        private readonly StudentController _controller = new StudentController();
       private readonly string _username;


        public StudentForm(string username)
        {
            InitializeComponent();
            _username = username;
            this.Load += StudentForm_Load;
        }


        private void LoadStudentProfile()
        {

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"SELECT UserName, Address, PhoneNumber, Email, CourseName 
                                 FROM students 
                                 WHERE UserName = @username";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@username", _username);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvprofile.DataSource = dt;
                }
            }
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {

        }

        private void profileviewbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"SELECT UserName, Address 
                                 FROM students 
                                 WHERE UserName = @username";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", _username);
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvprofile.DataSource = dt;
                    }
                }
            }
        }

        private void ttbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Subject, Room, Timeslot FROM timetable";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvtt.DataSource = dt;
                }
            }
        }

        private void marksbtn_Click(object sender, EventArgs e)
        {                    
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"SELECT Subject, Exam, Score 
                                FROM marks 
                                WHERE StudentName = @username";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", _username);
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvmarks.DataSource = dt;
                    }
                }
            }          
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
