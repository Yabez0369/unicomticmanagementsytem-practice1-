using System;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Xml.Linq;
using UnicomManageProject.DatabaseManager;
using UnicomManageProject.Enums;

namespace UnicomManageProject.Views
{
    public partial class ManageTimetableForm : Form
    {
        private int selectedId = -1;

        public ManageTimetableForm()
        {
            InitializeComponent();
            this.Load += ManageTimetableForm_Load;
            dataGridView1.CellClick += dataGridView1_CellContentClick;
        }

        private void ManageTimetableForm_Load(object sender, EventArgs e)
        {
            // Populate enums in combo boxes
            subjectcombobox.DataSource = Enum.GetValues(typeof(SubjectEnum));
            roomcombobox.DataSource = Enum.GetValues(typeof(RoomEnum));
            timeslotcomboBox.DataSource = Enum.GetValues(typeof(TimeSlot));

            subjectcombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            roomcombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            timeslotcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            subjectcombobox.SelectedIndex = -1;
            roomcombobox.SelectedIndex = -1;
            timeslotcomboBox.SelectedIndex = -1;

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
            timeslotcomboBox.SelectedIndex = -1;
            selectedId = -1;
        }

        private void addbtn_Click(object sender, EventArgs e)
        {
            if (subjectcombobox.SelectedItem == null || roomcombobox.SelectedItem == null || timeslotcomboBox.SelectedItem == null)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            var subject = (SubjectEnum)subjectcombobox.SelectedItem;
            var room = (RoomEnum)roomcombobox.SelectedItem;
            var timeslot = (TimeSlot)timeslotcomboBox.SelectedItem;

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "INSERT INTO timetable (Subject, Room, Timeslot) VALUES (@subject, @room, @timeslot)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", subject.ToString());
                    cmd.Parameters.AddWithValue("@room", room.ToString());
                    cmd.Parameters.AddWithValue("@timeslot", timeslot.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Timetable added.");
                    LoadTimetable();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select an entry to update.");
                return;
            }

            var subject = (SubjectEnum)subjectcombobox.SelectedItem;
            var room = (RoomEnum)roomcombobox.SelectedItem;
            var timeslot = (TimeSlot)timeslotcomboBox.SelectedItem;

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"UPDATE timetable 
                                 SET Subject = @subject, Room = @room, Timeslot = @timeslot 
                                 WHERE TimetableId = @id";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@subject", subject.ToString());
                    cmd.Parameters.AddWithValue("@room", room.ToString());
                    cmd.Parameters.AddWithValue("@timeslot", timeslot.ToString());
                    cmd.Parameters.AddWithValue("@id", selectedId);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Timetable updated.");
                    LoadTimetable();
                    clearbtn_Click(null, null);
                }
            }
        }

        private void bdltbtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select an entry to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this entry?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = "DELETE FROM timetable WHERE TimetableId = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId);
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
                selectedId = Convert.ToInt32(row.Cells["TimetableId"].Value);
                subjectcombobox.SelectedItem = Enum.Parse(typeof(SubjectEnum), row.Cells["Subject"].Value.ToString());
                roomcombobox.SelectedItem = Enum.Parse(typeof(RoomEnum), row.Cells["Room"].Value.ToString());
                timeslotcomboBox.SelectedItem = Enum.Parse(typeof(TimeSlot), row.Cells["Timeslot"].Value.ToString());
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void roomcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No logic needed here yet
        }
    }
}
