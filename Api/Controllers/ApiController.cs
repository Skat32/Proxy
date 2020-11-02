using System.Collections.Generic;
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
            return await _proxyService.GetProxy();
        }
        
        [HttpGet]
        public async Task<IEnumerable<string>> GetProxies()
        {
            return await _proxyService.GetProxies(_options.CountFreeProxies);
        }

        [HttpGet]
        public async Task<IEnumerable<string>> GetProxies(int count)
        {
            return await _proxyService.GetProxies(count);
        }
    }
}