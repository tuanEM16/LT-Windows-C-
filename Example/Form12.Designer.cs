namespace Example
{
    partial class Form12
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tbName = new System.Windows.Forms.TextBox();
            this.gbGender = new System.Windows.Forms.GroupBox();
            this.rbFemale = new System.Windows.Forms.RadioButton();
            this.rbMale = new System.Windows.Forms.RadioButton();
            this.ckDiscount = new System.Windows.Forms.CheckBox();
            this.tbDiscount = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btRun = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.gbGender.SuspendLayout();
            this.SuspendLayout();

            // tbName (Nhập tên)
            this.tbName.Location = new System.Drawing.Point(12, 12);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(260, 27);
            this.tbName.TabIndex = 0;
            this.tbName.Text = "Nguyễn Văn A";

            // gbGender (Nhóm giới tính)
            this.gbGender.Controls.Add(this.rbFemale);
            this.gbGender.Controls.Add(this.rbMale);
            this.gbGender.Location = new System.Drawing.Point(12, 50);
            this.gbGender.Name = "gbGender";
            this.gbGender.Size = new System.Drawing.Size(260, 80);
            this.gbGender.TabIndex = 1;
            this.gbGender.TabStop = false;
            this.gbGender.Text = "Giới tính";

            // rbMale
            this.rbMale.AutoSize = true;
            this.rbMale.Checked = true; // Mặc định chọn Nam
            this.rbMale.Location = new System.Drawing.Point(30, 30);
            this.rbMale.Name = "rbMale";
            this.rbMale.Size = new System.Drawing.Size(62, 24);
            this.rbMale.TabIndex = 0;
            this.rbMale.TabStop = true;
            this.rbMale.Text = "Nam";
            this.rbMale.UseVisualStyleBackColor = true;

            // rbFemale
            this.rbFemale.AutoSize = true;
            this.rbFemale.Location = new System.Drawing.Point(150, 30);
            this.rbFemale.Name = "rbFemale";
            this.rbFemale.Size = new System.Drawing.Size(50, 24);
            this.rbFemale.TabIndex = 1;
            this.rbFemale.Text = "Nữ";
            this.rbFemale.UseVisualStyleBackColor = true;

            // ckDiscount (Checkbox Giảm giá)
            this.ckDiscount.AutoSize = true;
            this.ckDiscount.Location = new System.Drawing.Point(12, 150);
            this.ckDiscount.Name = "ckDiscount";
            this.ckDiscount.Size = new System.Drawing.Size(92, 24);
            this.ckDiscount.TabIndex = 2;
            this.ckDiscount.Text = "Giảm giá";
            this.ckDiscount.UseVisualStyleBackColor = true;
            this.ckDiscount.CheckedChanged += new System.EventHandler(this.ckDiscount_CheckedChanged);

            // tbDiscount (Nhập % giảm)
            this.tbDiscount.Enabled = false; // Mặc định khóa
            this.tbDiscount.Location = new System.Drawing.Point(110, 148);
            this.tbDiscount.Name = "tbDiscount";
            this.tbDiscount.Size = new System.Drawing.Size(162, 27);
            this.tbDiscount.TabIndex = 3;

            // tbResult (Kết quả)
            this.tbResult.Location = new System.Drawing.Point(12, 190);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(260, 80);
            this.tbResult.TabIndex = 4;

            // btRun (Tính tiền)
            this.btRun.Location = new System.Drawing.Point(50, 290);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(90, 30);
            this.btRun.TabIndex = 5;
            this.btRun.Text = "Tính tiền";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btRun_Click);

            // btExit (Thoát)
            this.btExit.Location = new System.Drawing.Point(150, 290);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(90, 30);
            this.btExit.TabIndex = 6;
            this.btExit.Text = "Thoát";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);

            // Form12
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 340);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.tbDiscount);
            this.Controls.Add(this.ckDiscount);
            this.Controls.Add(this.gbGender);
            this.Controls.Add(this.tbName);
            this.Name = "Form12";
            this.Text = "RadioButton Checkbox";
            this.gbGender.ResumeLayout(false);
            this.gbGender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.GroupBox gbGender;
        private System.Windows.Forms.RadioButton rbMale;
        private System.Windows.Forms.RadioButton rbFemale;
        private System.Windows.Forms.CheckBox ckDiscount;
        private System.Windows.Forms.TextBox tbDiscount;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.Button btExit;
    }
}