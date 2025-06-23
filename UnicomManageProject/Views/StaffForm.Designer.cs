namespace UnicomManageProject.Views
{
    partial class StaffForm
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
            this.edittimetablebtn = new System.Windows.Forms.Button();
            this.exitbtn = new System.Windows.Forms.Button();
            this.noticebtn = new System.Windows.Forms.Button();
            this.viewmarksbtn = new System.Windows.Forms.Button();
            this.viewttbtn = new System.Windows.Forms.Button();
            this.viewprofilebtn = new System.Windows.Forms.Button();
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
            this.panel2.TabIndex = 67;
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
            this.dgvmarks.Location = new System.Drawing.Point(287, 423);
            this.dgvmarks.Name = "dgvmarks";
            this.dgvmarks.Size = new System.Drawing.Size(568, 150);
            this.dgvmarks.TabIndex = 77;
            // 
            // dgvtt
            // 
            this.dgvtt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtt.Location = new System.Drawing.Point(287, 251);
            this.dgvtt.Name = "dgvtt";
            this.dgvtt.Size = new System.Drawing.Size(568, 150);
            this.dgvtt.TabIndex = 76;
            // 
            // dgvprofile
            // 
            this.dgvprofile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvprofile.Location = new System.Drawing.Point(287, 156);
            this.dgvprofile.Name = "dgvprofile";
            this.dgvprofile.Size = new System.Drawing.Size(576, 74);
            this.dgvprofile.TabIndex = 75;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.editmarksbtn);
            this.panel1.Controls.Add(this.edittimetablebtn);
            this.panel1.Controls.Add(this.exitbtn);
            this.panel1.Controls.Add(this.noticebtn);
            this.panel1.Controls.Add(this.viewmarksbtn);
            this.panel1.Controls.Add(this.viewttbtn);
            this.panel1.Controls.Add(this.viewprofilebtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 561);
            this.panel1.TabIndex = 74;
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
            // edittimetablebtn
            // 
            this.edittimetablebtn.Location = new System.Drawing.Point(12, 191);
            this.edittimetablebtn.Name = "edittimetablebtn";
            this.edittimetablebtn.Size = new System.Drawing.Size(196, 23);
            this.edittimetablebtn.TabIndex = 5;
            this.edittimetablebtn.Text = "MANAGE TIMETABLE";
            this.edittimetablebtn.UseVisualStyleBackColor = true;
            this.edittimetablebtn.Click += new System.EventHandler(this.edittimetablebtn_Click);
            // 
            // exitbtn
            // 
            this.exitbtn.Location = new System.Drawing.Point(12, 490);
            this.exitbtn.Name = "exitbtn";
            this.exitbtn.Size = new System.Drawing.Size(196, 23);
            this.exitbtn.TabIndex = 4;
            this.exitbtn.Text = "EXIT";
            this.exitbtn.UseVisualStyleBackColor = true;
            this.exitbtn.Click += new System.EventHandler(this.exitbtn_Click);
            // 
            // noticebtn
            // 
            this.noticebtn.Location = new System.Drawing.Point(12, 450);
            this.noticebtn.Name = "noticebtn";
            this.noticebtn.Size = new System.Drawing.Size(196, 23);
            this.noticebtn.TabIndex = 3;
            this.noticebtn.Text = "VIEW NOTICE";
            this.noticebtn.UseVisualStyleBackColor = true;
            this.noticebtn.Click += new System.EventHandler(this.noticebtn_Click);
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
            // viewprofilebtn
            // 
            this.viewprofilebtn.Location = new System.Drawing.Point(12, 47);
            this.viewprofilebtn.Name = "viewprofilebtn";
            this.viewprofilebtn.Size = new System.Drawing.Size(196, 23);
            this.viewprofilebtn.TabIndex = 0;
            this.viewprofilebtn.Text = "VIEW PROFILE";
            this.viewprofilebtn.UseVisualStyleBackColor = true;
            this.viewprofilebtn.Click += new System.EventHandler(this.viewprofilebtn_Click);
            // 
            // StaffForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.dgvmarks);
            this.Controls.Add(this.dgvtt);
            this.Controls.Add(this.dgvprofile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "StaffForm";
            this.Text = "StaffForm";
            this.Load += new System.EventHandler(this.StaffForm_Load);
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
        private System.Windows.Forms.Button edittimetablebtn;
        private System.Windows.Forms.Button exitbtn;
        private System.Windows.Forms.Button noticebtn;
        private System.Windows.Forms.Button viewmarksbtn;
        private System.Windows.Forms.Button viewttbtn;
        private System.Windows.Forms.Button viewprofilebtn;
    }
}