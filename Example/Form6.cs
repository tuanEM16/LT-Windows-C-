using System;
using System.ComponentModel; 
using System.Windows.Forms;

namespace Example
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void tbYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void tbYear_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbYear.Text)) return;

            int year = int.Parse(tbYear.Text);

            if (year <= 2000)
            {
                MessageBox.Show("Vui lòng nhập năm lớn hơn 2000!");
                e.Cancel = true;
            }
        }
    }
}