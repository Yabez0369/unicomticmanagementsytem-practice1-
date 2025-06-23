using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using UnicomManageProject.Enums;
using System.Data.SQLite;
using UnicomManageProject.DatabaseManager;
using UnicomManageProject.Controlers;

namespace UnicomManageProject.Views
{
    public partial class ManageAttendanceForm : Form
    {
        private readonly AttendanceController _controller = new AttendanceController();
        public ManageAttendanceForm()
        {
            InitializeComponent();
            this.Load += ManageAttendanceForm_Load;
            //dgvattendance.CellClick += dgvattendance_CellClick;
        }

        private void ManageAttendanceForm_Load(object sender, EventArgs e)
        {
            //sunjectnamecombobox.DataSource = Enum.GetValues(typeof(SubjectEnum));
            //statuscombobox.DataSource = Enum.GetValues(typeof(AttendanceEnum));
            LoadAttendance();
        }

        private void LoadAttendance()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, Subject, Date, Status FROM attendance";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvattendance.DataSource = dt;
                }
            }
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "INSERT INTO attendance (Subject, Date, Status) VALUES (@subject, @date, @status)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", sunjectnamecombobox.Text);
                    cmd.Parameters.AddWithValue("@date", ttDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@status", statuscombobox.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance added.");
                    LoadAttendance();
                    //ClearFields();
                }
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(idLabel.Text)) return;

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "UPDATE attendance SET Subject=@subject, Date=@date, Status=@status WHERE Id=@id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", sunjectnamecombobox.Text);
                    cmd.Parameters.AddWithValue("@date", ttDate.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@status", statuscombobox.Text);
                   // cmd.Parameters.AddWithValue("@id", idLabel.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendance updated.");
                    LoadAttendance();
                    //ClearFields();
                }
            }
        }

        private void dltbtn_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(idLabel.Text)) return;

            var confirm = MessageBox.Show("Delete this attendance record?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM attendance WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                       // cmd.Parameters.AddWithValue("@id", idLabel.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Attendance deleted.");
                        LoadAttendance();
                        //ClearFields();
                    }
                }
            }
        }

        private void dgvattendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvattendance.Rows[e.RowIndex];
               // idLabel.Text = row.Cells["Id"].Value.ToString();
                sunjectnamecombobox.Text = row.Cells["Subject"].Value.ToString();
                ttDate.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
                statuscombobox.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            sunjectnamecombobox.SelectedIndex = -1;
            statuscombobox.SelectedIndex = -1;
            ttDate.Value = DateTime.Now;
            //idLabel.Text = string.Empty;
        }

        private void backbtn_Click(object sender, EventArgs e)
        {                 
           this.Close();  
        }
    }
}
