using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media; // Thư viện âm thanh

namespace Example
{
    public partial class FormGameRunner : Form
    {
        // --- CẤU HÌNH GAME ---
        int formWidth = 1280;
        int formHeight = 720;
        int ceilingY = 50; int floorY = 620; int middleY = 330;

        // Đối tượng
        PictureBox player = new PictureBox();
        List<PictureBox> platforms = new List<PictureBox>();
        List<PictureBox> obstacles = new List<PictureBox>();

        System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        Random rand = new Random();
        Label lblInfo = new Label();
        Button btnRestart = new Button();

        // --- HỆ THỐNG TỐC ĐỘ ---
        float currentSpeed = 12f;
        float maxSpeed = 35f;
        int score = 0;

        // --- VẬT LÝ ---
        bool isGravityDown = true;
        bool isGrounded = false;
        int gravitySpeed = 25;
        int pushBackForce = 25;

        int spawnCounter = 0;
        bool isGameOver = false;

        // --- TÀI NGUYÊN (THÊM MỚI) ---
        Image gifImage;        // Ảnh Robot
        Image obstacleImgUp;   // Ảnh Tháp đứng
        Image obstacleImgDown; // Ảnh Tháp ngược

        SoundPlayer sndJump;
        SoundPlayer sndHit;
        SoundPlayer sndGameOver;
        SoundPlayer sndMusic;

        public FormGameRunner()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.KeyUp += new KeyEventHandler(FormGameRunner_KeyUp);
        }
        private void FormGameRunner_KeyUp(object sender, KeyEventArgs e) { }

        private void FormGameRunner_Load(object sender, EventArgs e)
        {
            // 1. CẤU HÌNH FORM
            this.ClientSize = new Size(formWidth, formHeight);
            this.BackColor = Color.FromArgb(20, 20, 40);
            this.Text = "Gravity Runner - Dynamic Patterns + Assets";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;

            // --- LOAD TÀI NGUYÊN (MỚI) ---
            LoadResourcesSafe();

            // 2. NHÂN VẬT
            player.Size = new Size(150, 80); // Giữ nguyên size nhân vật của bạn
            player.BackColor = Color.Transparent;
            player.SizeMode = PictureBoxSizeMode.Zoom; // Co giãn ảnh GIF cho đẹp
            player.Paint += Player_Paint;
            this.Controls.Add(player);
            player.BringToFront();

            // 3. UI
            lblInfo.ForeColor = Color.Lime;
            lblInfo.Font = new Font("Consolas", 14, FontStyle.Bold);
            lblInfo.Location = new Point(10, 10);
            lblInfo.AutoSize = true;
            this.Controls.Add(lblInfo);

            btnRestart.Text = "CHƠI LẠI";
            btnRestart.Size = new Size(200, 60);
            btnRestart.Font = new Font("Arial", 20, FontStyle.Bold);
            btnRestart.BackColor = Color.Orange;
            btnRestart.ForeColor = Color.White;
            btnRestart.FlatStyle = FlatStyle.Flat;
            btnRestart.Location = new Point((this.ClientSize.Width - btnRestart.Width) / 2,
                                            (this.ClientSize.Height - btnRestart.Height) / 2);
            btnRestart.Click += new EventHandler(btnRestart_Click);
            btnRestart.Visible = false;
            this.Controls.Add(btnRestart);

            StartNewGame();
        }

        // Hàm load tài nguyên an toàn (tránh crash nếu thiếu file)
        private void LoadResourcesSafe()
        {
            try
            {
                // Load Ảnh
                gifImage = Image.FromFile("Images/player.gif"); // Đổi tên file gif của bạn thành player.gif
                ImageAnimator.Animate(gifImage, (o, args) => { });

                Image tempTower = Image.FromFile("Images/tower.png"); // Đổi tên file tháp thành tower.png
                obstacleImgUp = (Image)tempTower.Clone();
                obstacleImgDown = (Image)tempTower.Clone();
                obstacleImgDown.RotateFlip(RotateFlipType.RotateNoneFlipY);

                // Load Âm Thanh
                sndJump = new SoundPlayer("Sounds/jump.wav");
                sndHit = new SoundPlayer("Sounds/hit.wav");
                sndGameOver = new SoundPlayer("Sounds/gameover.wav");
                sndMusic = new SoundPlayer("Sounds/music.wav");
            }
            catch { } // Lờ đi nếu lỗi file để game vẫn chạy
        }

        // Hàm phát nhạc an toàn
        private void PlaySoundSafe(SoundPlayer snd)
        {
            try { if (snd != null) snd.Play(); } catch { }
        }

        private void Player_Paint(object sender, PaintEventArgs e)
        {
            if (gifImage == null) return;
            ImageAnimator.UpdateFrames(gifImage);

            if (!isGravityDown)
            {
                e.Graphics.TranslateTransform(0, player.Height);
                e.Graphics.ScaleTransform(1, -1);
            }
            e.Graphics.DrawImage(gifImage, 0, 0, player.Width, player.Height);
        }

