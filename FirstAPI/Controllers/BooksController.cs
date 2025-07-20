using FirstAPI.Data;
using FirstAPI.MedPatt.Books.Commands.CreateBook;
using FirstAPI.MedPatt.Books.Commands.DeleteBook;
using FirstAPI.MedPatt.Books.Commands.UpdateBook;
using FirstAPI.MedPatt.Books.Queries.Books.GetBooks;
using FirstAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly ISender _sender;
        public BooksController(ApplicationContext context,ISender sender)
        {
            _context= context;
            _sender= sender;
        }
    
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _sender.Send(new GetBooksQuery());
            return Ok(books);
        }
    
        [HttpPost]
        public async Task<IActionResult> AddBook(CreateBookCommand command)
        {
            if (command == null)
                return BadRequest();
            var bookId = await _sender.Send(command);

         
            return Ok(bookId);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id,Book updateBook)
        {
            var result = await _sender.Send(new UpdateBookCommand(
                id,
                updateBook.Title,
                updateBook.Author,
                updateBook.PublishedYear
                ));
            if(!result)
                return BadRequest();
            
            return NoContent();
                
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _sender.Send(new DeleteBookCommand(id));
            if (!result)
                return NotFound();
            
            return NoContent();
        }
    }
}
