namespace My_books.Data.Models
{
    public class Author_Book
    {
        public Guid  Id { get; set; }   


        //Navigation
        public Guid  BookId { get; set; }
        public Book Book { get; set; }

        public Guid AuthorId { get; set; }
        public Author Author { get; set; }


    }
}
