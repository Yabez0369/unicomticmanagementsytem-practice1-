using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UnicomManageProject.DatabaseManager;
using UnicomManageProject.Enums;

namespace UnicomManageProject.Views
{
    public partial class ManageLecturerForm : Form
    {
        private int selectedId = -1;
        public ManageLecturerForm()
        {
            InitializeComponent();
            this.Load += ManageLecturerForm_Load;
            dataGridView1.CellClick += LecturerGridView_CellClick;


        }

        private void ManageLecturerForm_Load(object sender, EventArgs e)
        {
           
            comboBox2.DataSource = Enum.GetValues(typeof(SubjectEnum));
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.SelectedIndex = -1;
            LoadCourses();
            LoadLecturers();
        }

        private void LoadCourses()
        {
            try
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "SELECT Name FROM course";
                    using (var cmd = new SQLiteCommand(query, con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var courseList = new List<string>();
                        while (reader.Read())
                        {
                            courseList.Add(reader.GetString(0));
                        }
                        comboBox1.DataSource = courseList;
                        comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                        comboBox1.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading courses:\n" + ex.Message);
            }
        }
        private void LoadLecturers()
        {
            try
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "SELECT Id, LecturerName, Address, Phone, Course, Subject FROM lecturers";
                    using (var da = new SQLiteDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading lecturers:\n" + ex.Message);
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear(); 
            textBox2.Clear(); 
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            selectedId = -1;               
           
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            try
            {
                var subject = (SubjectEnum)comboBox2.SelectedItem;

                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = @"INSERT INTO lecturers 
                             (LecturerName, Address, Phone, Course, Subject) 
                             VALUES (@name, @address, @phone, @course, @subject)";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@address", textBox2.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                        cmd.Parameters.AddWithValue("@course", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@subject", subject.ToString());

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Lecturer added.");
                        LoadLecturers();
                        ClearBtn_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding lecturer:\n" + ex.Message);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a lecturer to update.");
                return;
            }

            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both a course and a subject.");
                return;
            }

            try
            {
                var subject = (SubjectEnum)comboBox2.SelectedItem;

                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = @"UPDATE lecturers 
                             SET LecturerName = @name, Address = @address, Phone = @phone, 
                                 Course = @course, Subject = @subject 
                             WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@name", textBox1.Text);
                        cmd.Parameters.AddWithValue("@address", textBox2.Text);
                        cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                        cmd.Parameters.AddWithValue("@course", comboBox1.Text);
                        cmd.Parameters.AddWithValue("@subject", subject.ToString());
                        cmd.Parameters.AddWithValue("@id", selectedId);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Lecturer updated.");
                        LoadLecturers();
                        ClearBtn_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating lecturer:\n" + ex.Message);
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select an entry to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this lecturer?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
                try
                {
                    using (var con = DatabaseConfiguration.GetConnection())
                    {
                        string query = "DELETE FROM lecturers WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Lecturer deleted.");
                            LoadLecturers();
                            ClearBtn_Click(null, null);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting lecturer:\n" + ex.Message);
                }
        }

        private void LecturerGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0) return;

            try
            {
                var row = dataGridView1.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id"].Value);
                textBox1.Text = row.Cells["LecturerName"].Value.ToString();
                textBox2.Text = row.Cells["Address"].Value.ToString();
                textBox3.Text = row.Cells["Phone"].Value.ToString();
                comboBox1.Text = row.Cells["Course"].Value.ToString();
                comboBox2.SelectedItem = Enum.Parse(typeof(SubjectEnum), row.Cells["Subject"].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading selected lecturer:\n" + ex.Message);
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ManageLecturerForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
