using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Example
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            GenerateMenuButtons();
        }

        private void GenerateMenuButtons()
        {
            // Danh sách bài tập (Đã thêm Bài 17, 18, 19)
            string[,] exercises = new string[,] {
                { "Bài 1\nHello World", "Form1" },
                { "Bài 2\nResize Title", "Form2" },
                { "Bài 3\nSave Pos", "Form3" },
                { "Bài 4\nKey Logger", "Form4" },
                { "Bài 5\nButton Zoom", "Form5" },
                { "Bài 6\nTextbox Num", "Form6" },
                { "Bài 7\nCalc Log", "Form7" },
                { "Bài 8\nCalc Simple", "Form8" },
                { "Bài 9\nCalc Full", "Form9" },
                { "Bài 10\nCombobox", "Form10" },
                { "Bài 11\nCbo Class", "Form11" },
                { "Bài 12\nRadio Check", "Form12" },
                { "Bài 13\nQL Sinh Viên", "Form13" },
                { "Bài 14\nMusic Play", "Form14" },
                { "Bài 15\nPicture Box", "Form15" },
                { "Bài 16\nDataGridView", "Form16" },
                { "Bài 17\nBindingSource", "Form17" }, 
                { "Bài 18\nTimer Clock", "Form18" },   
                { "Bài 19\nGame Move", "Form19" },
                { "Bài 20\nBall Game", "Form20" },
                { "Bài 21\nDrop Egg", "Form21" },
                { "Bài 22\nFull Game", "Form22" },
                { "Bài 22\nFormGameRunner", "FormGameRunner" }
            };

            // Xóa các nút cũ (nếu có)
            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < exercises.GetLength(0); i++)
            {
                Button btn = new Button();
                btn.Text = exercises[i, 0];
                btn.Tag = exercises[i, 1];

                // --- TRANG TRÍ GIỐNG NÚT BÀN PHÍM ---

                // 1. Kích thước vuông (100x100)
                btn.Width = 100;
                btn.Height = 100;

                // 2. Khoảng cách giữa các nút (giống khe hở phím)
                btn.Margin = new Padding(10);

                // 3. Màu sắc và Kiểu dáng
                btn.BackColor = Color.WhiteSmoke; // Màu trắng khói (giống phím cơ)
                btn.FlatStyle = FlatStyle.Standard; // Kiểu nút nổi 3D
                btn.Cursor = Cursors.Hand; // Đưa chuột vào hiện bàn tay

                // 4. Font chữ
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.ForeColor = Color.DimGray;

                // Gán sự kiện
                btn.Click += Btn_Click;

                // Thêm vào Panel
                flowLayoutPanel1.Controls.Add(btn);
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string formName = btn.Tag.ToString();

            // Logic mở Form dựa theo tên
            Form f = null;
            switch (formName)
            {
                case "Form1": f = new Form1(); break;
                case "Form2": f = new Form2(); break;
                case "Form3": f = new Form3(); break;
                case "Form4": f = new Form4(); break;
                case "Form5": f = new Form5(); break;
                case "Form6": f = new Form6(); break;
                case "Form7": f = new Form7(); break;
                case "Form8": f = new Form8(); break;
                case "Form9": f = new Form9(); break;
                case "Form10": f = new Form10(); break;
                case "Form11": f = new Form11(); break;
                case "Form12": f = new Form12(); break;
                case "Form13": f = new Form13(); break;
                case "Form14": f = new Form14(); break;
                case "Form15": f = new Form15(); break;
                case "Form16": f = new Form16(); break;
                case "Form17": f = new Form17(); break;
                case "Form18": f = new Form18(); break;
                case "Form19": f = new Form19(); break;
                case "Form20": f = new Form20(); break;
                case "Form21": f = new Form21(); break;
                case "Form22": f = new Form22(); break;
                case "FormGameRunner": f = new FormGameRunner(); break;
            }

            if (f != null)
            {
                f.StartPosition = FormStartPosition.CenterScreen; // Căn giữa màn hình khi mở
                f.ShowDialog(); // Hiện form lên
            }
            else
            {
                MessageBox.Show("Form này chưa được tạo hoặc chưa có trong danh sách code!");
            }
        }
    }
}