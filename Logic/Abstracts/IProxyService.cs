using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logic.Abstracts
{
    public interface IProxyService
    {
        Task<string> GetProxy();

        Task<IEnumerable<string>> GetProxies(int count);
    }
}