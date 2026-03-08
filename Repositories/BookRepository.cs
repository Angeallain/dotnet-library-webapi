using LibraryWebApp.Models;
using LibraryWebApp.Data;

namespace LibraryWebApp.Repositories
{
    public class BookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context) 
            => _context = context;

        public List<Book> GetAll() 
            => _context.Books.ToList();

        public void Add(Book book) 
        { 
            _context.Books.Add(book); 
            _context.SaveChanges(); 
        }

        public void Update(Book book) 
        { 
            _context.Books.Update(book); 
            _context.SaveChanges(); 
        }
    }
}