using System.ComponentModel.DataAnnotations;

namespace URLShorteningService.Models
{
    public class Url
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string url { get; set; } = string.Empty;
        public string ShortUrl { get; set; } = string.Empty;
        public int accessCount { get; set; } = 0;
        public DateTime createdAt { get; set; } = DateTime.Now;
        public DateTime updatedAt { get; set; } = DateTime.Now;
    }
}
