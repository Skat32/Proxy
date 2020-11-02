using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer;
using Logic.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    public class ProxyService : IProxyService
    {
        private readonly ProxyDbContext _context;
        private const int MaxCountProxies = 100;

        public ProxyService(ProxyDbContext context)
        {
            _context = context;
        }
        
        public async Task<string> GetProxy()
        {
            var result = await _context.Proxies.SingleOrDefaultAsync(x => x.IsWorked && !x.IsDeleted);

            return result.ToString();
        }

        public Task<IEnumerable<string>> GetProxies(int count)
        {
            if (count > MaxCountProxies) count = MaxCountProxies;
            
            throw new System.NotImplementedException();
        }
    }
}