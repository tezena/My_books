using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_books.Data.VmModels;
using My_books.Services;

namespace My_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public AuthorServices _authorService;

        public AuthorsController(AuthorServices authorServices)
        {
            _authorService = authorServices;
        }

        [HttpPost("addAuthor")]

        public async Task<IActionResult> AddAuthor(AuthorVM author)
        {
            await _authorService.AddAuthor(author);

            return Ok(author);
        }


        [HttpGet]

        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthors();

            return Ok(authors);
        }

        [HttpGet]
        [Route("{id:guid}")]

        public async Task<IActionResult> GetAuthorById([FromRoute] Guid id)
        {
            var author = await _authorService.GetAuthorById(id);

            return Ok(author);
        }
    }
}
