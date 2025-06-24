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
using UnicomManageProject.DatabaseManager;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UnicomManageProject.Views
{
    public partial class LecturerForm : Form
    {
        private readonly string _username;   
        public LecturerForm(string username)
        { 
            InitializeComponent();
            _username = username;
        }

        private void LecturerForm_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT UserName, Address FROM lecturers WHERE UserName = @username";
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

        private void viewprofile_Click(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void viewttbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT TimetableId, Subject, Room, Timeslot FROM timetable WHERE Subject IN (SELECT Subject FROM lecturers WHERE UserName = @username)";
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

        private void editttbtn_Click(object sender, EventArgs e)
        {
            var form = new ManageTimetableForm(); // or pass subject if needed
            form.ShowDialog();
            editttbtn_Click(null, null);
        }

        private void editmarksbtn_Click(object sender, EventArgs e)
        {
            var form = new ManageMarksForm(); // or pass subject if needed
            form.ShowDialog();
            editmarksbtn_Click(null, null);
        }

        private void viewmarksbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, UserName, Subject, Exam, Score FROM marks WHERE Subject IN (SELECT Subject FROM lecturers WHERE UserName = @username)";
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

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void viewnoticebtn_Click(object sender, EventArgs e)
        {
            var form = new NoticeForm(); // or pass subject if needed
            form.ShowDialog();
            viewnoticebtn_Click(null, null);
        }
    }
}
