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
        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = rolename.Text.Trim();
            string password = rolepassword.Text;
            RoleEnum selectedRole = (RoleEnum)rolecomboBox.SelectedItem;

            if (selectedRole == RoleEnum.Admin)
            {
                if (username == "UnicomAdmin" && password == "Unicom0369")
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
            else
            {
                using (var con = DatabaseConfiguration.GetConnection())
                {            
                    string checkQuery = "SELECT password, isActivated FROM users WHERE username = @username AND role = @role";
                    using (var cmd = new SQLiteCommand(checkQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@role", selectedRole.ToString());

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedPassword = reader.GetString(0);
                                int isActivated = reader.GetInt32(1);

                                if (isActivated == 0) 
                                {
                                    this.Hide();
                                    new PasswordSetupForm(username, selectedRole.ToString(), storedPassword).ShowDialog();
                                    this.Show();
                                }
                                else if (storedPassword == password)
                                {
                                    this.Hide();
                                    Form nextForm = null;
                                    switch (selectedRole)
                                    {
                                        case RoleEnum.Student:
                                            nextForm = new StudentForm();
                                            break;
                                        case RoleEnum.Staff:
                                            nextForm = new StaffForm(username);
                                            break;
                                        case RoleEnum.Lecturer:
                                            nextForm = new LecturerForm();
                                            break;
                                    }
                                    nextForm?.ShowDialog();
                                    this.Show();
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
            
        }
    }
}
        

