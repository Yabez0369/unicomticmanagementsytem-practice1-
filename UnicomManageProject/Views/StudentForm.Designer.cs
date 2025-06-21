namespace UnicomManageProject.Views
{
    partial class StudentForm
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
            this.backbtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.marksbtn = new System.Windows.Forms.Button();
            this.ttbtn = new System.Windows.Forms.Button();
            this.profileviewbtn = new System.Windows.Forms.Button();
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
            this.panel2.TabIndex = 66;
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
            this.dgvmarks.Location = new System.Drawing.Point(287, 435);
            this.dgvmarks.Name = "dgvmarks";
            this.dgvmarks.Size = new System.Drawing.Size(568, 150);
            this.dgvmarks.TabIndex = 73;
            // 
            // dgvtt
            // 
            this.dgvtt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtt.Location = new System.Drawing.Point(287, 263);
            this.dgvtt.Name = "dgvtt";
            this.dgvtt.Size = new System.Drawing.Size(568, 150);
            this.dgvtt.TabIndex = 72;
            // 
            // dgvprofile
            // 
            this.dgvprofile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvprofile.Location = new System.Drawing.Point(287, 156);
            this.dgvprofile.Name = "dgvprofile";
            this.dgvprofile.Size = new System.Drawing.Size(576, 74);
            this.dgvprofile.TabIndex = 71;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.backbtn);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.marksbtn);
            this.panel1.Controls.Add(this.ttbtn);
            this.panel1.Controls.Add(this.profileviewbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 561);
            this.panel1.TabIndex = 70;
            // 
            // backbtn
            // 
            this.backbtn.Location = new System.Drawing.Point(12, 490);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(196, 23);
            this.backbtn.TabIndex = 4;
            this.backbtn.Text = "BACK";
            this.backbtn.UseVisualStyleBackColor = true;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 450);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(196, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "VIEW DASHBOARD";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // marksbtn
            // 
            this.marksbtn.Location = new System.Drawing.Point(0, 323);
            this.marksbtn.Name = "marksbtn";
            this.marksbtn.Size = new System.Drawing.Size(196, 23);
            this.marksbtn.TabIndex = 2;
            this.marksbtn.Text = "VIEW MARKS";
            this.marksbtn.UseVisualStyleBackColor = true;
            this.marksbtn.Click += new System.EventHandler(this.marksbtn_Click);
            // 
            // ttbtn
            // 
            this.ttbtn.Location = new System.Drawing.Point(12, 151);
            this.ttbtn.Name = "ttbtn";
            this.ttbtn.Size = new System.Drawing.Size(196, 23);
            this.ttbtn.TabIndex = 1;
            this.ttbtn.Text = "VIEW TIMETABLE";
            this.ttbtn.UseVisualStyleBackColor = true;
            this.ttbtn.Click += new System.EventHandler(this.ttbtn_Click);
            // 
            // profileviewbtn
            // 
            this.profileviewbtn.Location = new System.Drawing.Point(12, 56);
            this.profileviewbtn.Name = "profileviewbtn";
            this.profileviewbtn.Size = new System.Drawing.Size(196, 23);
            this.profileviewbtn.TabIndex = 0;
            this.profileviewbtn.Text = "VIEW PROFILE";
            this.profileviewbtn.UseVisualStyleBackColor = true;
            this.profileviewbtn.Click += new System.EventHandler(this.profileviewbtn_Click);
            // 
            // StudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.dgvmarks);
            this.Controls.Add(this.dgvtt);
            this.Controls.Add(this.dgvprofile);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "StudentForm";
            this.Text = "StudentForm";
            this.Load += new System.EventHandler(this.StudentForm_Load);
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
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button marksbtn;
        private System.Windows.Forms.Button ttbtn;
        private System.Windows.Forms.Button profileviewbtn;
    }
}