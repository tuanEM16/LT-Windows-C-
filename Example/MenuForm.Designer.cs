namespace Example
{
    partial class MenuForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();

            // 
            // Tiêu đề
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(480, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TỔNG HỢP BÀI TẬP WINDOWS FORM";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // Panel chứa nút (Tự động xếp hàng)
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 50);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(20);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(480, 400);
            this.flowLayoutPanel1.TabIndex = 1;

            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.lblTitle);
            this.Name = "MenuForm";
            this.Text = "Main Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}