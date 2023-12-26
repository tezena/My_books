using Microsoft.EntityFrameworkCore;
using My_books.Data.Models;
using My_books.Data.VmModels;
using My_books.Data;

namespace My_books.Services
{
    public class PublisherServices

    {
        private readonly BooksDbContext _context;

        public PublisherServices(BooksDbContext context)
        {
            _context = context;
        }
        public async Task AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Id = Guid.NewGuid(),
                Name = publisher.Name

            };
            await _context.Publishers.AddAsync(_publisher);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PublisherWithBooksVM>> GetAllPublishers()
        {
            var _publishers = await _context.Publishers.Select(publisher => new PublisherWithBooksVM()
            {
                Id = publisher.Id,
                Name = publisher.Name,
                
                BookAouthor=publisher.Books.Select(book=>new BookWAuthor()
                {
                    title = book.Title,
                    Authors=book.author_Books.Select(a=>a.Author.FullName).ToList()
                }).ToList(),
            }).ToListAsync();

            return _publishers;
        }
    }
}
