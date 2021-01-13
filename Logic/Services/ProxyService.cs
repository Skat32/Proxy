using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Logic.Abstracts;
using Microsoft.EntityFrameworkCore;
using Models.Entity;

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
        
        public async Task<Proxy> GetProxy()
        {
            var result = await _context.Proxies.SingleOrDefaultAsync(x => x.IsWorked && !x.IsDeleted);

            return result;
        }

        public async Task<IEnumerable<Proxy>> GetProxies(int count)
        {
            if (count > MaxCountProxies) count = MaxCountProxies;

            return await _context.Proxies.Where(x => x.IsWorked && !x.IsDeleted).Take(count).ToArrayAsync();
        }

        public async Task SaveProxyAsync(Proxy proxy)
        {
            await _context.Proxies.AddAsync(proxy);
            await _context.SaveChangesAsync();
        }

        public async Task SaveProxiesAsync(IEnumerable<Proxy> proxies)
        {
            await _context.Proxies.AddRangeAsync(proxies);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Proxy>> GetProxiesForWorker()
        {
            return _context.Proxies.Where(x => !x.IsDeleted && x.DateNexCheck > DateTime.Now);
        }
    }
}