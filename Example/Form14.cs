using System;
using System.Collections;
using System.Windows.Forms;

namespace Example
{
    public partial class Form14 : Form
    {
        public Form14() { InitializeComponent(); }

        // Tạo dữ liệu giả (Slide 123)
        public ArrayList GetData()
        {
            ArrayList lst = new ArrayList();
            lst.Add(new Song() { Id = 53418, Name = "Giấc mơ Chapi", Author = "Trần Tiến" });
            lst.Add(new Song() { Id = 52616, Name = "Đôi mắt Pleiku", Author = "Nguyễn Cường" });
            lst.Add(new Song() { Id = 51172, Name = "Em muốn sống bên anh trọn đời", Author = "Nguyễn Cường" });
            lst.Add(new Song() { Id = 52345, Name = "Ly cà phê ban mê", Author = "Nguyễn Cường" });
            return lst;
        }

        // Load Form
        private void Form14_Load(object sender, EventArgs e)
        {
            ArrayList listSongs = GetData();
            // Thêm từng bài hát vào ListBox thay vì gán DataSource để nút Xóa hoạt động tốt
            foreach (Song s in listSongs)
            {
                lbSong.Items.Add(s);
            }
        }

        // Chọn 1 bài (Slide 124)
        private void MoveSong()
        {
            if (lbSong.SelectedItem != null)
            {
                Song s = (Song)lbSong.SelectedItem;
                // Tạo chuỗi hiển thị bên phải
                string info = s.Id + " - " + s.Name + " - " + s.Author;
                lbFavorite.Items.Add(info);

                // Xóa khỏi bên trái (Slide 118)
                lbSong.Items.RemoveAt(lbSong.SelectedIndex);
            }
        }

        // Sự kiện nút >
        private void btSelect_Click(object sender, EventArgs e)
        {
            MoveSong();
        }

        // Sự kiện Double Click (Slide 119)
        private void lbSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MoveSong();
        }

        // Sự kiện nút >> (Chọn tất cả - Slide 119)
        private void btSelectAll_Click(object sender, EventArgs e)
        {
            // Lặp từ trên xuống dưới để chuyển hết
            while (lbSong.Items.Count > 0)
            {
                Song s = (Song)lbSong.Items[0];
                string info = s.Id + " - " + s.Name + " - " + s.Author;
                lbFavorite.Items.Add(info);
                lbSong.Items.RemoveAt(0);
            }
        }
    }
}