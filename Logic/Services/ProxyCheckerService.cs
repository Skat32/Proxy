using System.Collections.Generic;
using System.Threading.Tasks;
using Logic.Abstracts;

namespace Logic.Services
{
    public class ProxyCheckerService : IProxyCheckerService
    {

        public Task<bool> CheckProxy(string proxy)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CheckProxy(string ip, string port)
        {
            throw new System.NotImplementedException();
        }

        public Task CheckProxies(IEnumerable<string> proxies)
        {
            throw new System.NotImplementedException();
        }

        public Task CheckProxies(Dictionary<string, string> proxies)
        {
            throw new System.NotImplementedException();
        }
    }
}