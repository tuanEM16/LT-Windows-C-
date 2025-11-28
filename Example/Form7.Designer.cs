namespace Example
{
    partial class Form7
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblSoX = new System.Windows.Forms.Label();
            this.lblSoY = new System.Windows.Forms.Label();
            this.lblKetQua = new System.Windows.Forms.Label();
            this.tbSoX = new System.Windows.Forms.TextBox();
            this.tbSoY = new System.Windows.Forms.TextBox();
            this.tbKetQua = new System.Windows.Forms.TextBox();
            this.btCong = new System.Windows.Forms.Button();
            this.btNhan = new System.Windows.Forms.Button();
            this.btLuu = new System.Windows.Forms.Button();
            this.btThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // Label Số X
            // 
            this.lblSoX.AutoSize = true;
            this.lblSoX.Location = new System.Drawing.Point(30, 30);
            this.lblSoX.Name = "lblSoX";
            this.lblSoX.Size = new System.Drawing.Size(38, 20);
            this.lblSoX.TabIndex = 0;
            this.lblSoX.Text = "Số x";

            // 
            // Textbox Số X
            // 
            this.tbSoX.Location = new System.Drawing.Point(100, 27);
            this.tbSoX.Name = "tbSoX";
            this.tbSoX.Size = new System.Drawing.Size(450, 27);
            this.tbSoX.TabIndex = 1;

            // 
            // Label Số Y
            // 
            this.lblSoY.AutoSize = true;
            this.lblSoY.Location = new System.Drawing.Point(30, 70);
            this.lblSoY.Name = "lblSoY";
            this.lblSoY.Size = new System.Drawing.Size(38, 20);
            this.lblSoY.TabIndex = 2;
            this.lblSoY.Text = "Số y";

            // 
            // Textbox Số Y
            // 
            this.tbSoY.Location = new System.Drawing.Point(100, 67);
            this.tbSoY.Name = "tbSoY";
            this.tbSoY.Size = new System.Drawing.Size(450, 27);
            this.tbSoY.TabIndex = 3;

            // 
            // Label Kết quả
            // 
            this.lblKetQua.AutoSize = true;
            this.lblKetQua.Location = new System.Drawing.Point(30, 110);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(60, 20);
            this.lblKetQua.TabIndex = 4;
            this.lblKetQua.Text = "Kết quả";

            // 
            // Textbox Kết Quả (Multiline) - QUAN TRỌNG
            // 
            this.tbKetQua.Location = new System.Drawing.Point(100, 110);
            this.tbKetQua.Multiline = true; // Cho phép nhiều dòng
            this.tbKetQua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical; // Thêm thanh cuộn dọc
            this.tbKetQua.Name = "tbKetQua";
            this.tbKetQua.Size = new System.Drawing.Size(450, 250);
            this.tbKetQua.TabIndex = 5;

            // 
            // Button Lưu
            // 
            this.btLuu.Location = new System.Drawing.Point(30, 380);
            this.btLuu.Name = "btLuu";
            this.btLuu.Size = new System.Drawing.Size(90, 40);
            this.btLuu.TabIndex = 6;
            this.btLuu.Text = "Lưu";
            this.btLuu.UseVisualStyleBackColor = true;
            this.btLuu.Click += new System.EventHandler(this.btLuu_Click);

            // 
            // Button Cộng
            // 
            this.btCong.Location = new System.Drawing.Point(250, 380);
            this.btCong.Name = "btCong";
            this.btCong.Size = new System.Drawing.Size(90, 40);
            this.btCong.TabIndex = 7;
            this.btCong.Text = "Cộng";
            this.btCong.UseVisualStyleBackColor = true;
            this.btCong.Click += new System.EventHandler(this.btCong_Click);

            // 
            // Button Nhân
            // 
            this.btNhan.Location = new System.Drawing.Point(350, 380);
            this.btNhan.Name = "btNhan";
            this.btNhan.Size = new System.Drawing.Size(90, 40);
            this.btNhan.TabIndex = 8;
            this.btNhan.Text = "Nhân";
            this.btNhan.UseVisualStyleBackColor = true;
            this.btNhan.Click += new System.EventHandler(this.btNhan_Click);

            // 
            // Button Thoát
            // 
            this.btThoat.Location = new System.Drawing.Point(450, 380);
            this.btThoat.Name = "btThoat";
            this.btThoat.Size = new System.Drawing.Size(90, 40);
            this.btThoat.TabIndex = 9;
            this.btThoat.Text = "Thoát";
            this.btThoat.UseVisualStyleBackColor = true;
            this.btThoat.Click += new System.EventHandler(this.btThoat_Click);

            // 
            // Form7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);

            // Cấu hình Form theo Slide 69
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog; // Không cho chỉnh size viền
            this.MaximizeBox = false; // Tắt nút phóng to
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Hiện giữa màn hình

            this.Controls.Add(this.btThoat);
            this.Controls.Add(this.btNhan);
            this.Controls.Add(this.btCong);
            this.Controls.Add(this.btLuu);
            this.Controls.Add(this.tbKetQua);
            this.Controls.Add(this.tbSoY);
            this.Controls.Add(this.tbSoX);
            this.Controls.Add(this.lblKetQua);
            this.Controls.Add(this.lblSoY);
            this.Controls.Add(this.lblSoX);
            this.Name = "Form7";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblSoX;
        private System.Windows.Forms.Label lblSoY;
        private System.Windows.Forms.Label lblKetQua;
        private System.Windows.Forms.TextBox tbSoX;
        private System.Windows.Forms.TextBox tbSoY;
        private System.Windows.Forms.TextBox tbKetQua;
        private System.Windows.Forms.Button btCong;
        private System.Windows.Forms.Button btNhan;
        private System.Windows.Forms.Button btLuu;
        private System.Windows.Forms.Button btThoat;
    }
}