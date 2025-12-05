using System;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Example
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        // Sự kiện khi tích vào ô "Giảm giá" (Slide 106)
        private void ckDiscount_CheckedChanged(object sender, EventArgs e)
        {
            if (ckDiscount.Checked == true)
            {
                tbDiscount.Enabled = true; // Cho phép nhập số
            }
            else
            {
                tbDiscount.Enabled = false; // Khóa ô nhập lại
                tbDiscount.Text = "";       // Xóa nội dung cũ
            }
        }

        // Sự kiện bấm nút Tính tiền (Slide 106)
        private void btRun_Click(object sender, EventArgs e)
        {
            string msg = null;
            int disc = 0;

            // Kiểm tra giới tính
            if (rbMale.Checked == true)
                msg += "Ông ";
            if (rbFemale.Checked == true)
                msg += "Bà ";

            // Kiểm tra giảm giá
            if (ckDiscount.Checked == true)
            {
                // Thử lấy số từ ô nhập, nếu lỗi hoặc rỗng thì mặc định là 5
                if (!int.TryParse(tbDiscount.Text, out disc))
                {
                    disc = 5;
                }
            }

            // Hiển thị kết quả
            tbResult.Text = msg + tbName.Text + " được giảm " + disc.ToString() + "%\r\n";
        }

        // Nút Thoát
        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}