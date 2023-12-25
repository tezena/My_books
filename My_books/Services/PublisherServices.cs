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

        public async Task<List<Publisher>> GetAllPublishers()
        {
            return await _context.Publishers.ToListAsync();
        }
    }
}
