using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using My_books.Data;
using My_books.Data.Models;
using My_books.Data.VmModels;

namespace My_books.Services
{
    public class BookServices
    {

        private readonly BooksDbContext _context;

        public BookServices(BooksDbContext context)
        {
            _context = context;
        }


        public async Task AddBooks(BookVM book)
        {
            var _book = new Book()
            {
                id = Guid.NewGuid(),
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Genre = book.Genre,
                IsRead = book.IsRead,
                ReadDate = book.IsRead ? book.ReadDate.Value : null,
                Rate = book.Rate,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now
            };
              await    _context.Books.AddAsync(_book);
          await  _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBooks()
        {
             return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookById(Guid id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> UpdateBook(BookVM book,Guid id)
        {
            var _book = await _context.Books.FindAsync(id);

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;   
                _book.Author = book.Author;
                _book.IsRead = book.IsRead;
                _book.Genre = book.Genre;
                _book.ReadDate = book.ReadDate;
                _book.Rate = book.Rate; 
                _book.CoverUrl= book.CoverUrl;
                _book.DateAdded = DateTime.Now;


             await  _context.SaveChangesAsync();

            return _book;
                    
            }

            return null;


        }
        public async Task<bool> DeleteBook(Guid id)
        {
            var book=await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();

                return true;
            }

            return false;

           
        }
    }
}
