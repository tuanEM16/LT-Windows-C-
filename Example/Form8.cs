using System;
using System.Windows.Forms;

namespace Example
{
    public partial class Form8 : Form
    {
        // Khai báo biến toàn cục (Theo Slide 78)
        decimal workingMemory = 0; // Lưu số đầu tiên
        string opr = "";           // Lưu phép tính (+ hoặc *)

        public Form8()
        {
            InitializeComponent();
        }

        // --- NHÓM HÀM NHẬP SỐ (0, 1, 2, 3, .) ---
        // Khi bấm nút, ta nối thêm chữ số vào màn hình
        private void bt0_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += bt0.Text;
        }

        private void bt1_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += bt1.Text;
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += bt2.Text;
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            tbDisplay.Text += bt3.Text;
        }

        private void btDot_Click(object sender, EventArgs e)
        {
            // Kiểm tra: Nếu chưa có dấu chấm thì mới cho thêm (tránh lỗi 12..5)
            if (!tbDisplay.Text.Contains("."))
            {
                tbDisplay.Text += ".";
            }
        }

        // --- NHÓM HÀM PHÉP TÍNH (+, *) ---
        // (Theo Slide 79)
        private void btPlus_Click(object sender, EventArgs e)
        {
            opr = btPlus.Text; // Lưu dấu "+"
            workingMemory = decimal.Parse(tbDisplay.Text); // Lưu số hiện tại vào bộ nhớ
            tbDisplay.Clear(); // Xóa màn hình để nhập số thứ 2
        }

        private void btMul_Click(object sender, EventArgs e)
        {
            opr = "*"; // Lưu dấu "*"
            workingMemory = decimal.Parse(tbDisplay.Text);
            tbDisplay.Clear();
        }

        // --- HÀM TÍNH KẾT QUẢ (=) ---
        // (Theo Slide 79)
        private void btEquals_Click(object sender, EventArgs e)
        {
            // Lấy số thứ 2 từ màn hình
            decimal secondValue = decimal.Parse(tbDisplay.Text);

            // Kiểm tra phép tính và thực hiện
            if (opr == "+")
            {
                tbDisplay.Text = (workingMemory + secondValue).ToString();
            }

            if (opr == "*")
            {
                tbDisplay.Text = (workingMemory * secondValue).ToString();
            }
        }
    }
}