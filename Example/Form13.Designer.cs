namespace Example
{
    partial class Form13
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDob = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFaculty = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbList = new System.Windows.Forms.ListBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();

            // Label & TextBox Tên
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 20); this.label1.Text = "Họ tên:";
            this.tbName.Location = new System.Drawing.Point(100, 17); this.tbName.Size = new System.Drawing.Size(250, 27);

            // DateTimePicker Ngày sinh (Slide 107)
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 60); this.label2.Text = "Ngày sinh:";
            this.dtpDob.Location = new System.Drawing.Point(100, 57);
            this.dtpDob.Size = new System.Drawing.Size(250, 27);
            this.dtpDob.Format = System.Windows.Forms.DateTimePickerFormat.Short; // Chỉ hiện ngày tháng năm

            // GroupBox Giới tính
            this.groupBox1.Controls.Add(this.rbFemale);
            this.groupBox1.Controls.Add(this.rbMale);
            this.groupBox1.Location = new System.Drawing.Point(100, 90); this.groupBox1.Size = new System.Drawing.Size(250, 60); this.groupBox1.Text = "Giới tính";

            this.rbMale.AutoSize = true; this.rbMale.Location = new System.Drawing.Point(20, 25); this.rbMale.Text = "Nam"; this.rbMale.Checked = true;
            this.rbFemale.AutoSize = true; this.rbFemale.Location = new System.Drawing.Point(120, 25); this.rbFemale.Text = "Nữ";

            // ComboBox Khoa
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 160); this.label3.Text = "Khoa:";
            this.cbFaculty.Location = new System.Drawing.Point(100, 157); this.cbFaculty.Size = new System.Drawing.Size(250, 28);
            this.cbFaculty.Items.AddRange(new object[] { "Công nghệ thông tin", "Kế toán", "Cơ khí", "Điện" });
            this.cbFaculty.SelectedIndex = 0;

            // ListBox Danh sách
            this.label4.AutoSize = true; this.label4.Location = new System.Drawing.Point(20, 200); this.label4.Text = "Danh sách:";
            this.lbList.Location = new System.Drawing.Point(100, 200); this.lbList.Size = new System.Drawing.Size(250, 120);

            // Buttons
            this.btAdd.Location = new System.Drawing.Point(100, 330); this.btAdd.Text = "Thêm"; this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            this.btExit.Location = new System.Drawing.Point(250, 330); this.btExit.Text = "Thoát"; this.btExit.Click += new System.EventHandler(this.btExit_Click);

            // Form Settings
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.btExit); this.Controls.Add(this.btAdd); this.Controls.Add(this.lbList);
            this.Controls.Add(this.label4); this.Controls.Add(this.cbFaculty); this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1); this.Controls.Add(this.dtpDob); this.Controls.Add(this.label2);
            this.Controls.Add(this.tbName); this.Controls.Add(this.label1);
            this.Name = "Form13"; this.Text = "Quản lý sinh viên";
            this.groupBox1.ResumeLayout(false); this.groupBox1.PerformLayout();
            this.ResumeLayout(false); this.PerformLayout();
        }
        private System.Windows.Forms.Label label1, label2, label3, label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.DateTimePicker dtpDob;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbMale, rbFemale;
        private System.Windows.Forms.ComboBox cbFaculty;
        private System.Windows.Forms.ListBox lbList;
        private System.Windows.Forms.Button btAdd, btExit;
    }
}