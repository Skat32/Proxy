using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Abstracts
{
    public interface IProxyCheckerService
    {
        Task<bool> CheckProxy(string proxy);
        
        Task<bool> CheckProxy(string ip, string port);
        
        Task CheckProxies(IEnumerable<string> proxies);

        Task CheckProxies(Dictionary<string, string> proxies);
        
        
    }
}