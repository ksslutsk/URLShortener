namespace URLShortenerBACK.Models
{
    public class URL
    {
        public long ID { get; set; }
        public string LongURL { get; set; }
        public string ShortURL { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
