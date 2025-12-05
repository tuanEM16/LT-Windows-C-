using System;
using System.Windows.Forms;

namespace Example
{
    public partial class Form13 : Form
    {
        public Form13() { InitializeComponent(); }

        private void btAdd_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các control
            string name = tbName.Text;
            string dob = dtpDob.Value.ToShortDateString(); // Lấy ngày tháng năm
            string gender = rbMale.Checked ? "Nam" : "Nữ";
            string faculty = cbFaculty.SelectedItem.ToString();

            // Tạo chuỗi kết quả và thêm vào ListBox
            string info = name + " - " + gender + " - " + dob + " - " + faculty;
            lbList.Items.Add(info);
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}