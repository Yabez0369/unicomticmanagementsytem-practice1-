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
    public partial class ManageStudentForm : Form
    {
        private int selectedStudentId = -1;
        public ManageStudentForm()
        {
            InitializeComponent();
            this.Load += ManageStudentForm_Load;
            dgvStudentList.CellClick += dataGridView1_CellClick;
        }
        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
            LoadCourses();
        }
        private void LoadStudents()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, UserName, Address, PhoneNumber, Email, CourseName FROM students;";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStudentList.DataSource = dt;
                }
            }
        }

        private void LoadCourses()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Name FROM course";
                using (var cmd = new SQLiteCommand(query, con))
                using (var reader = cmd.ExecuteReader())
                {
                    courseComboBox.Items.Clear();
                    while (reader.Read())
                    {
                        courseComboBox.Items.Add(reader.GetString(0));
                    }
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            addressTextBox.Clear();
            phoneTextBox.Clear();
            emailTextBox.Clear();
            courseComboBox.SelectedIndex = -1;
            selectedStudentId = -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"INSERT INTO students 
                                 (UserName, Password, Address, PhoneNumber, Email, CourseName) 
                                 VALUES (@username, @password, @address, @phone, @email, @course)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", nameTextBox.Text);
                    cmd.Parameters.AddWithValue("@password", "Default123");
                    cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                    cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                    cmd.Parameters.AddWithValue("@course", courseComboBox.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added.");
                    LoadStudents();
                    button4_Click(null, null);
                }
            }
        }

        private void DltBtn_Click(object sender, EventArgs e)
        {
            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this student?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM students WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedStudentId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student deleted.");
                        LoadStudents();
                        button4_Click(null, null);
                    }
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            if (selectedStudentId == -1)
            {
                MessageBox.Show("Please select a student to update.");
                return;
            }

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
                    cmd.Parameters.AddWithValue("@username", nameTextBox.Text);
                    cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                    cmd.Parameters.AddWithValue("@phone", phoneTextBox.Text);
                    cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                    cmd.Parameters.AddWithValue("@course", courseComboBox.Text);
                    cmd.Parameters.AddWithValue("@id", selectedStudentId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student updated.");
                    LoadStudents();
                    button4_Click(null, null);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvStudentList.Rows[e.RowIndex];
                selectedStudentId = Convert.ToInt32(row.Cells["Id"].Value);
                nameTextBox.Text = row.Cells["UserName"].Value.ToString();
                addressTextBox.Text = row.Cells["Address"].Value.ToString();
                phoneTextBox.Text = row.Cells["PhoneNumber"].Value.ToString();
                emailTextBox.Text = row.Cells["Email"].Value.ToString();
                courseComboBox.Text = row.Cells["CourseName"].Value.ToString();
            }
        }

        private void ManageStudentForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
