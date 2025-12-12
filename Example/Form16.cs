using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Example
{
    public partial class Form16 : Form
    {
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

        // Sự kiện Load Form
        private void Form16_Load(object sender, EventArgs e)
        {
            // Lấy dữ liệu và đổ trực tiếp vào Grid
            List<Employee> lstEmp = GetData();

            // Cách 1: Gán trực tiếp (Đơn giản nhất)
            dgvEmployee.DataSource = lstEmp;

            // Cách 2: Dùng BindingSource (Nếu muốn chuẩn theo bài 22)
            // BindingSource bs = new BindingSource();
            // bs.DataSource = lstEmp;
            // dgvEmployee.DataSource = bs;
        }
    }
}