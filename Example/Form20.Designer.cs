namespace Example
{
    partial class Form20
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form20
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Name = "Form20";
            this.Text = "Bouncing Ball (Smooth Movement)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Gán các sự kiện
            this.Load += new System.EventHandler(this.Form20_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form20_KeyDown);

            // --- QUAN TRỌNG: GÁN SỰ KIỆN KEYUP ---
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form20_KeyUp);
            // -------------------------------------

            this.ResumeLayout(false);
        }
    }
}