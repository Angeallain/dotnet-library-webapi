using Microsoft.AspNetCore.Mvc;
using LibraryWebApp.Models;
using LibraryWebApp.Services;

namespace LibraryWebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly BookService _service;

        public BookController(BookService service) 
            => _service = service;

        [HttpGet]
        public IActionResult GetAll() 
            => Ok(_service.GetBooks());

        [HttpPost]
        public IActionResult Add([FromBody] Book book)
        {
            _service.AddBook(book);
            return Ok("Book added successfully");
        }

        [HttpPut("{id}/borrow")]
        public IActionResult Borrow(int id)
        {
            _service.BorrowBook(id);
            return Ok("Book borrowed successfully");
        }
    }
}