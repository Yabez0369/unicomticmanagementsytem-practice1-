namespace UnicomManageProject.Views
{
    partial class LecturerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvmarks = new System.Windows.Forms.DataGridView();
            this.dgvtt = new System.Windows.Forms.DataGridView();
            this.dgvprofile = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.editmarksbtn = new System.Windows.Forms.Button();
            this.editttbtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.viewnoticebtn = new System.Windows.Forms.Button();
            this.viewmarksbtn = new System.Windows.Forms.Button();
            this.viewttbtn = new System.Windows.Forms.Button();
            this.viewprofile = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprofile)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 100);
            this.panel2.TabIndex = 68;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Stencil", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(512, 34);
            this.label4.TabIndex = 0;
            this.label4.Text = "UNICOM TIC MANAGEMENT SYSTEM";
            // 
            // dgvmarks
            // 
            this.dgvmarks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmarks.Location = new System.Drawing.Point(298, 423);
            this.dgvmarks.Name = "dgvmarks";
            this.dgvmarks.Size = new System.Drawing.Size(568, 150);
            this.dgvmarks.TabIndex = 81;
            // 
            // dgvtt
            // 
            this.dgvtt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtt.Location = new System.Drawing.Point(298, 251);
            this.dgvtt.Name = "dgvtt";
            this.dgvtt.Size = new System.Drawing.Size(568, 150);
            this.dgvtt.TabIndex = 80;
            // 
            // dgvprofile
            // 
            this.dgvprofile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvprofile.Location = new System.Drawing.Point(298, 156);
            this.dgvprofile.Name = "dgvprofile";
            this.dgvprofile.Size = new System.Drawing.Size(576, 74);
            this.dgvprofile.TabIndex = 79;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.editmarksbtn);
            this.panel1.Controls.Add(this.editttbtn);
            this.panel1.Controls.Add(this.closebtn);
            this.panel1.Controls.Add(this.viewnoticebtn);
            this.panel1.Controls.Add(this.viewmarksbtn);
            this.panel1.Controls.Add(this.viewttbtn);
            this.panel1.Controls.Add(this.viewprofile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 561);
            this.panel1.TabIndex = 78;
            // 
            // editmarksbtn
            // 
            this.editmarksbtn.Location = new System.Drawing.Point(12, 365);
            this.editmarksbtn.Name = "editmarksbtn";
            this.editmarksbtn.Size = new System.Drawing.Size(196, 23);
            this.editmarksbtn.TabIndex = 6;
            this.editmarksbtn.Text = "MANAGE MARKS";
            this.editmarksbtn.UseVisualStyleBackColor = true;
            this.editmarksbtn.Click += new System.EventHandler(this.editmarksbtn_Click);
            // 
            // editttbtn
            // 
            this.editttbtn.Location = new System.Drawing.Point(12, 197);
            this.editttbtn.Name = "editttbtn";
            this.editttbtn.Size = new System.Drawing.Size(196, 23);
            this.editttbtn.TabIndex = 5;
            this.editttbtn.Text = "MANAGE TIMETABLE";
            this.editttbtn.UseVisualStyleBackColor = true;
            this.editttbtn.Click += new System.EventHandler(this.editttbtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.Location = new System.Drawing.Point(12, 490);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(196, 23);
            this.closebtn.TabIndex = 4;
            this.closebtn.Text = "BACK";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // viewnoticebtn
            // 
            this.viewnoticebtn.Location = new System.Drawing.Point(12, 450);
            this.viewnoticebtn.Name = "viewnoticebtn";
            this.viewnoticebtn.Size = new System.Drawing.Size(196, 23);
            this.viewnoticebtn.TabIndex = 3;
            this.viewnoticebtn.Text = "VIEW DASHBOARD";
            this.viewnoticebtn.UseVisualStyleBackColor = true;
            this.viewnoticebtn.Click += new System.EventHandler(this.viewnoticebtn_Click);
            // 
            // viewmarksbtn
            // 
            this.viewmarksbtn.Location = new System.Drawing.Point(12, 323);
            this.viewmarksbtn.Name = "viewmarksbtn";
            this.viewmarksbtn.Size = new System.Drawing.Size(196, 23);
            this.viewmarksbtn.TabIndex = 2;
            this.viewmarksbtn.Text = "VIEW MARKS";
            this.viewmarksbtn.UseVisualStyleBackColor = true;
            this.viewmarksbtn.Click += new System.EventHandler(this.viewmarksbtn_Click);
            // 
            // viewttbtn
            // 
            this.viewttbtn.Location = new System.Drawing.Point(12, 151);
            this.viewttbtn.Name = "viewttbtn";
            this.viewttbtn.Size = new System.Drawing.Size(196, 23);
            this.viewttbtn.TabIndex = 1;
            this.viewttbtn.Text = "VIEW TIMETABLE";
            this.viewttbtn.UseVisualStyleBackColor = true;
            this.viewttbtn.Click += new System.EventHandler(this.viewttbtn_Click);
            // 
            // viewprofile
            // 
            this.viewprofile.Location = new System.Drawing.Point(12, 47);
            this.viewprofile.Name = "viewprofile";
            this.viewprofile.Size = new System.Drawing.Size(196, 23);
            this.viewprofile.TabIndex = 0;
            this.viewprofile.Text = "VIEW PROFILE";
            this.viewprofile.UseVisualStyleBackColor = true;
            this.viewprofile.Click += new System.EventHandler(this.viewprofile_Click);
            // 
            // LecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.dgvmarks);
            this.Controls.Add(this.dgvtt);
            this.Controls.Add(this.dgvprofile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "LecturerForm";
            this.Text = "LecturerForm";
            this.Load += new System.EventHandler(this.LecturerForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvprofile)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvmarks;
        private System.Windows.Forms.DataGridView dgvtt;
        private System.Windows.Forms.DataGridView dgvprofile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button editmarksbtn;
        private System.Windows.Forms.Button editttbtn;
        private System.Windows.Forms.Button closebtn;
        private System.Windows.Forms.Button viewnoticebtn;
        private System.Windows.Forms.Button viewmarksbtn;
        private System.Windows.Forms.Button viewttbtn;
        private System.Windows.Forms.Button viewprofile;
    }
}