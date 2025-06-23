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

namespace UnicomManageProject.Views
{
    public partial class ManageCourseForm : Form
    {
        private int selectedCourseId = -1;
        public ManageCourseForm()
        {
            InitializeComponent();
            this.Load += ManageCourseForm_Load;
           dgvcourselist.CellClick += dgvcourselist_CellClick;
        }

        private void ManageCourseForm_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, Name, Duration, Description FROM course";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvcourselist.DataSource = dt;
                }
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            coursetxt.Clear();
            durationtxt.Clear();
            descriptiontxt.Clear();
            selectedCourseId = -1;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            string courseName = coursetxt.Text.Trim();
            string duration = durationtxt.Text.Trim();
            string description = descriptiontxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(courseName) || string.IsNullOrWhiteSpace(duration) || string.IsNullOrWhiteSpace(description))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            using (var con = DatabaseConfiguration.GetConnection())
            {
               

                 //Check if course with the same name already exists
                string checkQuery = "SELECT COUNT(*) FROM course WHERE Name = @name";
                using (var checkCmd = new SQLiteCommand(checkQuery, con))
                {
                    checkCmd.Parameters.AddWithValue("@name", courseName);
                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());

                    if (exists > 0)
                    {
                        MessageBox.Show("A course with this name already exists.");
                        return;
                    }
                }

                // Proceed with insertion
                string insertQuery = "INSERT INTO course (Name, Duration, Description) VALUES (@name, @duration, @desc)";
                using (var insertCmd = new SQLiteCommand(insertQuery, con))
                {
                    insertCmd.Parameters.AddWithValue("@name", courseName);
                    insertCmd.Parameters.AddWithValue("@duration", duration);
                    insertCmd.Parameters.AddWithValue("@desc", description);

                    try
                    {
                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show("Course added successfully.");
                        LoadCourses();
                        clearbtn_Click(null, null);
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show($"Error adding course: {ex.Message}");
                    }
                }

                con.Close();
            }
        }


        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to update.");
                return;
            }

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "UPDATE course SET Name = @name, Duration = @duration, Description = @desc WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", coursetxt.Text);
                    cmd.Parameters.AddWithValue("@duration", durationtxt.Text);
                    cmd.Parameters.AddWithValue("@desc", descriptiontxt.Text);
                    cmd.Parameters.AddWithValue("@id", selectedCourseId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course updated.");
                    LoadCourses();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void dltbtn_Click(object sender, EventArgs e)
        {
            if (selectedCourseId == -1)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this course?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM course WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedCourseId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Course deleted.");
                        LoadCourses();
                        clearbtn_Click(null, null);
                    }
                }
            }
        }

        private void dgvcourselist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvcourselist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvcourselist.Rows[e.RowIndex];
                selectedCourseId = Convert.ToInt32(row.Cells["Id"].Value);
                coursetxt.Text = row.Cells["Name"].Value.ToString();
                durationtxt.Text = row.Cells["Duration"].Value.ToString();
                descriptiontxt.Text = row.Cells["Description"].Value.ToString();
            }
        }
    }
}
