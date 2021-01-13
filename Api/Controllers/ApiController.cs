using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.Options;

namespace Api.Controllers
{
    [ApiController]
    public class ApiController : Controller
    {
        private readonly IProxyService _proxyService;
        private readonly ApiProxyOptions _options;

        public ApiController(IProxyService proxyService, IOptions<ApiProxyOptions> options)
        {
            _proxyService = proxyService;
            _options = options.Value;
        }
        
        [HttpGet]
        public async Task<string> GetProxy()
        {
            var result = await _proxyService.GetProxy();
            
            return result.ToString();
        }
        
        [HttpGet]
        public async Task<IEnumerable<string>> GetProxies()
        {
            var result =  await _proxyService.GetProxies(_options.CountFreeProxies);

            return result.Select(x => x.ToString());
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetProxies(int count)
        {
            var result =  await _proxyService.GetProxies(count);
            
            return result.Select(x => x.ToString());
        }

        [HttpGet]
        public void EnableAsync(bool enable)
        {
            ProxyWorkerSettings.Enable = enable;
        }
        
    }
}