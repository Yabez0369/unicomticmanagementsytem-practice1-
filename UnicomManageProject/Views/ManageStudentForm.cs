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
        public ManageStudentForm()
        {
            InitializeComponent();
            this.Load += ManageStudentForm_Load;
            //dgvStudentList.CellClick += dgvStudentList_CellClick;
        }
        private void ManageStudentForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }
        private void LoadStudents()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, UserName, Address FROM students";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvStudentList.DataSource = dt;
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
                string query = "INSERT INTO students (UserName, Password, Address) VALUES (@username, @password, @address)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", nameTextBox.Text);
                    cmd.Parameters.AddWithValue("@password", "Default123"); // or capture from UI
                    cmd.Parameters.AddWithValue("@address", addressTextBox.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student added.");
                    LoadStudents();
                }
            }
        }

        private void DltBtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this student?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM students WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        //cmd.Parameters.AddWithValue("@id", idLabel.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Student deleted.");
                        LoadStudents();
                    }
                }
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "UPDATE students SET UserName = @username, Address = @address WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", nameTextBox.Text);
                    cmd.Parameters.AddWithValue("@address", addressTextBox.Text);
                    //cmd.Parameters.AddWithValue("@id", idLabel.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Student updated.");
                    LoadStudents();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvStudentList.Rows[e.RowIndex];
                //idLabel.Text = row.Cells["Id"].Value.ToString(); // Hidden label or read-only textbox
                nameTextBox.Text = row.Cells["UserName"].Value.ToString();
                addressTextBox.Text = row.Cells["Address"].Value.ToString();
            }
        }

        private void ManageStudentForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}
