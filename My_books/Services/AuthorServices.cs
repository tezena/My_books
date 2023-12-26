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

        public async Task<List<AuthorWithBooksVM>> GetAllAuthors()
        { 
            var _authors=await _context.Authors.Select(author=>new AuthorWithBooksVM()
            {
                Id = author.Id,
                FullName=author.FullName,
                BooksName=author.author_Books.Select(b=>b.Book.Title).ToList(),
            }).ToListAsync();

            return _authors;
            
        }


        public async Task<AuthorWithBooksVM> GetAuthorById(Guid id)
        {
            var _author = await _context.Authors.Where(a => a.Id == id).Select(author => new AuthorWithBooksVM()
            {
                Id = author.Id,
                FullName = author.FullName,
                BooksName = author.author_Books.Select(b => b.Book.Title).ToList(),
            }).FirstOrDefaultAsync();

            return _author;

        }
    }
}
