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
        public ManageCourseForm()
        {
            InitializeComponent();
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

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "INSERT INTO course (Name, Duration, Description) VALUES (@name, @duration, @desc)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", coursetxt.Text);
                    cmd.Parameters.AddWithValue("@duration", durationtxt.Text);
                    cmd.Parameters.AddWithValue("@desc", descriptiontxt.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course added.");
                    LoadCourses();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE course 
                                 SET Name = @name, Duration = @duration, Description = @desc 
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", coursetxt.Text);
                    cmd.Parameters.AddWithValue("@duration", durationtxt.Text);
                    cmd.Parameters.AddWithValue("@desc", descriptiontxt.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Course updated.");
                    LoadCourses();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void dltbtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this course?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM course WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        // cmd.Parameters.AddWithValue("@id", idLabel.Text);
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
            if (e.RowIndex >= 0)
            {
                var row = dgvcourselist.Rows[e.RowIndex];
                //idLabel.Text = row.Cells["Id"].Value.ToString();
                coursetxt.Text = row.Cells["Name"].Value.ToString();
                durationtxt.Text = row.Cells["Duration"].Value.ToString();
                descriptiontxt.Text = row.Cells["Description"].Value.ToString();
            }
        }
    }
}
