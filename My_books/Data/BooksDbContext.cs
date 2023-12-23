using Microsoft.EntityFrameworkCore;
using My_books.Data.Models;

namespace My_books.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options):base(options)
        {
            
        }

        public DbSet<Book>Books { get; set; }

    }
}
