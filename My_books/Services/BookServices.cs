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
           
                Genre = book.Genre,
                IsRead = book.IsRead,
                ReadDate = book.IsRead ? book.ReadDate.Value : null,
                Rate = book.Rate,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId= book.PublisherId,
            };
              await    _context.Books.AddAsync(_book);
          await  _context.SaveChangesAsync();

            foreach (Guid Id in book.AuthorsId)
            {
                var book_author = new Author_Book()
                {
                    Id = Guid.NewGuid(),
                    AuthorId= Id,
                    BookId=_book.id
                    };

                await _context.BookAuthors.AddAsync(book_author);
                await _context.SaveChangesAsync();

            }

        }

        public async Task<List<BookGetVM>> GetAllBooks()
        {
            var _books = await _context.Books.Select(book => new BookGetVM()
            {
                id = book.id,
                Title = book.Title,
                Description = book.Description,
                Genre = book.Genre,
                IsRead = book.IsRead,
                Rate = book.Rate,
                ReadDate = book.ReadDate,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorsName = book.author_Books.Select(a => a.Author.FullName).ToList(),
            }).ToListAsync();


            return _books;
        }

        public async Task<BookGetVM> GetBookById(Guid id)
        {
            var _book =await _context.Books.Where(b => b.id == id).Select(book => new BookGetVM()
            {
                id=book.id,
                Title = book.Title,
                Description = book.Description,
                Genre = book.Genre,
                IsRead = book.IsRead,
                Rate = book.Rate,
                ReadDate = book.ReadDate,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorsName = book.author_Books.Select(a => a.Author.FullName).ToList(),
            }).FirstOrDefaultAsync();


            return _book;
        }

        public async Task<Book> UpdateBook(BookVM book,Guid id)
        {
            var _book = await _context.Books.FindAsync(id);

            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;   
              
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
