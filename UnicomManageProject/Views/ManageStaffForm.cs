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
using UnicomManageProject.Enums;

namespace UnicomManageProject.Views
{
    public partial class ManageStaffForm : Form
    {
        private int selectedId = -1;
        public ManageStaffForm()
        {
            InitializeComponent();
            this.Load += ManageStaffForm_Load;
            dgvstafflist.CellClick += dgvstafflist_CellContentClick;
        }

        private void ManageStaffForm_Load(object sender, EventArgs e)
        {
            LoadStaffs();
            positionComboBox.DataSource = Enum.GetValues(typeof(PositionEnum));

        }

        private void LoadStaffs()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, UserName, Address, PhoneNumber, Position FROM staff";
                using (var da = new SQLiteDataAdapter(query, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvstafflist.DataSource = dt;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a staff member to delete.");
                return;
            }

            var confirm = MessageBox.Show("Are you sure you want to delete this staff member?", "Confirm", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    using (var con = DatabaseConfiguration.GetConnection())
                    {
                        string query = "DELETE FROM staff WHERE Id = @id";
                        using (var cmd = new SQLiteCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@id", selectedId);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Staff member deleted.");
                            LoadStaffs();
                            ClearFields();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting staff: " + ex.Message);
                }
            }
        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = @"INSERT INTO staff (UserName, Password, Address, PhoneNumber, Position)
                                     VALUES (@username, @password, @address, @phone, @position)";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", staffnametxt.Text);
                        cmd.Parameters.AddWithValue("@password", "default123"); 
                        cmd.Parameters.AddWithValue("@address", addresstxt.Text);
                        cmd.Parameters.AddWithValue("@phone", phonetxt.Text);
                        cmd.Parameters.AddWithValue("@position", positionComboBox.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Staff member added.");
                        LoadStaffs();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding staff: " + ex.Message);
            }

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            ClearFields();

        }

        private void ClearFields()
        {
            staffnametxt.Clear();
            addresstxt.Clear();
            phonetxt.Clear();
            positionComboBox.SelectedIndex = -1;
            selectedId = -1;
        }
        private void updatebtn_Click(object sender, EventArgs e)
        {
            if (selectedId == -1)
            {
                MessageBox.Show("Please select a staff member to update.");
                return;
            }

            try
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {
                    string query = @"UPDATE staff 
                                     SET UserName = @username,
                                         Address = @address,
                                         PhoneNumber = @phone,
                                         Position = @position
                                     WHERE Id = @id";
                    using (var cmd = new SQLiteCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@username", staffnametxt.Text);
                        cmd.Parameters.AddWithValue("@address", addresstxt.Text);
                        cmd.Parameters.AddWithValue("@phone", phonetxt.Text);
                        cmd.Parameters.AddWithValue("@position", positionComboBox.Text);
                        cmd.Parameters.AddWithValue("@id", selectedId);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Staff member updated.");
                        LoadStaffs();
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating staff: " + ex.Message);
            }
        }

        private void dgvstafflist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvstafflist.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["Id"].Value);
                staffnametxt.Text = row.Cells["UserName"].Value.ToString();
                addresstxt.Text = row.Cells["Address"].Value.ToString();
                phonetxt.Text = row.Cells["PhoneNumber"].Value.ToString();
                positionComboBox.Text = row.Cells["Position"].Value.ToString();
            }
        }

        private void backbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
