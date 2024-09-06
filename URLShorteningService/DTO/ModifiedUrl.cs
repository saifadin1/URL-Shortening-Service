namespace URLShorteningService.DTO
{
    public class ModifiedUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string shortCode { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
