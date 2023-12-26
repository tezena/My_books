namespace My_books.Data.VmModels
{
    public class AuthorVM
    {
        public string FullName { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public List<string> BooksName { get; set; }
    }
}
