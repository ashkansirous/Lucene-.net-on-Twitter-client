namespace Twitter.Connector.Models
{
    public class Place
    {
        public string id { get; set; }
        public string url { get; set; }
        public string place_type { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string country_code { get; set; }
        public string country { get; set; }
        public object[] contained_within { get; set; }
        public Bounding_Box bounding_box { get; set; }
        public Attributes attributes { get; set; }
    }
}