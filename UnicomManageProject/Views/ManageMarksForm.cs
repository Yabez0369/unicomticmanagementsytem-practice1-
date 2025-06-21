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
    public partial class ManageMarksForm : Form
    {
        public ManageMarksForm()
        {
            InitializeComponent();
            this.Load += ManageMarksForm_Load;
           // dgvmarkslist.CellClick += dgvmarkslist_CellClick;
        }

        private void ManageMarksForm_Load(object sender, EventArgs e)
        {
            LoadMarks();
        }
        private void LoadMarks()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, Subject, Exam, Score FROM marks";
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
            //subjectcombobox.Clear();
            //examcombobox.Clear();
            //scorecombobox.Clear();
            //idLabel.Text = string.Empty;
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "INSERT INTO marks (Subject, Exam, Score) VALUES (@subject, @exam, @score)";
                using (var cmd = new SQLiteCommand(query, con))
                {
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
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE marks 
                                 SET Subject = @subject, Exam = @exam, Score = @score 
                                 WHERE Id = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", subjectcombobox.Text);
                    cmd.Parameters.AddWithValue("@exam", examcombobox.Text);
                    cmd.Parameters.AddWithValue("@score", scorecombobox.Text);
                    //cmd.Parameters.AddWithValue("@id", idLabel.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mark updated.");
                    LoadMarks();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void dltbtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Delete this mark?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM marks WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        //cmd.Parameters.AddWithValue("@id", idLabel.Text);
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
            if (e.RowIndex >= 0)
            {
                var row = dgvmarkslist.Rows[e.RowIndex];
                //idLabel.Text = row.Cells["Id"].Value.ToString();
                subjectcombobox.Text = row.Cells["Subject"].Value.ToString();
                examcombobox.Text = row.Cells["Exam"].Value.ToString();
                scorecombobox.Text = row.Cells["Score"].Value.ToString();
            }
        }
    }
}
