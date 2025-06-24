using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnicomManageProject.Views
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void mngnoticebtn_Click(object sender, EventArgs e)
        {
            new NoticeForm().ShowDialog();
        }

        private void mngattendacebtn_Click(object sender, EventArgs e)
        {
            new ManageAttendanceForm().ShowDialog();
        }

        private void mngstudentbtn_Click(object sender, EventArgs e)
        {
            new ManageStudentForm().ShowDialog();
        }

        private void mngstaffbtn_Click(object sender, EventArgs e)
        {
            new ManageStaffForm().ShowDialog();
        }

        private void mnglecturerbtn_Click(object sender, EventArgs e)
        {
            new ManageLecturerForm().ShowDialog();
        }

        private void mngcoursebtn_Click(object sender, EventArgs e)
        {
            new ManageCourseForm().ShowDialog();
        }

        private void mngexambtn_Click(object sender, EventArgs e)
        {
            //new ManageExamForm().ShowDialog();
        }

        private void mngmarksbtn_Click(object sender, EventArgs e)
        {
            new ManageMarksForm().ShowDialog();
        }

        private void mngttbtn_Click(object sender, EventArgs e)
        {
            new ManageTimetableForm().ShowDialog();
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
