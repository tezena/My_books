namespace My_books.Data.Models
{
    public class Author
    {

        public Guid Id { get; set; }
        public string FullName { get; set; }

        //Navigation
        
        public List<Author_Book> author_Books { get; set; }
    }
}
