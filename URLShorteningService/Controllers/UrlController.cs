
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
                return Created("", _url);
            }
            return BadRequest();
        }

        [HttpGet("{shortUrl}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(string shortUrl)
        {
            var url = _urlRepo.GetUrl(shortUrl);
            if (url != null)
            {
                ModifiedUrl _url = new ModifiedUrl()
                {
                    createdAt = url.createdAt,
                    updatedAt = url.updatedAt,
                    shortCode = url.ShortUrl,
                    Url = url.url
                };
                return Ok(_url);
            }
            return NotFound();
        }

        [HttpPut("{shortCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(string shortCode, UrlDTO url)
        {
            var _url = _urlRepo.GetUrl(shortCode);
            if (_url != null)
            {
                _urlRepo.UpdateUrl(shortCode , url);
                return Ok(_url);
            }
            return BadRequest();
        }

        [HttpDelete("{ShortCode}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(string ShortCode)
        {
            var url = _urlRepo.GetUrl(ShortCode);
            if (url != null)
            {
                _urlRepo.DeleteUrl(ShortCode);
                return NoContent();
            }
            return NotFound();
        }

        [HttpGet("stats/{ShortCode}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetStats(string ShortCode)
        {
            var url = _urlRepo.GetUrl(ShortCode);
            if (url != null)
            {
                return Ok(url);
            }
            return NotFound();
        }

    }
}