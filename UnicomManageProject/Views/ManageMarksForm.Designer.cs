namespace UnicomManageProject.Views
{
    partial class ManageMarksForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.backbtn = new System.Windows.Forms.Button();
            this.clearbtn = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.dltbtn = new System.Windows.Forms.Button();
            this.Addbtn = new System.Windows.Forms.Button();
            this.dgvmarkslist = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.subjectcombobox = new System.Windows.Forms.ComboBox();
            this.examcombobox = new System.Windows.Forms.ComboBox();
            this.scorecombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvmarkslist)).BeginInit();
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 137;
            this.label3.Text = "Score";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("MS Reference Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(288, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(223, 29);
            this.label7.TabIndex = 133;
            this.label7.Text = "MANAGE MARKS";
            // 
            // backbtn
            // 
            this.backbtn.Location = new System.Drawing.Point(217, 512);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 23);
            this.backbtn.TabIndex = 132;
            this.backbtn.Text = "BACK";
            this.backbtn.UseVisualStyleBackColor = true;
            // 
            // clearbtn
            // 
            this.clearbtn.Location = new System.Drawing.Point(118, 512);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(75, 23);
            this.clearbtn.TabIndex = 131;
            this.clearbtn.Text = "CLEAR";
            this.clearbtn.UseVisualStyleBackColor = true;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Location = new System.Drawing.Point(271, 449);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(75, 23);
            this.updatebtn.TabIndex = 130;
            this.updatebtn.Text = "UPDATE";
            this.updatebtn.UseVisualStyleBackColor = true;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // dltbtn
            // 
            this.dltbtn.Location = new System.Drawing.Point(171, 449);
            this.dltbtn.Name = "dltbtn";
            this.dltbtn.Size = new System.Drawing.Size(75, 23);
            this.dltbtn.TabIndex = 129;
            this.dltbtn.Text = "DELETE";
            this.dltbtn.UseVisualStyleBackColor = true;
            this.dltbtn.Click += new System.EventHandler(this.dltbtn_Click);
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(70, 449);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbtn.TabIndex = 128;
            this.Addbtn.Text = "ADD";
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // dgvmarkslist
            // 
            this.dgvmarkslist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvmarkslist.Location = new System.Drawing.Point(389, 185);
            this.dgvmarkslist.Name = "dgvmarkslist";
            this.dgvmarkslist.Size = new System.Drawing.Size(465, 387);
            this.dgvmarkslist.TabIndex = 127;
            this.dgvmarkslist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvmarkslist_CellContentClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(543, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 126;
            this.label5.Text = "MARKS LIST";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 125;
            this.label2.Text = "Exam Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(884, 100);
            this.panel2.TabIndex = 123;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(67, 274);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 138;
            this.label6.Text = "Subject Name";
            // 
            // subjectcombobox
            // 
            this.subjectcombobox.FormattingEnabled = true;
            this.subjectcombobox.Location = new System.Drawing.Point(171, 271);
            this.subjectcombobox.Name = "subjectcombobox";
            this.subjectcombobox.Size = new System.Drawing.Size(175, 21);
            this.subjectcombobox.TabIndex = 140;
            // 
            // examcombobox
            // 
            this.examcombobox.FormattingEnabled = true;
            this.examcombobox.Location = new System.Drawing.Point(171, 320);
            this.examcombobox.Name = "examcombobox";
            this.examcombobox.Size = new System.Drawing.Size(175, 21);
            this.examcombobox.TabIndex = 141;
            // 
            // scorecombobox
            // 
            this.scorecombobox.FormattingEnabled = true;
            this.scorecombobox.Location = new System.Drawing.Point(171, 367);
            this.scorecombobox.Name = "scorecombobox";
            this.scorecombobox.Size = new System.Drawing.Size(175, 21);
            this.scorecombobox.TabIndex = 142;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 143;
            this.label1.Text = "Student Name";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(171, 225);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(175, 20);
            this.textBox1.TabIndex = 144;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(70, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 145;
            this.label8.Text = "Student Id";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(171, 178);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(175, 20);
            this.textBox2.TabIndex = 146;
            // 
            // ManageMarksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 661);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scorecombobox);
            this.Controls.Add(this.examcombobox);
            this.Controls.Add(this.subjectcombobox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.dltbtn);
            this.Controls.Add(this.Addbtn);
            this.Controls.Add(this.dgvmarkslist);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel2);
            this.Name = "ManageMarksForm";
            this.Text = "ManageMarksForm";
            this.Load += new System.EventHandler(this.ManageMarksForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvmarkslist)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button backbtn;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button dltbtn;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.DataGridView dgvmarkslist;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox subjectcombobox;
        private System.Windows.Forms.ComboBox examcombobox;
        private System.Windows.Forms.ComboBox scorecombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
    }
}