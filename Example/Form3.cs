using System;
using System.Drawing; // Dùng Point
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;

namespace Example
{
    public partial class Form3 : Form
    {
        // Đường dẫn file
        string path = "config.xml";

        public Form3()
        {
            InitializeComponent();
        }

        // --- CÁC HÀM XỬ LÝ FILE ---
        public void Write(InfoWindows iw)
        {
            try
            {
                XmlSerializer writer = new XmlSerializer(typeof(InfoWindows));
                using (StreamWriter file = new StreamWriter(path))
                {
                    writer.Serialize(file, iw);
                }
            }
            catch { }
        }

        public InfoWindows Read()
        {
            try
            {
                if (!File.Exists(path)) return null;

                XmlSerializer reader = new XmlSerializer(typeof(InfoWindows));
                using (StreamReader file = new StreamReader(path))
                {
                    return (InfoWindows)reader.Deserialize(file);
                }
            }
            catch { return null; }
        }

        // --- SỰ KIỆN LOAD (Lúc mở lên) ---
        private void Form3_Load(object sender, EventArgs e)
        {
            InfoWindows iw = Read();
            if (iw != null)
            {
                this.Width = iw.Width;
                this.Height = iw.Height;

                // Quan trọng: Đặt Location
                this.Location = iw.Location;
            }
        }

        // --- SỰ KIỆN ĐÓNG (Lúc tắt đi) ---
        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            InfoWindows iw = new InfoWindows();

            // Nếu đang phóng to/thu nhỏ thì không lưu (tránh lỗi lưu tọa độ âm)
            if (this.WindowState == FormWindowState.Normal)
            {
                iw.Width = this.Width;
                iw.Height = this.Height;
                iw.Location = this.Location;
            }
            else
            {
                iw.Width = this.RestoreBounds.Width;
                iw.Height = this.RestoreBounds.Height;
                iw.Location = this.RestoreBounds.Location;
            }

            Write(iw);
        }
    }
}