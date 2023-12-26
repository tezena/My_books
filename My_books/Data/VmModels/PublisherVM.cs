namespace My_books.Data.VmModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

       public List<BookWAuthor> BookAouthor { get; set; }

    }

    public class BookWAuthor
    {
        public string title { get; set; }
        public List<string> Authors { get; set; }
    }
}
