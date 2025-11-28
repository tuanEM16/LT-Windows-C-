namespace Example
{
    partial class Form6
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.btnCheck = new System.Windows.Forms.Button(); 
            this.SuspendLayout();

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Year";

            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(120, 47);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(200, 27);
            this.tbYear.TabIndex = 1;
            this.tbYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbYear_KeyPress);
            this.tbYear.Validating += new System.ComponentModel.CancelEventHandler(this.tbYear_Validating);

            // 
            // btnCheck (Nút này để bấm vào cho tbYear mất focus)
            // 
            this.btnCheck.Location = new System.Drawing.Point(120, 100);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(100, 30);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Kiểm tra";
            this.btnCheck.UseVisualStyleBackColor = true;

            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.btnCheck); // Nhớ thêm nút vào form
            this.Controls.Add(this.tbYear);
            this.Controls.Add(this.label1);
            this.Name = "Form6";
            this.Text = "Textbox Example";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbYear;
        private System.Windows.Forms.Button btnCheck;
    }
}