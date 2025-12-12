using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example
{
    public partial class Form22 : Form
    {
        // --- KHAI BÁO CÁC ĐỐI TƯỢNG ---
        PictureBox pbEgg = new PictureBox();
        PictureBox pbBasket = new PictureBox();
        System.Windows.Forms.Timer tmGame = new System.Windows.Forms.Timer();
        Label lblScore = new Label(); // Hiển thị điểm số

        // Thông số Trứng
        int xEgg = 300;
        int yEgg = 0;
        int yDelta = 5; // Tốc độ rơi

        // Thông số Rổ
        int xBasket = 300;
        int yBasket = 500; // Vị trí gần đáy
        int xDeltaBasket = 20; // Tốc độ di chuyển rổ

        int score = 0;

        public Form22()
        {
            InitializeComponent();
            // Chống giật hình
            this.DoubleBuffered = true;
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            // Cấu hình Form
            this.BackColor = Color.LightSkyBlue; // Nền trời xanh
            this.KeyPreview = true; // Bắt buộc để nhận phím
            this.Size = new Size(600, 600);

            // 1. TẠO CÁI RỔ (Slide 173)
            pbBasket.Size = new Size(100, 40);
            yBasket = this.ClientSize.Height - 50; // Đặt sát đáy
            pbBasket.Location = new Point(xBasket, yBasket);
            pbBasket.BackColor = Color.OrangeRed; // Màu rổ
            // Nếu có ảnh: pbBasket.Image = Image.FromFile(@"D:\basket.png");
            this.Controls.Add(pbBasket);

            // 2. TẠO QUẢ TRỨNG (Slide 167 + Fix hình bầu dục)
            pbEgg.Size = new Size(40, 60);
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Gold;
            // Cắt hình bầu dục cho trứng
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pbEgg.Width, pbEgg.Height);
            pbEgg.Region = new Region(path);
            this.Controls.Add(pbEgg);

            // 3. TẠO BẢNG ĐIỂM
            lblScore.Text = "Score: 0";
            lblScore.Font = new Font("Arial", 16, FontStyle.Bold);
            lblScore.Location = new Point(10, 10);
            lblScore.AutoSize = true;
            this.Controls.Add(lblScore);

            // 4. CẤU HÌNH TIMER
            tmGame.Interval = 20;
            tmGame.Tick += new EventHandler(tmGame_Tick);
            tmGame.Start();
        }

        // --- XỬ LÝ LOGIC GAME (TIMER) ---
        void tmGame_Tick(object sender, EventArgs e)
        {
            // Trứng rơi xuống
            yEgg += yDelta;
            pbEgg.Location = new Point(xEgg, yEgg);

            // --- KIỂM TRA HỨNG TRÚNG (Va chạm) ---
            if (pbEgg.Bounds.IntersectsWith(pbBasket.Bounds))
            {
                score++; // Cộng điểm
                lblScore.Text = "Score: " + score;

                // Tăng độ khó: Cứ 5 điểm thì rơi nhanh hơn chút
                if (score % 5 == 0) yDelta += 1;

                ResetEgg(); // Sinh trứng mới
            }

            // --- KIỂM TRA HỨNG TRƯỢT (Chạm đất) ---
            if (yEgg > this.ClientSize.Height)
            {
                tmGame.Stop();
                DialogResult res = MessageBox.Show("Vỡ trứng rồi!\nĐiểm của bạn: " + score + "\nChơi lại không?", "Game Over", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    score = 0;
                    yDelta = 5; // Reset tốc độ
                    lblScore.Text = "Score: 0";
                    ResetEgg();
                    tmGame.Start();
                }
                else
                {
                    this.Close();
                }
            }
        }

        // Hàm sinh trứng lại từ trên đỉnh (Ngẫu nhiên vị trí ngang)
        void ResetEgg()
        {
            yEgg = 0;
            Random rnd = new Random();
            // Random X trong phạm vi màn hình
            xEgg = rnd.Next(0, this.ClientSize.Width - pbEgg.Width);
            pbEgg.Location = new Point(xEgg, yEgg);
        }

        // --- ĐIỀU KHIỂN RỔ (Slide 174) ---
        private void Form22_KeyDown(object sender, KeyEventArgs e)
        {
            // Qua Phải (Kiểm tra không cho chạy ra ngoài mép phải)
            if (e.KeyCode == Keys.Right && pbBasket.Right < this.ClientSize.Width)
            {
                xBasket += xDeltaBasket;
            }
            // Qua Trái (Kiểm tra không cho chạy ra ngoài mép trái)
            if (e.KeyCode == Keys.Left && pbBasket.Left > 0)
            {
                xBasket -= xDeltaBasket;
            }

            // Cập nhật vị trí rổ
            pbBasket.Location = new Point(xBasket, yBasket);
        }
    }
}