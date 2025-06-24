using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnicomManageProject.DatabaseManager;
using UnicomManageProject.Enums;
using System.Data.SQLite;

namespace UnicomManageProject.Views
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            rolecomboBox.DataSource = System.Enum.GetValues(typeof(RoleEnum));
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            rolecomboBox.SelectedIndex = 0;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = rolename.Text.Trim();
            string password = rolepassword.Text;
            RoleEnum selectedRole = (RoleEnum)rolecomboBox.SelectedItem;

            if (selectedRole == RoleEnum.Admin)
            {
                HandleAdminLogin(username, password);
            }
            else
            {
                HandleUserLogin(username, password, selectedRole);
            }
        }

        private void HandleAdminLogin(string username, string password)
        {
            if (username == "Admin" && password == "Admin0369")
            {
                this.Hide();
                new AdminForm().ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Invalid admin credentials.");
            }
        }
        private void HandleUserLogin(string username, string password, RoleEnum role)
        {
            using (var con = DatabaseConfiguration.GetConnection())
            {
                string query = "SELECT password, isActivated FROM users WHERE username = @username AND role = @role";
                using (var cmd = new SQLiteCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@role", role.ToString());

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader.GetString(0);
                            int isActivated = reader.GetInt32(1);

                            if (isActivated == 0)
                            {
                                this.Hide();
                                new PasswordSetupForm(username, role.ToString(), storedPassword).ShowDialog();
                                this.Show();
                                return; // Important to stop further processing
                            }

                            if (storedPassword == password)
                            {
                                OpenUserform(role, username); 

                            }
                            else
                            {
                                MessageBox.Show("Invalid password.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("User not found.");
                        }
                    }
                }
            }

        }

        private void OpenUserform(RoleEnum role, string username)
        {
            this.Hide();
            Form nextForm = null;

            switch (role)
            {
                case RoleEnum.Student:
                    nextForm = new StudentForm(username);
                    break;
                case RoleEnum.Staff:
                    nextForm = new StaffForm(username);
                    break;
                case RoleEnum.Lecturer:
                    nextForm = new LecturerForm(username);
                    break;
            }

            nextForm?.ShowDialog();
            this.Show();
        }

        private void btnsubmit_Click(object sender, EventArgs e)
        {
            this.Hide();
            new AdminForm().ShowDialog();
            this.Show();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            rolename.Clear();
            rolepassword.Clear();
            rolecomboBox.SelectedIndex = 0;

        }

        
    }
}
        

