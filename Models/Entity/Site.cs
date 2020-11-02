namespace Models.Entity
{
    public class Site : Base
    {
        public string Url { get; set; }
        public Proxy Proxy { get; set; }
        public long ProxyId { get; set; }
    }
}