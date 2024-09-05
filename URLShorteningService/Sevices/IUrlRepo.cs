
namespace URLShorteningService.Sevices
{
    public interface IUrlRepo
    {
        public void AddUrl(Url url);
        public Url GetUrl(string shortUrl);
        void UpdateUrl(string shortCode , UrlDTO url);
        public bool UrlExists(string LongUrl);
    }
}
