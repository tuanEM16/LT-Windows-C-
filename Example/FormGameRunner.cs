using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Example
{
    public partial class FormGameRunner : Form
    {
        // --- CẤU HÌNH GAME ---
        int formWidth = 1280;
        int formHeight = 720;
        int ceilingY = 50; int floorY = 620; int middleY = 330;

        PictureBox player = new PictureBox();
        List<PictureBox> platforms = new List<PictureBox>();
        List<PictureBox> obstacles = new List<PictureBox>();

        System.Windows.Forms.Timer gameTimer = new System.Windows.Forms.Timer();
        Random rand = new Random();
        Label lblInfo = new Label();
        Button btnRestart = new Button();

        float currentSpeed = 12f;
        float maxSpeed = 30f;
        int score = 0;

        int targetScore = 10000;
        bool finishLineSpawned = false;

        bool isGravityDown = true;
        bool isGrounded = false;
        int gravitySpeed = 16;

        int jumpCount = 0;
        int maxJumps = 2;

        bool isColliding = false;

        int spawnCounter = 0;
        bool isGameOver = false;

        // --- TÀI NGUYÊN ---
        Image gifImage;
        Image obstacleImgUp;
        Image obstacleImgDown;
        Image platformImg; 

        SoundPlayer sndJump;
        SoundPlayer sndHit;
        SoundPlayer sndGameOver;
        SoundPlayer sndMusic;
        SoundPlayer sndVictory;

        public FormGameRunner()
        {
            InitializeComponent();

            // Cấu hình chống nháy (Double Buffer)
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.UserPaint, true);
            this.UpdateStyles();

            this.KeyUp += new KeyEventHandler(FormGameRunner_KeyUp);
        }

        // KỸ THUẬT VẼ CHỒNG LỚP (GIÚP KHÔNG BỊ XÉ HÌNH)
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void FormGameRunner_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(formWidth, formHeight);
            this.BackColor = Color.FromArgb(20, 20, 40);
            this.Text = "Gravity Runner - Hard Collision Fix";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyPreview = true;

            LoadResourcesSafe();

            player.Size = new Size(100, 80);
            player.BackColor = Color.Transparent;
            player.SizeMode = PictureBoxSizeMode.Zoom;
            player.Paint += Player_Paint;
            this.Controls.Add(player);
            player.BringToFront();

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

        private void LoadResourcesSafe()
        {
            try
            {
                if (System.IO.File.Exists("Images/player.gif"))
                {
                    gifImage = Image.FromFile("Images/player.gif");
                    ImageAnimator.Animate(gifImage, (o, args) => { });
                }

                if (System.IO.File.Exists("Images/tower.png"))
                {
                    Image tempTower = Image.FromFile("Images/tower.png");
                    obstacleImgUp = (Image)tempTower.Clone();
                    obstacleImgDown = (Image)tempTower.Clone();
                    obstacleImgDown.RotateFlip(RotateFlipType.RotateNoneFlipY);
                }

                // [MỚI] Load ảnh mặt đường
                if (System.IO.File.Exists("Images/platform.png"))
                {
                    platformImg = Image.FromFile("Images/platform.png");
                }

                if (System.IO.File.Exists("Sounds/jump.wav")) sndJump = new SoundPlayer("Sounds/jump.wav");
                if (System.IO.File.Exists("Sounds/hit.wav")) sndHit = new SoundPlayer("Sounds/hit.wav");
                if (System.IO.File.Exists("Sounds/gameover.wav")) sndGameOver = new SoundPlayer("Sounds/gameover.wav");
                if (System.IO.File.Exists("Sounds/music.wav")) sndMusic = new SoundPlayer("Sounds/music.wav");
                if (System.IO.File.Exists("Sounds/victory.wav")) sndVictory = new SoundPlayer("Sounds/victory.wav");
            }
            catch { }
        }

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
            isColliding = false;
            finishLineSpawned = false;
            jumpCount = 0;
            score = 0;
            currentSpeed = 12f;
            btnRestart.Visible = false;

            foreach (PictureBox p in platforms) this.Controls.Remove(p);
            foreach (PictureBox o in obstacles) this.Controls.Remove(o);
            platforms.Clear();
            obstacles.Clear();

            player.Location = new Point(200, floorY - player.Height);
            player.BringToFront();

            try { if (sndMusic != null) sndMusic.PlayLooping(); } catch { }

            SpawnPattern(0, 2500, 1);

            gameTimer.Interval = 15;
            gameTimer.Tick -= GameLoop_Tick;
            gameTimer.Tick += GameLoop_Tick;
            gameTimer.Start();
            this.Focus();
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (isGameOver) return;

            // Reset va chạm đầu khung hình
            isColliding = false;

            // Tính điểm
            if (!finishLineSpawned)
            {
                score += (int)(currentSpeed / 5);
                if (currentSpeed < maxSpeed) currentSpeed += 0.005f;
            }
            lblInfo.Text = $"SPEED: {Math.Round(currentSpeed)} | SCORE: {score} / {targetScore}";

            // Trọng lực
            if (isGravityDown) player.Top += gravitySpeed;
            else player.Top -= gravitySpeed;

            CheckGroundedState();

            if (!isGrounded)
            {
                if (player.Top > this.ClientSize.Height) { GameOver("Rớt vực thẳm!"); return; }
                if (player.Bottom < 0) { GameOver("Bay lên trời!"); return; }
            }

            // [QUAN TRỌNG] Xử lý di chuyển map và va chạm
            ManageMapAndObstacles();

            // [LOGIC SỬA LỖI XÉ HÌNH]
            // Chỉ cho phép nhân vật tự chạy lên (hồi phục vị trí) nếu KHÔNG va chạm.
            // Nếu isColliding = true (đang đụng tường), dòng này bị bỏ qua -> Nhân vật đứng im chịu trận -> Hết xé.
            if (!isColliding && isGrounded && player.Left < 200)
            {
                player.Left += 3;
            }

            if (player.Right < 0) GameOver("BẠN QUÁ CHẬM!");

            // Vẽ lại sau khi tính toán xong xuôi để hình ảnh đồng bộ
            this.Invalidate();
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
                            isGrounded = true;
                            jumpCount = 0;
                            return;
                        }
                    }
                    else if (!isGravityDown && (type == "ceiling" || type == "middle"))
                    {
                        if (player.Top <= plat.Bottom && player.Top >= plat.Bottom - gravitySpeed - 5)
                        {
                            player.Top = plat.Bottom;
                            isGrounded = true;
                            jumpCount = 0;
                            return;
                        }
                    }
                }
            }
        }

        private void ManageMapAndObstacles()
        {
            int moveStep = (int)currentSpeed;

            // --- 1. QUẢN LÝ SÀN (PLATFORM) ---
            for (int i = platforms.Count - 1; i >= 0; i--)
            {
                platforms[i].Left -= moveStep;

                Rectangle playerHitbox = new Rectangle(
                    player.Left + 20,
                    player.Top + 10,
                    player.Width - 40,
                    player.Height - 20
                );

                Rectangle platBox = platforms[i].Bounds;

                // ---- FIX VA CHẠM MÉP PLATFORM ----
                bool hitSide =
                    playerHitbox.Right > platBox.Left &&
                    playerHitbox.Left < platBox.Left &&
                    playerHitbox.Bottom > platBox.Top + 8 &&
                    playerHitbox.Top < platBox.Bottom - 8;

                if (hitSide)
                {
                    player.Left = platBox.Left - player.Width - 1;
                    isColliding = true;
                }

                if (platforms[i].Right < 0)
                {
                    this.Controls.Remove(platforms[i]);
                    platforms.RemoveAt(i);
                }
            }

            // --- 2. QUẢN LÝ VẬT CẢN (THÁP) ---
            for (int i = obstacles.Count - 1; i >= 0; i--)
            {
                PictureBox obs = obstacles[i];
                obs.Left -= moveStep;

                Rectangle playerHitbox = new Rectangle(player.Left + 20, player.Top + 10, player.Width - 40, player.Height - 20);

                // KIỂM TRA VA CHẠM
                if (playerHitbox.IntersectsWith(obs.Bounds))
                {
                    // Nếu là đích thì thắng
                    if (obs.Tag != null && obs.Tag.ToString() == "finish")
                    {
                        GameWin();
                        return;
                    }

                    // [FIX XÉ HÌNH] VA CHẠM CỨNG
                    // Thay vì đẩy lùi từ từ, ta ép chặt vị trí nhân vật vào ngay mép trước vật cản.
                    // Trừ đi 1 pixel để đảm bảo không dính chồng lên nhau.
                    player.Left = obs.Left - player.Width - 1;

                    // Bật cờ va chạm để hàm GameLoop_Tick biết mà dừng việc kéo nhân vật tới trước
                    isColliding = true;

                    if (player.Left > 50) PlaySoundSafe(sndHit);
                }

                if (obs.Right < 0) { this.Controls.Remove(obs); obstacles.RemoveAt(i); }
            }

            // --- SINH MAP MỚI ---
            spawnCounter += moveStep;
            if (spawnCounter > 100)
            {
                if (platforms.Count > 0 && platforms[platforms.Count - 1].Right > this.Width + 100) return;
                spawnCounter = 0;

                if (score >= targetScore && !finishLineSpawned)
                {
                    SpawnFinishLine(this.Width + 100);
                    finishLineSpawned = true;
                }
                else if (!finishLineSpawned)
                {
                    int gap = rand.Next(160, 220);
                    int width = rand.Next(600, 1500);
                    int patternType = rand.Next(1, 6);
                    SpawnPattern(this.Width + gap, width, patternType);
                }
            }
        }

        private void SpawnFinishLine(int x)
        {
            SpawnSinglePlatform(x, floorY, 2000, "floor");
            SpawnSinglePlatform(x, ceilingY, 2000, "ceiling");

            PictureBox ribbon = new PictureBox();
            ribbon.Tag = "finish";
            ribbon.BackColor = Color.Red;
            ribbon.Size = new Size(20, this.ClientSize.Height);
            ribbon.Location = new Point(x + 800, 0);

            this.Controls.Add(ribbon);
            obstacles.Add(ribbon);

            ribbon.BringToFront();
            player.BringToFront();
        }

        private void SpawnPattern(int x, int width, int patternType)
        {
            bool hasFloor = false; bool hasCeiling = false; bool hasMiddle = false; bool allowObstacles = true;
            switch (patternType)
            {
                case 1: hasFloor = true; hasCeiling = true; break;
                case 2: hasFloor = true; hasCeiling = true; hasMiddle = true; break;
                case 3: hasFloor = true; allowObstacles = false; break;
                case 4: hasCeiling = true; allowObstacles = false; break;
                case 5: hasMiddle = true; if (rand.Next(2) == 0) hasFloor = true; else hasCeiling = true; break;
            }

            if (hasFloor) SpawnSinglePlatform(x, floorY, width, "floor");
            if (hasCeiling) SpawnSinglePlatform(x, ceilingY, width, "ceiling");
            if (hasMiddle) SpawnSinglePlatform(x, middleY, width, "middle");

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

        // [MỚI] HÀM TẠO SÀN CÓ ẢNH NỀN
        private void SpawnSinglePlatform(int x, int y, int width, string type)
        {
            PictureBox plat = new PictureBox();
            plat.Tag = type;

            // Nếu load được ảnh thì dùng ảnh
            if (platformImg != null)
            {
                plat.Image = platformImg;
                plat.SizeMode = PictureBoxSizeMode.StretchImage; // Kéo giãn ảnh cho vừa
                plat.BackColor = Color.Transparent;
            }
            else
            {
                plat.BackColor = Color.Gray; // Không có ảnh thì màu xám
            }

            if (type == "floor") { plat.Size = new Size(width, 50); plat.Location = new Point(x, y); }
            else if (type == "ceiling") { plat.Size = new Size(width, 50); plat.Location = new Point(x, y - 50); }
            else
            {
                plat.Size = new Size(width, 30);
                plat.Location = new Point(x, y);
                // Đường giữa thì dùng màu bạc nếu ko có ảnh
                if (platformImg == null) plat.BackColor = Color.Silver;
            }

            this.Controls.Add(plat); platforms.Add(plat);

            // Đưa người lên trên cùng để không bị sàn đè mất
            player.BringToFront();
        }

        private void MakeObstacle(int x, int dummyY, string platType)
        {
            PictureBox obs = new PictureBox();
            obs.BackColor = Color.Transparent;
            obs.Size = new Size(50, 120);
            obs.SizeMode = PictureBoxSizeMode.StretchImage;

            int y = 0;
            if (platType == "floor") { y = floorY; obs.Location = new Point(x, y - 120); obs.Image = obstacleImgUp; }
            else if (platType == "ceiling") { y = ceilingY; obs.Location = new Point(x, y); obs.Image = obstacleImgDown; }
            else
            {
                y = middleY;
                if (rand.Next(2) == 0) { obs.Location = new Point(x, y - 120); obs.Image = obstacleImgUp; }
                else { obs.Location = new Point(x, y + 30); obs.Image = obstacleImgDown; }
            }

            if (obstacleImgUp == null) obs.BackColor = Color.OrangeRed;
            this.Controls.Add(obs); obstacles.Add(obs); obs.BringToFront();
        }

        private void btnRestart_Click(object sender, EventArgs e) => StartNewGame();

        private void GameWin()
        {
            gameTimer.Stop();
            try { if (sndMusic != null) sndMusic.Stop(); } catch { }
            PlaySoundSafe(sndVictory);

            isGameOver = true;
            btnRestart.Visible = true;
            btnRestart.BringToFront();

            lblInfo.Text = $"VICTORY! BẠN ĐÃ CHIẾN THẮNG!\nSCORE: {score}";
            lblInfo.ForeColor = Color.Yellow;
        }

        private void GameOver(string msg)
        {
            gameTimer.Stop();
            try { if (sndMusic != null) sndMusic.Stop(); } catch { }
            PlaySoundSafe(sndGameOver);

            isGameOver = true;
            btnRestart.Visible = true;
            btnRestart.BringToFront();
            lblInfo.ForeColor = Color.Lime;
            lblInfo.Text = $"GAME OVER! SCORE: {score} ({msg})";
        }

        private void FormGameRunner_KeyUp(object sender, KeyEventArgs e) { }

        private void FormGameRunner_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGameOver && e.KeyCode == Keys.Space) { btnRestart.PerformClick(); return; }
            if (isGameOver) return;

            if ((e.KeyCode == Keys.Space || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                && jumpCount < maxJumps)
            {
                isGravityDown = !isGravityDown;
                isGrounded = false;
                jumpCount++;
                PlaySoundSafe(sndJump);
            }
        }
    }
}