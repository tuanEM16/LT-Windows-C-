using System;
using System.Windows.Forms;

namespace Example 
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "Caculator";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Chào mừng đến với ứng dụng Windows Form!", "Thông báo");
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            ShowSize();
        }
        private void ShowSize()
        {
            int width = this.Size.Width;   
            int height = this.Size.Height;

            this.Text = width.ToString() + " - " + height.ToString();
        }
    }
}