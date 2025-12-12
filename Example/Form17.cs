using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Example
{
    public partial class Form17 : Form
    {
        // 1. Khai báo danh sách và BindingSource (Slide 149)
        List<Employee> lstEmp;
        BindingSource bs = new BindingSource();

        public Form17()
        {
            InitializeComponent();
        }

        // Tạo dữ liệu mẫu giả lập (Slide 141)
        public List<Employee> GetData()
        {
            List<Employee> lst = new List<Employee>();
            lst.Add(new Employee() { Id = "53418", Name = "Trần Tiến", Age = 20, Gender = true });
            lst.Add(new Employee() { Id = "53416", Name = "Nguyễn Cường", Age = 25, Gender = false });
            lst.Add(new Employee() { Id = "53417", Name = "Nguyễn Hào", Age = 23, Gender = true });
            return lst;
        }

        // Sự kiện Load Form (Slide 149)
        private void Form17_Load(object sender, EventArgs e)
        {
            lstEmp = GetData();
            bs.DataSource = lstEmp;         // Đổ dữ liệu vào BindingSource
            dgvEmployee.DataSource = bs;    // Gán BindingSource cho Grid
        }

        // Sự kiện Thêm mới (Slide 149)
        private void btAddNew_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;

            int age = 0;
            int.TryParse(tbAge.Text, out age); // Xử lý lỗi nếu nhập sai số
            em.Age = age;

            em.Gender = ckGender.Checked;

            // QUAN TRỌNG: Chỉ cần thêm vào BindingSource, Grid sẽ TỰ CẬP NHẬT
            bs.Add(em);

            // Xóa trắng ô nhập
            tbId.Text = ""; tbName.Text = ""; tbAge.Text = ""; ckGender.Checked = false;
            tbId.Focus();
        }

        // Sự kiện Xóa (Slide 150)
        private void btDelete_Click(object sender, EventArgs e)
        {
            // Xóa dòng đang chọn thông qua BindingSource
            if (bs.Current != null)
            {
                bs.RemoveCurrent();
            }
        }

        // Sự kiện Click vào dòng để hiện ngược lại TextBox (Slide 144/150)
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployee.Rows[e.RowIndex].Cells[0].Value != null)
            {
                // Cách lấy dữ liệu an toàn từ Grid
                tbId.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbAge.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();

                // Kiểm tra null hoặc parse lỗi cho checkbox
                var cellVal = dgvEmployee.Rows[e.RowIndex].Cells[3].Value;
                if (cellVal != null)
                    ckGender.Checked = (bool)cellVal;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}