        private void StartNewGame()
        {
            isGameOver = false;
            isGravityDown = true;
            isGrounded = false;
            score = 0;
            currentSpeed = 12f;
            btnRestart.Visible = false;

            foreach (PictureBox p in platforms) this.Controls.Remove(p);
            foreach (PictureBox o in obstacles) this.Controls.Remove(o);
            platforms.Clear();
            obstacles.Clear();

            player.Location = new Point(200, floorY - player.Height);
            player.BringToFront();

            // Phát nhạc nền
            try { if (sndMusic != null) sndMusic.PlayLooping(); } catch { }

            // Đoạn đường đầu tiên luôn là "Đường Hầm" an toàn để chạy đà
            SpawnPattern(0, 2500, 1);

            gameTimer.Interval = 20;
            gameTimer.Tick -= GameLoop_Tick;
            gameTimer.Tick += GameLoop_Tick;
            gameTimer.Start();
            this.Focus();
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;
            player.Invalidate();

            // A. ĐIỂM SỐ
            score += (int)(currentSpeed / 5);
            if (currentSpeed < maxSpeed) currentSpeed += 0.005f;
            lblInfo.Text = $"SPEED: {Math.Round(currentSpeed)} | SCORE: {score}";

            // B. VẬT LÝ
            if (isGravityDown) player.Top += gravitySpeed;
            else player.Top -= gravitySpeed;

            // C. BÁM ĐƯỜNG
            CheckGroundedState();

            // D. RƠI VỰC
            if (!isGrounded)
            {
                if (player.Top > this.ClientSize.Height) { GameOver("Rớt vực thẳm!"); return; }
                if (player.Bottom < 0) { GameOver("Bay lên trời!"); return; }
            }

            // E. QUẢN LÝ MAP
            ManageMapAndObstacles();

            // F. HỒI PHỤC VỊ TRÍ
            if (isGrounded && player.Left < 200) player.Left += 3;

            if (player.Right < 0) GameOver("Bị đẩy lùi chết!");
        }

        private void CheckGroundedState()
        {
            isGrounded = false;
            int coreLeft = player.Left + 50;
            int coreRight = player.Right - 50;

            foreach (PictureBox plat in platforms)
            {
                if (coreRight > plat.Left && coreLeft < plat.Right)
                {
                    string type = plat.Tag.ToString();
                    if (isGravityDown && (type == "floor" || type == "middle"))
                    {
                        if (player.Bottom >= plat.Top && player.Bottom <= plat.Top + gravitySpeed + 5)
                        {
                            player.Top = plat.Top - player.Height;
                            isGrounded = true; return;
                        }
                    }
                    else if (!isGravityDown && (type == "ceiling" || type == "middle"))
                    {
                        if (player.Top <= plat.Bottom && player.Top >= plat.Bottom - gravitySpeed - 5)
                        {
                            player.Top = plat.Bottom;
                            isGrounded = true; return;
                        }
                    }
                }
            }
        }

        private void ManageMapAndObstacles()
        {
            int moveStep = (int)currentSpeed;

            // Di chuyển
            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                platforms[i].Left -= moveStep;
                if (platforms[i].Right < 0) { this.Controls.Remove(platforms[i]); platforms.RemoveAt(i); }
            }
            for (int i = obstacles.Count - 1; i >= 0; i--)
            {
                PictureBox obs = obstacles[i];
                obs.Left -= moveStep;

                Rectangle playerHitbox = new Rectangle(player.Left + 20, player.Top + 10, player.Width - 40, player.Height - 20);
                if (playerHitbox.IntersectsWith(obs.Bounds))
                {
                    player.Left -= pushBackForce;
                    // THÊM TIẾNG VA CHẠM (chỉ kêu khi chưa bị đẩy quá xa)
                    if (player.Left > 50) PlaySoundSafe(sndHit);
                }

                if (obs.Right < 0) { this.Controls.Remove(obs); obstacles.RemoveAt(i); }
            }

