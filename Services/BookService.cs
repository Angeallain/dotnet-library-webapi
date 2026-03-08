using LibraryWebApp.Models;
using LibraryWebApp.Repositories;

namespace LibraryWebApp.Services
{
    public class BookService
    {
        private readonly BookRepository _repo;

        public BookService(BookRepository repo) 
            => _repo = repo;

        public List<Book> GetBooks() 
            => _repo.GetAll();

        public void AddBook(Book book) 
            => _repo.Add(book);

        public void BorrowBook(int id)
        {
            var book = _repo.GetAll().FirstOrDefault(b => b.Id == id);
            if (book != null && !book.IsBorrowed)
            {
                book.IsBorrowed = true;
                _repo.Update(book);
            }
        }
    }
}