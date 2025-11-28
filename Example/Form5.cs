using System;
using System.Drawing; // <--- Cần thêm cái này để dùng được "Size"
using System.Windows.Forms;

namespace Example
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        // Sự kiện khi bấm nút OK (Theo Slide 56)
        private void bt_OK_Click(object sender, EventArgs e)
        {
            // Đổi tiêu đề cửa sổ
            this.Text = "Article for Button";

            // Đổi kích thước cửa sổ thành 500x500
            this.Size = new Size(500, 500);
        }
    }
}