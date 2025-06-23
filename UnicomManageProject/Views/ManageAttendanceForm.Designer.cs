namespace UnicomManageProject.Views
{
    partial class ManageAttendanceForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.ttDate = new System.Windows.Forms.DateTimePicker();
            this.statuscombobox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.backbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.dltbtn = new System.Windows.Forms.Button();
            this.Addbtn = new System.Windows.Forms.Button();
            this.dgvattendance = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.sunjectnamecombobox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvattendance)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            // ttDate
            // 
            this.ttDate.Location = new System.Drawing.Point(189, 323);
            this.ttDate.Name = "ttDate";
            this.ttDate.Size = new System.Drawing.Size(200, 20);
            this.ttDate.TabIndex = 120;
            // 
            // statuscombobox
            // 
            this.statuscombobox.FormattingEnabled = true;
            this.statuscombobox.Location = new System.Drawing.Point(189, 369);
            this.statuscombobox.Name = "statuscombobox";
            this.statuscombobox.Size = new System.Drawing.Size(175, 21);
            this.statuscombobox.TabIndex = 118;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(306, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(306, 29);
            this.label7.TabIndex = 116;
            this.label7.Text = "MANAGE ATTENDANCE";
            // 
            // backbtn
            // 
            this.backbtn.Location = new System.Drawing.Point(235, 540);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 23);
            this.backbtn.TabIndex = 115;
            this.backbtn.Text = "BACK";
            this.backbtn.UseVisualStyleBackColor = true;
            this.backbtn.Click += new System.EventHandler(this.backbtn_Click);
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(136, 540);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(75, 23);
            this.clearbtn.TabIndex = 114;
            this.clearbtn.Text = "CLEAR";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(289, 477);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(75, 23);
            this.updatebtn.TabIndex = 113;
            this.updatebtn.Text = "UPDATE";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // dltbtn
            // 
            this.dltbtn.Location = new System.Drawing.Point(189, 477);
            this.dltbtn.Name = "dltbtn";
            this.dltbtn.Size = new System.Drawing.Size(75, 23);
            this.dltbtn.TabIndex = 112;
            this.dltbtn.Text = "DELETE";
            this.dltbtn.UseVisualStyleBackColor = true;
            this.dltbtn.Click += new System.EventHandler(this.dltbtn_Click);
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(88, 477);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbtn.TabIndex = 111;
            this.Addbtn.Text = "ADD";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // dgvattendance
            // 
            this.dgvattendance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvattendance.Location = new System.Drawing.Point(407, 233);
            this.dgvattendance.Name = "dgvattendance";
            this.dgvattendance.Size = new System.Drawing.Size(465, 387);
            this.dgvattendance.TabIndex = 110;
            this.dgvattendance.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvattendance_CellContentClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 109;
            this.label6.Text = "Status";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(561, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 20);
            this.label5.TabIndex = 108;
            this.label5.Text = "ATTENDANCE LIST";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 329);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 107;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 106;
            this.label2.Text = "Subject Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 105;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 100);
            this.panel2.TabIndex = 104;
            // 
            // sunjectnamecombobox
            // 
            this.sunjectnamecombobox.FormattingEnabled = true;
            this.sunjectnamecombobox.Location = new System.Drawing.Point(189, 279);
            this.sunjectnamecombobox.Name = "sunjectnamecombobox";
            this.sunjectnamecombobox.Size = new System.Drawing.Size(175, 21);
            this.sunjectnamecombobox.TabIndex = 121;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(88, 245);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 122;
            this.label8.Text = "Student Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(189, 238);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 123;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(85, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 124;
            this.label9.Text = "Student ID";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(189, 203);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 20);
            this.textBox2.TabIndex = 125;
            // 
            // ManageAttendanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.sunjectnamecombobox);
            this.Controls.Add(this.ttDate);
            this.Controls.Add(this.statuscombobox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.dltbtn);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.dgvattendance);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Name = "ManageAttendanceForm";
            this.Text = "ManageAttendanceForm";
            this.Load += new System.EventHandler(this.ManageAttendanceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvattendance)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker ttDate;
        private System.Windows.Forms.ComboBox statuscombobox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button dltbtn;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.DataGridView dgvattendance;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox sunjectnamecombobox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
    }
}