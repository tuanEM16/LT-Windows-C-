using System;
using System.Drawing; // Thư viện xử lý ảnh
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Example
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        // Sự kiện bấm nút "Chọn ảnh..." (Slide 129)
        private void btFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            // Chỉ lọc các file ảnh
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            dlg.Title = "Chọn ảnh nhân viên";

            // Nếu người dùng chọn file và bấm OK
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Cách 1: Load trực tiếp từ file (Slide 129)
                pbImage.ImageLocation = dlg.FileName;

                // Chế độ hiển thị: Co giãn ảnh cho vừa khung
                pbImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}