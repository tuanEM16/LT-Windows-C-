using System;
using System.Drawing; // Thêm thư viện này để chỉnh màu sắc, font chữ
using System.Windows.Forms;

namespace Example
{
    public partial class Form9 : Form
    {
        decimal memory = 0;
        decimal workingMemory = 0;
        string opr = "";

        public Form9()
        {
            InitializeComponent();
            // Gọi hàm tạo nút ngay khi Form khởi động
            GenerateButtons();
        }

        // --- HÀM TỰ ĐỘNG VẼ NÚT (Chuyển từ Designer sang đây) ---
        // Thay thế toàn bộ hàm này
        private void GenerateButtons()
        {
            this.ClientSize = new Size(465, 530);

            string[] btnLabels = {
                "MC", "MR", "MS", "M+", "M-",
                "←", "CE", "C", "±", "√",
                "7", "8", "9", "/", "%",
                "4", "5", "6", "*", "1/x",
                "1", "2", "3", "-", "=",
                "0", ".", "+"
            };

            int x = 12;
            int y = 80;
            int w = 80;
            int h = 60;
            int gap = 10;
            int colCount = 0;

            foreach (string lbl in btnLabels)
            {
                Button btn = new Button();
                btn.Text = lbl;
                btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);

                // 1. Nút Bằng (=)
                if (lbl == "=")
                {
                    btn.Size = new Size(w, h * 2 + gap);
                    btn.Location = new Point(x, y);
                }
                // 2. Nút Số 0
                else if (lbl == "0")
                {
                    x = 12;
                    y += h + gap;

                    btn.Size = new Size(w * 2 + gap, h);
                    btn.Location = new Point(x, y);

                    x += (w * 2 + gap) + gap;

                    // --- SỬA LỖI Ở ĐÂY ---
                    // Nút 0 chiếm 2 ô, nên ta set biến đếm thành 2
                    // Để các nút sau (. và +) biết đường mà xếp tiếp
                    colCount = 2;
                }
                // 3. Các nút bình thường
                else
                {
                    btn.Size = new Size(w, h);
                    btn.Location = new Point(x, y);

                    x += w + gap;
                    colCount++;

                    if (colCount >= 5)
                    {
                        x = 12;
                        y += h + gap;
                        colCount = 0;
                    }
                }

                btn.Click += new EventHandler(Button_Click);
                this.Controls.Add(btn);
            }
        }
        // --- HÀM XỬ LÝ LOGIC (Giữ nguyên) ---
        private void Button_Click(object sender, EventArgs e)
        {
            Button bt = (Button)sender;
            string text = bt.Text;

            if ((char.IsDigit(text, 0) && text.Length == 1) || text == ".")
            {
                if (text == "." && txtDisplay.Text.Contains(".")) return;
                txtDisplay.Text += text;
            }
            else if (text == "+" || text == "-" || text == "*" || text == "/")
            {
                opr = text;
                workingMemory = decimal.Parse(txtDisplay.Text);
                txtDisplay.Clear();
            }
            else if (text == "=")
            {
                decimal secondValue = decimal.Parse(txtDisplay.Text);
                switch (opr)
                {
                    case "+": txtDisplay.Text = (workingMemory + secondValue).ToString(); break;
                    case "-": txtDisplay.Text = (workingMemory - secondValue).ToString(); break;
                    case "*": txtDisplay.Text = (workingMemory * secondValue).ToString(); break;
                    case "/":
                        if (secondValue != 0) txtDisplay.Text = (workingMemory / secondValue).ToString();
                        break;
                }
            }
            else if (text == "±")
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = (-val).ToString();
            }
            else if (text == "√")
            {
                double val = double.Parse(txtDisplay.Text);
                txtDisplay.Text = Math.Sqrt(val).ToString();
            }
            else if (text == "%")
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                txtDisplay.Text = (val / 100).ToString();
            }
            else if (text == "1/x")
            {
                decimal val = decimal.Parse(txtDisplay.Text);
                if (val != 0) txtDisplay.Text = (1 / val).ToString();
            }
            else if (text == "←")
            {
                if (txtDisplay.TextLength > 0)
                    txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.TextLength - 1);
            }
            else if (text == "C")
            {
                workingMemory = 0; opr = ""; txtDisplay.Clear();
            }
            else if (text == "CE")
            {
                txtDisplay.Clear();
            }
            else if (text == "MC") memory = 0;
            else if (text == "MR") txtDisplay.Text = memory.ToString();
            else if (text == "MS") memory = decimal.Parse(txtDisplay.Text);
            else if (text == "M+") memory += decimal.Parse(txtDisplay.Text);
            else if (text == "M-") memory -= decimal.Parse(txtDisplay.Text);
        }
    }
}