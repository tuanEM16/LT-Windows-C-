using System;
using System.Drawing;
using System.Windows.Forms;

namespace Example
{
    public partial class Form22 : Form
    {
        // Khai báo đối tượng
        PictureBox pbEgg = new PictureBox();
        PictureBox pbBasket = new PictureBox();
        System.Windows.Forms.Timer tmGame = new System.Windows.Forms.Timer();
        Label lblScore = new Label();

        int xEgg = 300;
        int yEgg = 0;
        int yDelta = 5;

        int xBasket = 300;
        int yBasket = 500;
        int xDeltaBasket = 25; // Tăng tốc độ rổ lên chút cho dễ hứng

        int score = 0;

        public Form22()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Chống giật
        }

        private void Form22_Load(object sender, EventArgs e)
        {
            // Cấu hình Form
            this.BackColor = Color.LightSkyBlue;
            this.KeyPreview = true;
            this.Size = new Size(600, 700); // Tăng chiều cao lên chút

            // --- 1. TẠO RỔ (Load ảnh) ---
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage; // Co giãn ảnh cho vừa khung
            pbBasket.Size = new Size(120, 80);
            yBasket = this.ClientSize.Height - 100;
            pbBasket.Location = new Point(xBasket, yBasket);
            pbBasket.BackColor = Color.Transparent; // Nền trong suốt

            // Load ảnh từ thư mục Images (Lùi ra 2 cấp thư mục để tìm)
            try
            {
                pbBasket.Image = Image.FromFile("Images/basket.png");
            }
            catch
            {
                pbBasket.BackColor = Color.OrangeRed; // Nếu lỗi ảnh thì dùng màu cũ
            }
            this.Controls.Add(pbBasket);

            // --- 2. TẠO TRỨNG (Load ảnh) ---
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(50, 70);
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Transparent;

            try
            {
                pbEgg.Image = Image.FromFile("Images/egg_gold.png");
            }
            catch
            {
                pbEgg.BackColor = Color.Gold; // Nếu lỗi ảnh thì dùng màu cũ
            }
            this.Controls.Add(pbEgg);

            // --- 3. BẢNG ĐIỂM ---
            lblScore.Text = "Score: 0";
            lblScore.Font = new Font("Arial", 16, FontStyle.Bold);
            lblScore.Location = new Point(10, 10);
            lblScore.AutoSize = true;
            this.Controls.Add(lblScore);

            // --- 4. TIMER ---
            tmGame.Interval = 20;
            tmGame.Tick += new EventHandler(tmGame_Tick);
            tmGame.Start();
        }

        void tmGame_Tick(object sender, EventArgs e)
        {
            // Trứng rơi
            yEgg += yDelta;
            pbEgg.Location = new Point(xEgg, yEgg);

            // --- HỨNG TRÚNG ---
            if (pbEgg.Bounds.IntersectsWith(pbBasket.Bounds))
            {
                score++;
                lblScore.Text = "Score: " + score;
                if (score % 5 == 0) yDelta += 2; // Tăng độ khó

                ResetEgg(); // Sinh trứng mới
            }

            // --- RƠI XUỐNG ĐẤT (VỠ) ---
            if (yEgg > this.ClientSize.Height - pbEgg.Height)
            {
                tmGame.Stop();

                // Đổi hình trứng vỡ (Slide 169)
                try
                {
                    pbEgg.Image = Image.FromFile("Images/egg_gold_broken.png");
                }
                catch
                {
                    pbEgg.BackColor = Color.Red;
                }

                DialogResult res = MessageBox.Show("Trứng vỡ rồi!\nĐiểm: " + score + "\nChơi lại?", "Game Over", MessageBoxButtons.YesNo);
                if (res == DialogResult.Yes)
                {
                    // Reset game
                    score = 0; yDelta = 5; lblScore.Text = "Score: 0";

                    // Đổi lại hình trứng nguyên vẹn
                    try
                    {
                        pbEgg.Image = Image.FromFile("Images/egg_gold.png");
                    }
                    catch { pbEgg.BackColor = Color.Gold; }

                    ResetEgg();
                    tmGame.Start();
                }
                else
                {
                    this.Close();
                }
            }
        }

        void ResetEgg()
        {
            yEgg = 0;
            Random rnd = new Random();
            xEgg = rnd.Next(0, this.ClientSize.Width - pbEgg.Width);
            pbEgg.Location = new Point(xEgg, yEgg);
        }

        private void Form22_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right && pbBasket.Right < this.ClientSize.Width)
                xBasket += xDeltaBasket;

            if (e.KeyCode == Keys.Left && pbBasket.Left > 0)
                xBasket -= xDeltaBasket;

            pbBasket.Location = new Point(xBasket, yBasket);
        }
    }
}