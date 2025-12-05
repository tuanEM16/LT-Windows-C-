namespace Example
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        // Hàm này để hiển thị tên bài hát trong ListBox (quan trọng)
        public override string ToString()
        {
            return Name;
        }
    }
}