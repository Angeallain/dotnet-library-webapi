using Microsoft.EntityFrameworkCore;
using LibraryWebApp.Models;

namespace LibraryWebApp.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) 
            : base(options) { }

        public DbSet<Book> Books { get; set; }
    }
}