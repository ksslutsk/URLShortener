namespace URLShortenerBACK.DTO
{
    public class LongLink
    {
        public LongLink(string longURL)
        {
            LongURL = longURL;
        }

        public string LongURL { get; set; }
    }
}
