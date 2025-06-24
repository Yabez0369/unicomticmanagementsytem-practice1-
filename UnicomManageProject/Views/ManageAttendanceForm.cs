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
using UnicomManageProject.Models;

namespace UnicomManageProject.Views
{
    public partial class ManageAttendanceForm : Form
    {
        private int? selectedId = null;
        public ManageAttendanceForm()
        {
            InitializeComponent();
            this.Load += ManageAttendanceForm_Load;
            dgvattendance.CellClick += dgvattendance_CellContentClick;
        }

        private void ManageAttendanceForm_Load(object sender, EventArgs e)
        {
            sunjectnamecombobox.DataSource = Enum.GetValues(typeof(SubjectEnum));
            statuscombobox.DataSource = Enum.GetValues(typeof(AttendanceEnum));
            LoadAttendance();
        }

        private void LoadAttendance()
        {
            try
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "SELECT Id, StudentId, StudentName, Subject, Date, Status FROM attendance";
                    using (var da = new SQLiteDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvattendance.DataSource = dt;
                    }
                }
                dgvattendance.ClearSelection();
                selectedId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance: " + ex.Message);
            }
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox2.Text, out int studentId) || string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Valid Student ID and Name are required.");
                    return;
                }

                string studentName = textBox1.Text.Trim();
                string subject = sunjectnamecombobox.Text;
                string status = statuscombobox.Text;
                DateTime date = ttDate.Value;

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

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Attendance added.");
                        LoadAttendance();
                        //ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding attendance: " + ex.Message);
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedId == null)
                {
                    MessageBox.Show("Please select a record to update.");
                    return;
                }

                if (!int.TryParse(textBox2.Text, out int studentId) || string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("Valid Student ID and Name are required.");
                    return;
                }

                string studentName = textBox1.Text.Trim();
                string subject = sunjectnamecombobox.Text;
                string status = statuscombobox.Text;
                DateTime date = ttDate.Value;

                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = @"UPDATE attendance SET 
                                     StudentId = @studentId,
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
                        cmd.Parameters.AddWithValue("@id", selectedId.Value);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Attendance updated.");
                        LoadAttendance();
                        //ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating attendance: " + ex.Message);
            }
        }

        private void dltbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedId == null)
                {
                    MessageBox.Show("Please select a record to delete.");
                    return;
                }

                var confirm = MessageBox.Show("Delete this attendance record?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    using (var con = DatabaseConfiguration.GetConnection())
                    {
                        string query = "DELETE FROM attendance WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId.Value);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Attendance deleted.");
                            LoadAttendance();
                            //ClearFields();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting attendance: " + ex.Message);
            }
        }

        private void dgvattendance_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvattendance.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id"].Value);
                textBox2.Text = row.Cells["StudentId"].Value.ToString();
                textBox1.Text = row.Cells["StudentName"].Value.ToString();
                sunjectnamecombobox.Text = row.Cells["Subject"].Value.ToString();
                ttDate.Value = DateTime.Parse(row.Cells["Date"].Value.ToString());
                statuscombobox.Text = row.Cells["Status"].Value.ToString();
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void backbtn_Click(object sender, EventArgs e)
        {                 
           this.Close();  
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            sunjectnamecombobox.SelectedIndex = -1;
            statuscombobox.SelectedIndex = -1;
            ttDate.Value = DateTime.Now;
            selectedId = null;
        }
    }
}
