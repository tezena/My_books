using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using My_books.Data.VmModels;
using My_books.Services;

namespace My_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BookServices _bookService;

        public BooksController(BookServices bookServices)
        {
             _bookService = bookServices;
        }

        [HttpPost("addBooks")]
        
        public async  Task<IActionResult> AddBook(BookVM book)
        {
              await _bookService.AddBooks(book); 
              
            return Ok(book);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllBooks()
        {
             var books= await _bookService.GetAllBooks();

            return Ok(books);
        }
        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetBookById([FromRoute] Guid id)
        {
            var book =await _bookService.GetBookById(id);
            if(book != null)
            {
                return Ok(book);

            }
            return NotFound();
        }


        [HttpPut]
        [Route("{id:guid}")]

        public async Task<IActionResult> UpdateBook([FromRoute] Guid id,BookVM book)
        {
            var result = await _bookService.UpdateBook(book,id);

            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }



        [HttpDelete]
        [Route("{id:guid}")]

        public async Task<IActionResult> DeleteBook([FromRoute] Guid id)
        {
           var result=   await _bookService.DeleteBook(id);

            if (result)
                return Ok();

            return NotFound();
           
        }
    }
}
