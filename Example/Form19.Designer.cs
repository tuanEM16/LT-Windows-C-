namespace Example
{
    partial class Form19
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btLeft = new System.Windows.Forms.Button();
            this.btRight = new System.Windows.Forms.Button();
            this.btFile = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // btLeft (Nút Qua Trái)
            // 
            this.btLeft.Location = new System.Drawing.Point(150, 300); // Đặt nút xuống dưới thấp
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(75, 40);
            this.btLeft.Text = "<< Trái";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);

            // 
            // btRight (Nút Qua Phải)
            // 
            this.btRight.Location = new System.Drawing.Point(250, 300);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(75, 40);
            this.btRight.Text = "Phải >>";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);

            // 
            // btFile (Nút Chọn Ảnh - Slide 152)
            // 
            this.btFile.Location = new System.Drawing.Point(350, 300);
            this.btFile.Name = "btFile";
            this.btFile.Size = new System.Drawing.Size(100, 40);
            this.btFile.Text = "Chọn Ảnh...";
            this.btFile.UseVisualStyleBackColor = true;
            this.btFile.Click += new System.EventHandler(this.btFile_Click);

            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.btFile);
            this.Controls.Add(this.btRight);
            this.Controls.Add(this.btLeft);
            this.Name = "Form19";
            this.Text = "Article 23: Move PictureBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.Button btFile;
    }
}