
using URLShorteningService.DTO;

namespace URLShorteningService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        public IUrlRepo _urlRepo;
        public UrlController(IUrlRepo urlRepo)
        {
            _urlRepo = urlRepo;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Shorten(UrlDTO url)
        {
            bool found = _urlRepo.UrlExists(url.url);
            if (found == false)
            {
                var _url = new Url { url = url.url, ShortUrl = CodeGenerator.Generate().ToString() };
                _urlRepo.AddUrl(_url);
                return Ok(_url);
            }
            return BadRequest();
        }
    }
}