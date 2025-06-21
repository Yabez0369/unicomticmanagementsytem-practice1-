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
    public partial class ManageTimetableForm : Form
    {
        public ManageTimetableForm()
        {
            InitializeComponent();
            this.Load += ManageTimetableForm_Load;
           // dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void ManageTimetableForm_Load(object sender, EventArgs e)
        {
            LoadTimetable();
        }
        private void LoadTimetable()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT TimetableId, Subject, Room, Timeslot FROM timetable";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            subjectcombobox.SelectedIndex = -1;
            roomcombobox.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
            //idLabel.Text = string.Empty;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            string timeslot = $"{dateTimePicker1.Value:yyyy-MM-dd HH:mm} - {dateTimePicker2.Value:yyyy-MM-dd HH:mm}";

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "INSERT INTO timetable (Subject, Room, Timeslot) VALUES (@subject, @room, @timeslot)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", subjectcombobox.Text);
                    cmd.Parameters.AddWithValue("@room", roomcombobox.Text);
                    cmd.Parameters.AddWithValue("@timeslot", timeslot);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Timetable added.");
                    LoadTimetable();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            string timeslot = $"{dateTimePicker1.Value:yyyy-MM-dd HH:mm} - {dateTimePicker2.Value:yyyy-MM-dd HH:mm}";

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE timetable 
                                 SET Subject = @subject, Room = @room, Timeslot = @timeslot 
                                 WHERE TimetableId = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", subjectcombobox.Text);
                    cmd.Parameters.AddWithValue("@room", roomcombobox.Text);
                    cmd.Parameters.AddWithValue("@timeslot", timeslot);
                   

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Timetable updated.");
                    LoadTimetable();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void bdltbtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete this entry?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM timetable WHERE TimetableId = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        //cmd.Parameters.AddWithValue("@id", idLabel.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Timetable deleted.");
                        LoadTimetable();
                        clearbtn_Click(null, null);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                //idLabel.Text = row.Cells["TimetableId"].Value.ToString();
                subjectcombobox.Text = row.Cells["Subject"].Value.ToString();
                roomcombobox.Text = row.Cells["Room"].Value.ToString();

                // Parse timeslot into start and end
                string[] times = row.Cells["Timeslot"].Value.ToString().Split('-');
                if (times.Length == 2)
                {
                    dateTimePicker1.Value = DateTime.Parse(times[0].Trim());
                    dateTimePicker2.Value = DateTime.Parse(times[1].Trim());
                }
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
