using Microsoft.EntityFrameworkCore;
using My_books.Data;
using My_books.Data.Models;
using My_books.Data.VmModels;

namespace My_books.Services
{
    public class AuthorServices
    {
        private readonly BooksDbContext _context;

        public AuthorServices(BooksDbContext context)
        {
            _context = context;
        }
        public async Task AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Id = Guid.NewGuid(),
                FullName=author.FullName
                
            };
            await _context.Authors.AddAsync(_author);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Author>> GetAllAuthors()
        {
            return await _context.Authors.ToListAsync();
        }
    }
}
