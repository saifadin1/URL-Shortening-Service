namespace URLShorteningService.Sevices
{
    public interface IUrlRepo
    {
        public void AddUrl(Url url);
        public Url GetUrl(string shortUrl);
        public bool UrlExists(string LongUrl);
    }
}
