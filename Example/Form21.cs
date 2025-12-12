using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example
{
    public partial class Form21 : Form
    {
        // Khai báo đối tượng (Slide 167)
        PictureBox pbEgg = new PictureBox();
        System.Windows.Forms.Timer tmEgg = new System.Windows.Forms.Timer();

        // Tọa độ và tốc độ
        int xEgg = 300; // Vị trí ngang ban đầu
        int yEgg = 0;   // Vị trí dọc (bắt đầu từ trên đỉnh)
        int yDelta = 5; // Tốc độ rơi (càng lớn rơi càng nhanh)

        public Form21()
        {
            InitializeComponent();
        }

        private void Form21_Load(object sender, EventArgs e)
        {
            // 1. Cấu hình Timer
            tmEgg.Interval = 20;
            tmEgg.Tick += new EventHandler(tmEgg_Tick);
            tmEgg.Start();

            // 2. Cấu hình Quả Trứng
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(50, 70); // Chỉnh chiều cao 70 cho giống trứng (thon dài)
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Gold;

            // --- MỚI THÊM: CẮT GỌT THÀNH HÌNH TRỨNG (BẦU DỤC) ---
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            // Vẽ hình elip nội tiếp khung hình chữ nhật
            path.AddEllipse(0, 0, pbEgg.Width, pbEgg.Height);
            // Gán vùng hiển thị (cắt bỏ phần thừa 4 góc)
            pbEgg.Region = new Region(path);
            // ----------------------------------------------------

            // Thêm trứng vào Form
            this.Controls.Add(pbEgg);
        }
        // Sự kiện Timer: Xử lý rơi (Slide 169)
        void tmEgg_Tick(object sender, EventArgs e)
        {
            // Cho trứng rơi xuống
            yEgg += yDelta;

            // Kiểm tra va chạm với đáy Form (Trứng vỡ)
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                // Dừng rơi
                tmEgg.Stop();

                // Đổi trạng thái thành "Vỡ" (Slide 169)
                pbEgg.BackColor = Color.Red; // Đổi màu thành Đỏ (máu me/vỡ)
                                             // pbEgg.Image = Image.FromFile(@"D:\egg_gold_broken.png"); // Hoặc đổi ảnh vỡ

                MessageBox.Show("Oop! Trứng đã vỡ.", "Game Over");

                // (Tùy chọn) Reset lại để chơi tiếp
                ResetGame();
            }

            // Cập nhật vị trí
            pbEgg.Location = new Point(xEgg, yEgg);
        }

        void ResetGame()
        {
            // Đưa trứng lên lại đỉnh
            yEgg = 0;
            // Random vị trí rơi cho thú vị
            Random rnd = new Random();
            xEgg = rnd.Next(0, this.ClientSize.Width - pbEgg.Width);

            pbEgg.BackColor = Color.Gold; // Trứng lành lặn lại
            tmEgg.Start(); // Rơi tiếp
        }
    }
}