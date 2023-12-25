namespace My_books.Data.Models
{
    public class Publisher
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    


        //Navigation property
        public List<Book> Books { get; set; }
    }
}
