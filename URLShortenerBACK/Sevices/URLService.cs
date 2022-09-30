using URLShortenerBACK.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HashidsNet;
using URLShortenerBACK.DTO;

namespace URLShortenerBACK.Sevices
{
    public class URLService
    {
        private readonly DataContext _context;
        public URLService(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<URL>> GetURLs()
        {
            var urls = this._context.URLs;
            return urls;
        }
        public async Task<URL> AddNewUrl(string url, long userId)
        {
            URL model = GenURLModel(url, userId);
            var res = await _context.URLs.FindAsync(model.ID);
            if (res == null)
            {
                this._context.Add(model);
                this._context.SaveChanges();
                return model;
            }
            return res;
        }
        private URL GenURLModel(string url, long userId)
        {
            var hashids = new Hashids(url);
            var id = hashids.Encode(1, 2, 3);
            URL model= new URL();

            model.LongURL = url;
            model.ShortURL = id;
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = userId;
            return model;
        }
        public async Task<URL?> DeleteURL(long id)
        {
            var url = await _context.URLs.FindAsync(id);
            if (url == null) return null;
            _context.URLs.Remove(url);
            await _context.SaveChangesAsync();
            return url;
        }
        public LongLink GetLongUrl(string shortUrl)
        {
            var res = (from url in _context.URLs where url.ShortURL == shortUrl select url).ToList();
            LongLink ll = new LongLink(res[0].LongURL);
            return ll;
        }
    }
}
