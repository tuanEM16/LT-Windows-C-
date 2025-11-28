using System;
using System.Windows.Forms;
using System.IO; // <--- Quan trọng: Thư viện để ghi file cho KeyLogger

namespace Example
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        // --- PHẦN 1: BUTTON (Slide 51, 52) ---
        private void bt_OK_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bạn đã bấm nút OK!");
        }

        // --- PHẦN 2: KEY LOGGER (Slide 46) ---
        private void Form4_KeyUp(object sender, KeyEventArgs e)
        {
            // Code ghi phím bấm vào file
            // Tham số true để ghi nối đuôi (không xóa dữ liệu cũ)
            using (StreamWriter sw = new StreamWriter("Key_Logger.txt", true))
            {
                sw.Write(e.KeyCode.ToString() + " ");
            }
        }
    }
}