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
using System.Xml.Linq;
using UnicomManageProject.DatabaseManager;
using UnicomManageProject.Enums;

namespace UnicomManageProject.Views
{
    public partial class ManageMarksForm : Form
    {
        private int selectedId = -1;

        public ManageMarksForm()
        {
            InitializeComponent();
            this.Load += ManageMarksForm_Load;
            dgvmarkslist.CellClick += dgvmarkslist_CellContentClick;
        }

        private void LoadEnum()
        {

        }
        private void ManageMarksForm_Load(object sender, EventArgs e)
        {
            subjectcombobox.DataSource = Enum.GetValues(typeof(SubjectEnum));
            examcombobox.DataSource = Enum.GetValues(typeof(ExamTypeEnum));
            scorecombobox.DataSource = Enum.GetValues(typeof(MarkEnum));

            subjectcombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            examcombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            scorecombobox.DropDownStyle = ComboBoxStyle.DropDownList;

            LoadMarks();
        }
        private void LoadMarks()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, StudentId, StudentName, Subject, Exam, Score FROM marks";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvmarkslist.DataSource = dt;
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox1.Clear();
            subjectcombobox.SelectedIndex = -1;
            examcombobox.SelectedIndex = -1;
            scorecombobox.SelectedIndex = -1;
            selectedId = -1;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"INSERT INTO marks 
                 (StudentId, StudentName, Subject, Exam, Score) 
                 VALUES (@studentId, @studentName, @subject, @exam, @score)";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@studentId", textBox2.Text);
                    cmd.Parameters.AddWithValue("@studentName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@subject", subjectcombobox.Text);
                    cmd.Parameters.AddWithValue("@exam", examcombobox.Text);
                    cmd.Parameters.AddWithValue("@score", scorecombobox.Text);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mark added.");
                    LoadMarks();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a record to update.");
                return;
            }

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE marks 
                         SET StudentId = @studentId, 
                             StudentName = @studentName,
                             Subject = @subject, 
                             Exam = @exam, 
                             Score = @score 
                         WHERE Id = @id";

                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@studentId", textBox2.Text);
                    cmd.Parameters.AddWithValue("@studentName", textBox1.Text);
                    cmd.Parameters.AddWithValue("@subject", subjectcombobox.Text);
                    cmd.Parameters.AddWithValue("@exam", examcombobox.Text);
                    cmd.Parameters.AddWithValue("@score", scorecombobox.Text);
                    cmd.Parameters.AddWithValue("@id", selectedId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mark updated.");
                    LoadMarks();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void dltbtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a mark to delete.");
                return;
            }

            var confirm = MessageBox.Show("Delete this mark?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM marks WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Mark deleted.");
                        LoadMarks();
                        clearbtn_Click(null, null);
                    }
                }
            }
        }

        private void dgvmarkslist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a mark to delete.");
                return;
            }

            var confirm = MessageBox.Show("Delete this mark?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM marks WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Mark deleted.");
                        LoadMarks();
                        clearbtn_Click(null, null);
                    }
                }

            }
        }
    }
}
