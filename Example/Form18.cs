using System;
using System.Windows.Forms;

namespace Example
{
    public partial class Form18 : Form
    {
        // Biến đếm giây
        int second = 0;

        public Form18()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            // Bắt đầu đếm
            tmStopwatch.Start();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            // Dừng đếm
            tmStopwatch.Stop();
        }

        // Sự kiện Tick xảy ra mỗi 1 giây (do Interval = 1000)
        private void tmStopwatch_Tick(object sender, EventArgs e)
        {
            second++;

            // Định dạng hiển thị phút:giây cho đẹp (ví dụ 01:05)
            // Logic đơn giản trong slide là: lblDisplay.Text = second.ToString();
            // Nhưng ta làm đẹp hơn một chút:
            TimeSpan time = TimeSpan.FromSeconds(second);
            lblDisplay.Text = time.ToString(@"mm\:ss");
        }
    }
}