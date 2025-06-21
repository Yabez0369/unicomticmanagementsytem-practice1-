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
    public partial class PasswordSetupForm : Form
    {
        public PasswordSetupForm(string username, string role, string systemPassword)
        {     
            InitializeComponent();
            Name = username;
            Username.Text = role;
            GivenPassword.Text = systemPassword;

            Username.Text = Name;
            Username.ReadOnly = true;

            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);

        }

        private void PasswordSetupForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string enteredGiven = GivenPassword.Text;
            string newPass = NewPassword.Text;
            string confirmPass = ConfirmPassword.Text;

            if (enteredGiven != GivenPassword.Text)
            {
                MessageBox.Show("Incorrect system-generated password.");
                return;
            }

            if (string.IsNullOrWhiteSpace(newPass) || newPass.Length < 4)
            {
                MessageBox.Show("New password must be at least 4 characters.");
                return;
            }

            if (newPass != confirmPass)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            using (var con = DatabaseConfiguration.GetConnection())
            {
                string updateQuery = @"UPDATE users 
                                       SET password = @newPass, isActivated = 1 
                                       WHERE username = @username AND role = @role";

                using (var cmd = new SQLiteCommand(updateQuery, con))
                {
                    cmd.Parameters.AddWithValue("@newPass", newPass);
                    cmd.Parameters.AddWithValue("@username", Username);
                    cmd.Parameters.AddWithValue("@role", Username.Text
                        );

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Password set successfully! You can now log in.");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to update password.");
                    }
                }
            }
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            GivenPassword.Clear();
            NewPassword.Clear();
            ConfirmPassword.Clear();
        }
    }
}
