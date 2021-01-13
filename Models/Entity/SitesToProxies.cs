namespace Models.Entity
{
    public class SitesToProxies : Base
    {
        public Site Site { get; set; }

        public Proxy Proxy { get; set; }

        public long SiteId { get; set; }

        public long ProxyId { get; set; }

        public bool IsWorked { get; set; }
    }
}