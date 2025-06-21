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
    public partial class ManageStaffForm : Form
    {
        public ManageStaffForm()
        {
            InitializeComponent();
            this.Load += ManageStaffForm_Load;
           // dgvstafflist.CellClick += dgvstafflist_CellClick;
        }

        private void ManageStaffForm_Load(object sender, EventArgs e)
        {
            LoadStaffs();
        }

        private void LoadStaffs()
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT Id, StaffName, Address, Phone, Position FROM staff";
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

        }

        private void Addbtn_Click(object sender, EventArgs e)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = @"INSERT INTO staff (StaffName, Address, Phone, Position)
                                 VALUES (@name, @address, @phone, @position)";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@name", staffnametxt.Text);
                    cmd.Parameters.AddWithValue("@address", addresstxt.Text);
                    cmd.Parameters.AddWithValue("@phone", phonetxt.Text);
                    cmd.Parameters.AddWithValue("@position", positionComboBox.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Staff member added.");
                    LoadStaffs();
                    clearbtn_Click(null, null);
                }
            }

        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            staffnametxt.Clear();
            addresstxt.Clear();
            phonetxt.Clear();
            positionComboBox.SelectedIndex = -1;
            
        }
    }
}
