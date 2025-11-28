using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;               
using System.Xml.Serialization; 

namespace Example
{
    public partial class Form2 : Form
    {
        string path = @"D:\form.xml";

        public Form2()
        {
            InitializeComponent();
        }

        public void Write(InfoWindows iw)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                StreamWriter file = new StreamWriter(path);
                writer.Serialize(file, iw);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi file: " + ex.Message);
            }
        }

        // Sự kiện Load
        private void Form2_Load(object sender, EventArgs e)
        {
            SaveCurrentSize();
        }

        // Sự kiện ResizeEnd
        private void Form2_ResizeEnd(object sender, EventArgs e)
        {
            SaveCurrentSize();
        }

        // Hàm lưu kích thước hiện tại (Slide 29)
        private void SaveCurrentSize()
        {
            // Hiển thị lên title như bài tập 1
            this.Text = this.Size.Width + " - " + this.Size.Height;

            // Tạo đối tượng chứa thông tin
            InfoWindows iw = new InfoWindows();
            iw.Width = this.Size.Width;
            iw.Height = this.Size.Height;

            // Gọi hàm ghi file
            Write(iw);
        }


    }
}