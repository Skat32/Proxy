using System.Collections.Generic;

namespace Models.Entity
{
    public class Country : Base
    {
        public string Name { get; set; }

        public IEnumerable<Proxy> Proxies { get; set; }
    }
}