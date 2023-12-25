using Microsoft.EntityFrameworkCore;
using My_books.Data.Models;

namespace My_books.Data
{
    public class BooksDbContext : DbContext
    {
        public BooksDbContext(DbContextOptions<BooksDbContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author_Book>().HasOne(b => b.Book).WithMany(ba=>ba.author_Books).HasForeignKey(bi=>bi.BookId);
            modelBuilder.Entity<Author_Book>().HasOne(b=>b.Author).WithMany(ba => ba.author_Books).HasForeignKey(bi => bi.AuthorId);



        }

        public DbSet<Book>Books { get; set; }
        public DbSet<Publisher>Publishers { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Author_Book> BookAuthors { get; set; }

    }
}
