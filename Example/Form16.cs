using System;
using System.Collections.Generic; // Dùng List
using System.Windows.Forms;

namespace Example
{
    public partial class Form16 : Form
    {
        // Khai báo biến toàn cục (Slide 149)
        List<Employee> lstEmp;
        BindingSource bs = new BindingSource();

        public Form16()
        {
            InitializeComponent();
        }

        // Tạo dữ liệu mẫu (Slide 141)
        public List<Employee> GetData()
        {
            List<Employee> lst = new List<Employee>();
            lst.Add(new Employee() { Id = "53418", Name = "Trần Tiến", Age = 20, Gender = true });
            lst.Add(new Employee() { Id = "53416", Name = "Nguyễn Cường", Age = 25, Gender = false });
            lst.Add(new Employee() { Id = "53417", Name = "Nguyễn Hào", Age = 23, Gender = true });
            return lst;
        }

        // Load Form (Slide 149 - Quan trọng)
        private void Form16_Load(object sender, EventArgs e)
        {
            lstEmp = GetData();
            bs.DataSource = lstEmp;         // Đưa list vào BindingSource
            dgvEmployee.DataSource = bs;    // Đưa BindingSource vào GridView
        }

        // Nút Thêm Mới (Slide 149)
        private void btAddNew_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.Id = tbId.Text;
            em.Name = tbName.Text;
            em.Age = int.Parse(tbAge.Text);
            em.Gender = ckGender.Checked;

            // Thêm vào BindingSource, nó sẽ tự hiện lên bảng
            bs.Add(em);
            // Lưu ý: Không cần dgvEmployee.Rows.Add nữa
        }

        // Nút Xóa (Slide 150)
        private void btDelete_Click(object sender, EventArgs e)
        {
            // Xóa dòng đang chọn thông qua BindingSource
            if (bs.Current != null)
            {
                bs.RemoveCurrent();
            }
        }

        // Sự kiện chọn dòng để hiện lại thông tin (Slide 150)
        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy dòng hiện tại từ DataGridView
            if (dgvEmployee.Rows[e.RowIndex].Cells[0].Value != null)
            {
                tbId.Text = dgvEmployee.Rows[e.RowIndex].Cells[0].Value.ToString();
                tbName.Text = dgvEmployee.Rows[e.RowIndex].Cells[1].Value.ToString();
                tbAge.Text = dgvEmployee.Rows[e.RowIndex].Cells[2].Value.ToString();
                ckGender.Checked = (bool)dgvEmployee.Rows[e.RowIndex].Cells[3].Value;
            }
        }

        private void btExit_Click(object sender, EventArgs e) { this.Close(); }
    }
}