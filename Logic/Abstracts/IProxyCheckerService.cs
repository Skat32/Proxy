using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Abstracts
{
    public interface IProxyCheckerService
    {
        Task<bool> CheckProxyAsync(string proxy);
        
        Task<bool> CheckProxyAsync(string ip, string port);
        
        Task CheckProxiesAsync(IEnumerable<string> proxies);

        Task CheckProxiesAsync(Dictionary<string, string> proxies);
        
        
    }
}