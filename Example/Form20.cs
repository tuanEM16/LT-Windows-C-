using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example
{
    public partial class Form20 : Form
    {
        // Khai báo đối tượng
        PictureBox pbBall = new PictureBox();
        PictureBox pbPaddle = new PictureBox();
        System.Windows.Forms.Timer tmGame = new System.Windows.Forms.Timer();

        // Biến trạng thái di chuyển (Để sửa lỗi Delay)
        bool goLeft = false;  // Đang giữ phím Trái?
        bool goRight = false; // Đang giữ phím Phải?

        // Thông số game
        int xBall = 50;
        int yBall = 50;
        int xDelta = 7;
        int yDelta = 7;
        int paddleSpeed = 15; // Tốc độ thanh hứng

        public Form20()
        {
            InitializeComponent();

            // Chống giật hình (Flicker) cho Form
            this.DoubleBuffered = true;
        }

        private void Form20_Load(object sender, EventArgs e)
        {
            // --- 1. Cấu hình Giao diện ---
            this.BackColor = Color.Black; // Nền đen
            this.KeyPreview = true;       // Bắt buộc để nhận phím
            this.Bounds = new Rectangle(0, 0, 800, 500); // Kích thước form cố định

            // --- 2. Tạo Bóng ---
            pbBall.Size = new Size(20, 20);
            pbBall.Location = new Point(xBall, yBall);
            pbBall.BackColor = Color.Yellow; // Bóng vàng cho nổi trên nền đen
            // Vẽ bóng tròn
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 20, 20);
            pbBall.Region = new Region(path);
            this.Controls.Add(pbBall);

            // --- 3. Tạo Thanh Hứng ---
            pbPaddle.Size = new Size(120, 15);
            pbPaddle.BackColor = Color.White; // Thanh màu trắng
            pbPaddle.Location = new Point((this.ClientSize.Width - pbPaddle.Width) / 2, this.ClientSize.Height - 40);
            this.Controls.Add(pbPaddle);

            // --- 4. Cấu hình Timer ---
            tmGame.Interval = 15; // 15ms (khoảng 60 FPS) cho mượt
            tmGame.Tick += new EventHandler(tmGame_Tick);
            tmGame.Start();
        }

        // Vòng lặp chính của Game (Chạy liên tục 60 lần/giây)
        void tmGame_Tick(object sender, EventArgs e)
        {
            // --- A. XỬ LÝ DI CHUYỂN THANH HỨNG (Ở ĐÂY SẼ MƯỢT HƠN) ---
            if (goLeft == true && pbPaddle.Left > 0)
            {
                pbPaddle.Left -= paddleSpeed;
            }
            if (goRight == true && pbPaddle.Right < this.ClientSize.Width)
            {
                pbPaddle.Left += paddleSpeed;
            }

            // --- B. XỬ LÝ BÓNG ---
            xBall += xDelta;
            yBall += yDelta;

            // 1. Va chạm tường trái/phải
            if (xBall <= 0 || xBall >= this.ClientSize.Width - pbBall.Width)
            {
                xDelta = -xDelta;
            }

            // 2. Va chạm tường trên
            if (yBall <= 0)
            {
                yDelta = -yDelta;
            }

            // 3. Va chạm với Thanh Hứng
            if (pbBall.Bounds.IntersectsWith(pbPaddle.Bounds))
            {
                yDelta = -yDelta; // Nảy lên
                yBall = pbPaddle.Top - pbBall.Height - 2; // Đẩy bóng ra khỏi thanh để tránh kẹt

                // Tăng tốc độ game mỗi lần đỡ trúng cho kịch tính (Tùy chọn)
                // if (xDelta > 0) xDelta++; else xDelta--;
            }

            // 4. Game Over (Rơi xuống đáy)
            if (yBall > this.ClientSize.Height)
            {
                tmGame.Stop();
                DialogResult lr = MessageBox.Show("Game Over! Chơi lại không?", "Thua rồi", MessageBoxButtons.YesNo);
                if (lr == DialogResult.Yes)
                {
                    // Reset game
                    xBall = 50; yBall = 50; xDelta = 7; yDelta = 7;
                    tmGame.Start();
                }
                else
                {
                    this.Close();
                }
            }

            // Cập nhật vị trí bóng
            pbBall.Location = new Point(xBall, yBall);
        }

        // Sự kiện: KHI NHẤN PHÍM XUỐNG
        private void Form20_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
        }

        // Sự kiện: KHI NHẢ PHÍM RA (RẤT QUAN TRỌNG)
        private void Form20_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
        }
    }
}