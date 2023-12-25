using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using My_books.Data.VmModels;
using My_books.Services;

namespace My_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        public PublisherServices _publisherService;

        public PublishersController(PublisherServices publisherServices)
        {
            _publisherService = publisherServices;
        }

        [HttpPost("addPublisher")]

        public async Task<IActionResult> AddPublisher(PublisherVM publisher)
        {
            await _publisherService.AddPublisher(publisher);

            return Ok(publisher);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllPublishers()
        {
            var publishers = await _publisherService.GetAllPublishers();
            return Ok(publishers);
        }
    }
}
