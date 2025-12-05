namespace Example
{
    partial class Form14
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.lbSong = new System.Windows.Forms.ListBox();
            this.lbFavorite = new System.Windows.Forms.ListBox();
            this.btSelect = new System.Windows.Forms.Button();
            this.btSelectAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // lbSong (Danh sách bài hát nguồn)
            this.lbSong.Location = new System.Drawing.Point(20, 40);
            this.lbSong.Size = new System.Drawing.Size(200, 300);
            this.lbSong.TabIndex = 0;
            // Double click để chọn (Slide 119)
            this.lbSong.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSong_MouseDoubleClick);

            // lbFavorite (Danh sách yêu thích)
            this.lbFavorite.Location = new System.Drawing.Point(300, 40);
            this.lbFavorite.Size = new System.Drawing.Size(200, 300);
            this.lbFavorite.TabIndex = 1;

            // Nút Chọn (>)
            this.btSelect.Location = new System.Drawing.Point(230, 100);
            this.btSelect.Size = new System.Drawing.Size(60, 40);
            this.btSelect.Text = ">";
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);

            // Nút Chọn Tất Cả (>>)
            this.btSelectAll.Location = new System.Drawing.Point(230, 150);
            this.btSelectAll.Size = new System.Drawing.Size(60, 40);
            this.btSelectAll.Text = ">>";
            this.btSelectAll.Click += new System.EventHandler(this.btSelectAll_Click);

            // Labels
            this.label1.AutoSize = true; this.label1.Location = new System.Drawing.Point(20, 15); this.label1.Text = "Danh sách bài hát";
            this.label2.AutoSize = true; this.label2.Location = new System.Drawing.Point(300, 15); this.label2.Text = "Bài hát ưa thích";

            // Form
            this.ClientSize = new System.Drawing.Size(530, 360);
            this.Controls.Add(this.label2); this.Controls.Add(this.label1);
            this.Controls.Add(this.btSelectAll); this.Controls.Add(this.btSelect);
            this.Controls.Add(this.lbFavorite); this.Controls.Add(this.lbSong);
            this.Name = "Form14"; this.Text = "Music Selector";
            this.Load += new System.EventHandler(this.Form14_Load);
            this.ResumeLayout(false); this.PerformLayout();
        }
        private System.Windows.Forms.ListBox lbSong, lbFavorite;
        private System.Windows.Forms.Button btSelect, btSelectAll;
        private System.Windows.Forms.Label label1, label2;
    }
}