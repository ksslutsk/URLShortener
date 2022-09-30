using Microsoft.AspNetCore.Mvc;
using URLShortenerBACK.Sevices;
using URLShortenerBACK.Models;
using URLShortenerBACK.DTO;
using Microsoft.AspNetCore.Cors;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;

namespace URLShortenerBACK.Controllers
{
    [Route("url")]
    [ApiController]
    [EnableCors("OpenCORSPolicy")]
    public class URLController : Controller
    {
        private readonly URLService _urlService;
        public URLController(URLService urlService)
        {
            _urlService = urlService;
        }
        [HttpGet]
        public async Task<IEnumerable<URL>> GetURLs()
        {
            return await _urlService.GetURLs();
        }
        [HttpGet("{shortUrl}")]
        public RedirectResult GetLongUrl(string shortUrl)
        {
            LongLink url = _urlService.GetLongUrl(shortUrl);
            //var response = new HttpResponseMessage(System.Net.HttpStatusCode.Moved);
            //response.Headers.Location = new Uri(url.LongURL);

            
            return Redirect(url.LongURL);
        }
        [HttpPost]
        public async Task<URL> CreateShortURL(URLDTO urldto)
        {
            var res = await _urlService.AddNewUrl(urldto.Url, urldto.Creator);
            return res;
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUrl(long id)
        {
            var url = await _urlService.DeleteURL(id);
            if (url == null) return NotFound();

            return NoContent();
        }
    }
}
