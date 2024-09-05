

namespace URLShorteningService.Sevices
{
    public class UrlRepoService : IUrlRepo
    {
        public AppDbContext context { get; }
        public UrlRepoService(AppDbContext context)
        {
            this.context = context;
        }
        public void AddUrl(Url url)
        {
            context.Urls.Add(url);
            context.SaveChanges();
        }
        public Url GetUrl(string shortUrl)
        {
            var url = context.Urls.FirstOrDefault(u => u.ShortUrl == shortUrl);
            return url;
        }   
        public bool UrlExists(string LongUrl)
        {
            var url = context.Urls.FirstOrDefault(u => u.url == LongUrl);
            if (url != null)
            {
                return true;
            }
            return false;
        }
        public void UpdateUrl(string shortCode , UrlDTO url)
        {
            var _url = context.Urls.FirstOrDefault(u => u.ShortUrl == shortCode);
            if(_url != null)
            {
                _url.url = url.url;
                context.SaveChanges();
            }
        }
    }
}
