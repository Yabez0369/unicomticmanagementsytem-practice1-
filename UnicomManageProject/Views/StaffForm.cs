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
    public partial class StaffForm : Form
    {
        private readonly StaffController _controller = new StaffController();
        private readonly string _staffUsername;
        public StaffForm(string staffUsername)
        {
            InitializeComponent();
            _staffUsername = staffUsername;
            var staffForm = new StaffForm("DemoUser");
            staffForm.Show();
        }

        private void StaffForm_Load(object sender, EventArgs e)
        {
            LoadProfile();
        }

        private void LoadProfile()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT UserName, Address FROM staff WHERE UserName = @username";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", _staffUsername);
                    using (var da = new SQLiteDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvprofile.DataSource = dt;
                    }
                }
            }
        }

        private void viewprofilebtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT TimetableId, Subject, Room, Timeslot FROM timetable";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvprofile.DataSource = dt;
                }
            }
        }

        private void viewttbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT TimetableId, Subject, Room, Timeslot FROM timetable";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvtt.DataSource = dt;
                }
            }
        }

        private void edittimetablebtn_Click(object sender, EventArgs e)
        {
            var form = new ManageTimetableForm();
            form.ShowDialog();
            edittimetablebtn_Click(null, null);
        }

        private void viewmarksbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, UserName, Subject, Exam, Score FROM marks";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvmarks.DataSource = dt;
                }
            }
        }

        private void editmarksbtn_Click(object sender, EventArgs e)
        {
            var form = new ManageMarksForm();
            form.ShowDialog();
            editmarksbtn_Click(null, null);
        }

        private void noticebtn_Click(object sender, EventArgs e)
        {
            var form = new NoticeForm();
            form.ShowDialog();
            editmarksbtn_Click(null, null);
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
