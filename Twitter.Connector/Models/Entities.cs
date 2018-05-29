namespace Twitter.Connector.Models
{
    public class Entities
    {
        public Hashtag[] hashtags { get; set; }
        public object[] symbols { get; set; }
        public User_Mentions[] user_mentions { get; set; }
        public Url[] urls { get; set; }
        public Medium[] media { get; set; }
    }
}