using System;
using System.Windows.Forms;

namespace Example
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        // Sự kiện khi Form vừa mở lên (Slide 96)
        private void Form10_Load(object sender, EventArgs e)
        {
            // Chọn sẵn mục thứ 3 (Index = 2) là "Quản trị kinh doanh"
            cb_Faculty.SelectedIndex = 2;
        }

        // Sự kiện khi thay đổi lựa chọn trong Combobox (Slide 96)
        private void cb_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cb_Faculty.SelectedIndex; // Lấy số thứ tự (bắt đầu từ 0)
            tbDisplay.Text = "Bạn đã chọn khoa thứ: " + index.ToString();
        }

        // Sự kiện bấm nút OK (Slide 96)
        private void btOK_Click(object sender, EventArgs e)
        {
            // Lấy nội dung chữ của mục đang chọn
            var item = cb_Faculty.SelectedItem;
            if (item != null)
            {
                tbDisplay.Text = "Bạn là sinh viên khoa: " + item.ToString();
            }
        }

        // Sự kiện bấm nút Clear (Xóa)
        private void btClear_Click(object sender, EventArgs e)
        {
            tbDisplay.Clear();
        }
    }
}