namespace Example
{
    partial class Form22
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
            // Form22
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 600);
            this.Name = "Form22";
            this.Text = "Game Catch Egg (Article 27)";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            // Gán sự kiện
            this.Load += new System.EventHandler(this.Form22_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form22_KeyDown);

            this.ResumeLayout(false);
        }
    }
}