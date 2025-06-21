using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using UnicomManageProject.DatabaseManager;

namespace UnicomManageProject.Views
{
    public partial class ManageLecturerForm : Form
    {
        public ManageLecturerForm()
        {
            InitializeComponent();
            this.Load += ManageLecturerForm_Load;
            //dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void ManageLecturerForm_Load(object sender, EventArgs e)
        {
            LoadLecturers();
        }

        private void LoadLecturers()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, LecturerName, Address, Phone, Email, Course, Subject FROM lecturers";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            //idLabel.Text = string.Empty;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(emailTextBox.Text))
            //{
            //    MessageBox.Show("Please fill in all required fields.");
            //    return;
            //}

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"INSERT INTO lecturers 
                                 (LecturerName, Address, Phone, Email, Course, Subject) 
                                 VALUES (@name, @address, @phone, @email, @course, @subject)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@address", textBox2.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                    //cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
                    cmd.Parameters.AddWithValue("@course", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@subject", comboBox2.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lecturer added.");
                    LoadLecturers();
                    ClearBtn_Click(null, null);
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(idLabel.Text))
            //{
            //    MessageBox.Show("Please select a lecturer to update.");
            //    return;
            //}

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE lecturers 
                                 SET LecturerName = @name, Address = @address, Phone = @phone, 
                                     Email = @email, Course = @course, Subject = @subject 
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@address", textBox2.Text);
                    cmd.Parameters.AddWithValue("@phone", textBox3.Text);               
                    cmd.Parameters.AddWithValue("@course", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@subject", comboBox2.Text);
                    //cmd.Parameters.AddWithValue("@id", idLabel.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Lecturer updated.");
                    LoadLecturers();
                    ClearBtn_Click(null, null);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(idLabel.Text))
            //{
            //    MessageBox.Show("Please select a lecturer to delete.");
            //    return;
            //}

            var confirm = MessageBox.Show("Are you sure you want to delete this lecturer?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM lecturers WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        //cmd.Parameters.AddWithValue("@id", );
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Lecturer deleted.");
                        LoadLecturers();
                        ClearBtn_Click(null, null);
                    }
                }
            }
        }

        private void LecturerGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                //idLabel.Text = row.Cells["Id"].Value.ToString();
                textBox1.Text = row.Cells["LecturerName"].Value.ToString();
                textBox2.Text = row.Cells["Address"].Value.ToString();
                textBox3.Text = row.Cells["Phone"].Value.ToString();
                //emailTextBox.Text = row.Cells["Email"].Value.ToString();
                comboBox1.Text = row.Cells["Course"].Value.ToString();
                comboBox2.Text = row.Cells["Subject"].Value.ToString();
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
