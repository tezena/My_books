namespace My_books.Data.Models
{
    public class Book
    {
        public Guid id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public string Genre { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadDate { get; set; }
        public int? Rate { get; set; }
        public string CoverUrl { get; set; }
        public DateTime DateAdded { get; set; }



    }
}
