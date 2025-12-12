using System;
using System.Drawing; // Cần thiết để dùng Point, Size
using System.Windows.Forms;

namespace Example
{
    public partial class Form19 : Form
    {
        // Khai báo biến toàn cục (Slide 153)
        PictureBox pb = new PictureBox();
        int x = 50; // Tọa độ ban đầu
        int y = 50;

        public Form19()
        {
            InitializeComponent();

            // --- TẠO PICTUREBOX BẰNG CODE (Slide 153) ---
            // Thay vì kéo thả, ta viết code để tạo control
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Size = new Size(150, 150);
            pb.Location = new Point(x, y);

            // Đường dẫn ảnh (Bạn nhớ đổi đường dẫn này thành file ảnh có thật trên máy bạn)
            // Ví dụ: @"C:\Windows\Web\Wallpaper\Windows\img0.jpg"
            try
            {
                pb.ImageLocation = @"D:\abc.jpg";
            }
            catch { } // Bỏ qua lỗi nếu không tìm thấy ảnh

            pb.BackColor = Color.Red; // Tô màu đỏ để dễ nhìn nếu chưa load được ảnh

            // Quan trọng: Thêm control vào Form
            this.Controls.Add(pb);
        }

        // Sự kiện nút Trái (Slide 154)
        private void btLeft_Click(object sender, EventArgs e)
        {
            x -= 10; // Giảm X để sang trái
            pb.Location = new Point(x, y);
        }

        // Sự kiện nút Phải (Slide 154)
        private void btRight_Click(object sender, EventArgs e)
        {
            x += 10; // Tăng X để sang phải
            pb.Location = new Point(x, y);
        }

        // Sự kiện chọn file ảnh (Bổ sung từ Slide 129/152 để game hoàn chỉnh hơn)
        private void btFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                pb.ImageLocation = dlg.FileName;
            }
        }
    }
}