namespace Example
{
    partial class FormGameRunner
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
            // FormGameRunner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "FormGameRunner";
            this.Text = "Game Vượt Chướng Ngại Vật";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // --- GÁN CÁC SỰ KIỆN QUAN TRỌNG ---
            this.Load += new System.EventHandler(this.FormGameRunner_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGameRunner_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormGameRunner_KeyUp);
            // ----------------------------------

            this.ResumeLayout(false);
        }
    }
}