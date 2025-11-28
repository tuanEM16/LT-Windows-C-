namespace Example
{
    partial class Form4
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
            this.bt_OK = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // bt_OK
            // 
            this.bt_OK.Location = new System.Drawing.Point(362, 210);
            this.bt_OK.Name = "bt_OK";
            this.bt_OK.Size = new System.Drawing.Size(94, 29);
            this.bt_OK.TabIndex = 0;
            this.bt_OK.Text = "ok";
            this.bt_OK.UseVisualStyleBackColor = true;
            // QUAN TRỌNG: Kết nối sự kiện Click
            this.bt_OK.Click += new System.EventHandler(this.bt_OK_Click);

            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);

            // QUAN TRỌNG: Thêm nút vào Form mới hiện lên được
            this.Controls.Add(this.bt_OK);

            this.Name = "Form4";
            this.Text = "Form4";

            // QUAN TRỌNG: Bật chế độ bắt phím cho KeyLogger
            this.KeyPreview = true;

            // QUAN TRỌNG: Kết nối sự kiện KeyUp
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form4_KeyUp);

            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button bt_OK;
    }
}