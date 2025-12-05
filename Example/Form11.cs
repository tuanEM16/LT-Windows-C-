using System;
using System.Collections; // Cần cái này để dùng ArrayList
using System.Windows.Forms;

namespace Example
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        // Hàm tạo dữ liệu giả lập (Slide 100)
        public ArrayList GetData()
        {
            ArrayList lst = new ArrayList();

            Faculty f1 = new Faculty();
            f1.Id = "K01";
            f1.Name = "Công nghệ thông tin";
            f1.Quantity = 1200;
            lst.Add(f1);

            Faculty f2 = new Faculty();
            f2.Id = "K02";
            f2.Name = "Quản trị kinh doanh";
            f2.Quantity = 4200;
            lst.Add(f2);

            Faculty f3 = new Faculty();
            f3.Id = "K03";
            f3.Name = "Kế toán tài chính";
            f3.Quantity = 5200;
            lst.Add(f3);

            return lst;
        }

        // Sự kiện Load Form (Slide 101)
        private void Form11_Load(object sender, EventArgs e)
        {
            ArrayList lst = GetData();

            // Gán nguồn dữ liệu
            cb_Faculty.DataSource = lst;

            // Quan trọng: Chọn trường nào để hiển thị lên màn hình
            cb_Faculty.DisplayMember = "Name";

            // Quan trọng: Chọn trường nào để làm giá trị ẩn bên dưới
            cb_Faculty.ValueMember = "Id";
        }

        // Sự kiện chọn Combobox (Slide 101)
        private void cb_Faculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra null để tránh lỗi khi mới khởi động
            if (cb_Faculty.SelectedValue != null)
            {
                // Lấy giá trị ẩn (Id) của mục đang chọn
                string id = cb_Faculty.SelectedValue.ToString();
                tbDisplay.Text = "Bạn đã chọn khoa có mã: " + id;
            }
        }

        // Sự kiện bấm nút OK (Slide 101)
        private void btOK_Click(object sender, EventArgs e)
        {
            // Lấy object đang chọn, ép kiểu về Faculty để lấy Name
            Faculty selectedFaculty = (Faculty)cb_Faculty.SelectedItem;
            if (selectedFaculty != null)
            {
                tbDisplay.Text = "Bạn đã chọn khoa có tên: " + selectedFaculty.Name;
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbDisplay.Clear();
        }
    }
}