            // SINH MAP MỚI THEO MẪU (PATTERN) - GIỮ NGUYÊN LOGIC CỦA BẠN
            spawnCounter += moveStep;
            if (spawnCounter > 100)
            {
                if (platforms.Count > 0 && platforms[platforms.Count - 1].Right > this.Width + 100) return;
                spawnCounter = 0;

                int minGap = 160;
                int maxGap = 220;
                int gap = rand.Next(minGap, maxGap);
                int width = rand.Next(600, 1500); // Đường dài ngẫu nhiên

                // CHỌN NGẪU NHIÊN 1 TRONG 5 MẪU ĐỊA HÌNH
                int patternType = rand.Next(1, 6);
                SpawnPattern(this.Width + gap, width, patternType);
            }
        }

        // --- HÀM SINH MAP THEO MẪU ---
        private void SpawnPattern(int x, int width, int patternType)
        {
            bool hasFloor = false;
            bool hasCeiling = false;
            bool hasMiddle = false;
            bool allowObstacles = true;

            switch (patternType)
            {
                case 1: // Đường hầm cổ điển (An toàn nhất)
                    hasFloor = true; hasCeiling = true;
                    break;
                case 2: // Đường 3 làn
                    hasFloor = true; hasCeiling = true; hasMiddle = true;
                    break;
                case 3: // CHỈ CÓ SÀN (Solo)
                    hasFloor = true;
                    allowObstacles = false; // Cấm sinh vật cản để tránh đường cụt
                    break;
                case 4: // CHỈ CÓ TRẦN (Solo)
                    hasCeiling = true;
                    allowObstacles = false; // Cấm sinh vật cản
                    break;
                case 5: // Hỗn hợp (Có đường giữa)
                    hasMiddle = true;
                    if (rand.Next(2) == 0) hasFloor = true; else hasCeiling = true;
                    break;
            }

            // Sinh các đường dựa theo cờ (flag) đã bật
            if (hasFloor) SpawnSinglePlatform(x, floorY, width, "floor");
            if (hasCeiling) SpawnSinglePlatform(x, ceilingY, width, "ceiling");
            if (hasMiddle) SpawnSinglePlatform(x, middleY, width, "middle");

            // Sinh vật cản (Nếu được phép)
            if (allowObstacles)
            {
                for (int pos = x + 300; pos < x + width - 300; pos += 500)
                {
                    List<string> validLanes = new List<string>();
                    if (hasFloor) validLanes.Add("floor");
                    if (hasCeiling) validLanes.Add("ceiling");
                    if (hasMiddle) validLanes.Add("middle");

                    if (validLanes.Count > 0)
                    {
                        string chosenLane = validLanes[rand.Next(validLanes.Count)];
                        MakeObstacle(pos, 0, chosenLane);
                    }
                }
            }
        }

        private void SpawnSinglePlatform(int x, int y, int width, string type)
        {
            PictureBox plat = new PictureBox();
            plat.BackColor = Color.Gray;
            plat.Tag = type;
            if (type == "floor") { plat.Size = new Size(width, 50); plat.Location = new Point(x, y); }
            else if (type == "ceiling") { plat.Size = new Size(width, 50); plat.Location = new Point(x, y - 50); }
            else { plat.Size = new Size(width, 30); plat.BackColor = Color.Silver; plat.Location = new Point(x, y); }
            this.Controls.Add(plat); platforms.Add(plat);
        }

        // --- HÀM TẠO VẬT CẢN (ĐÃ NÂNG CẤP HÌNH ẢNH) ---
        private void MakeObstacle(int x, int dummyY, string platType)
        {
            PictureBox obs = new PictureBox();
            obs.BackColor = Color.Transparent; // Không dùng màu nền nữa

            // QUAN TRỌNG: Tháp cao nên tăng chiều cao lên 120
            obs.Size = new Size(50, 120);
            obs.SizeMode = PictureBoxSizeMode.StretchImage;

            // Tính toán lại Y chuẩn xác dựa trên loại đường và chiều cao mới
            int y = 0;
            if (platType == "floor")
            {
                y = floorY;
                obs.Location = new Point(x, y - 120); // Trừ đi chiều cao tháp (120)
                obs.Image = obstacleImgUp;
            }
            else if (platType == "ceiling")
            {
                y = ceilingY;
                obs.Location = new Point(x, y);
                obs.Image = obstacleImgDown;
            }
            else // middle
            {
                y = middleY;
                if (rand.Next(2) == 0)
                {
                    obs.Location = new Point(x, y - 120);
                    obs.Image = obstacleImgUp;
                }
                else
                {
                    obs.Location = new Point(x, y + 30);
                    obs.Image = obstacleImgDown;
                }
            }

            // Nếu không load được ảnh thì dùng màu đỏ dự phòng
            if (obstacleImgUp == null) obs.BackColor = Color.OrangeRed;

            this.Controls.Add(obs); obstacles.Add(obs); obs.BringToFront();
        }

        private void btnRestart_Click(object sender, EventArgs e) => StartNewGame();

        private void GameOver(string msg)
        {
            gameTimer.Stop();
            try { if (sndMusic != null) sndMusic.Stop(); } catch { }
            PlaySoundSafe(sndGameOver); // Phát tiếng thua

            isGameOver = true;
            btnRestart.Visible = true;
            btnRestart.BringToFront();
            lblInfo.Text = $"GAME OVER! SCORE: {score} ({msg})";
        }

        private void FormGameRunner_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGameOver && e.KeyCode == Keys.Space) { btnRestart.PerformClick(); return; }
            if (isGameOver) return;
            if ((e.KeyCode == Keys.Space || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) && isGrounded)
            {
                isGravityDown = !isGravityDown;
                isGrounded = false;
                PlaySoundSafe(sndJump); // Phát tiếng nhảy
            }
        }
    }
}