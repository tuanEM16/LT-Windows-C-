namespace Example
{
    partial class Form15
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbId = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.SuspendLayout();

            // Label Mã
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 20); this.label1.Text = "Mã nhân viên:";

            // TextBox Mã
            this.tbId.Location = new System.Drawing.Point(120, 17); this.tbId.Size = new System.Drawing.Size(200, 27);
            this.tbId.Text = "03152482001";

            // Label Tên
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(20, 60); this.label2.Text = "Tên nhân viên:";

            // TextBox Tên
            this.tbName.Location = new System.Drawing.Point(120, 57); this.tbName.Size = new System.Drawing.Size(200, 27);
            this.tbName.Text = "Nguyễn Văn Hùng";

            // Label Ảnh
            this.label3.AutoSize = true; this.label3.Location = new System.Drawing.Point(20, 100); this.label3.Text = "Ảnh 3x4:";

            // PictureBox (Khung ảnh)
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle; // Viền khung
            this.pbImage.Location = new System.Drawing.Point(120, 100);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(120, 160); // Kích thước ảnh 3x4
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;

            // Button Chọn ảnh
            this.btFile.Location = new System.Drawing.Point(250, 100);
            this.btFile.Name = "btFile";
            this.btFile.Size = new System.Drawing.Size(100, 35);
            this.btFile.Text = "Chọn ảnh...";
            this.btFile.Click += new System.EventHandler(this.btFile_Click);

            // Form Settings
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 300);
            this.Controls.Add(this.btFile);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form15";
            this.Text = "Quản lý nhân sự";
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label1, label2, label3;
        private System.Windows.Forms.TextBox tbId, tbName;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Button btFile;
    }
}