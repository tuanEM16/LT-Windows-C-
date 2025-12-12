namespace Example
{
    partial class Form18
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.tmStopwatch = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();

            // 
            // lblDisplay (Hiển thị giờ)
            // 
            this.lblDisplay.AutoSize = true;
            this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(80, 50);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(200, 73);
            this.lblDisplay.TabIndex = 0;
            this.lblDisplay.Text = "00:00"; // Giá trị ban đầu

            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(90, 160);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(100, 40);
            this.btStart.TabIndex = 1;
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);

            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(210, 160);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(100, 40);
            this.btStop.TabIndex = 2;
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);

            // 
            // tmStopwatch (Đồng hồ ngầm)
            // 
            this.tmStopwatch.Interval = 1000; // 1000ms = 1 giây (Theo Slide 159)
            this.tmStopwatch.Tick += new System.EventHandler(this.tmStopwatch_Tick);

            // 
            // Form18
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 250);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lblDisplay);
            this.Name = "Form18";
            this.Text = "Article 24: Timer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Timer tmStopwatch;
    }
}