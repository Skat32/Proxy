using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataLayer;
using Flurl.Http;
using Logic.Abstracts;
using Microsoft.EntityFrameworkCore;
using Models.Entity;
using Models.Options;
using Timer = System.Timers.Timer;

namespace Logic.Services
{
    public class ProxyCheckerService : IProxyCheckerService, IProxyCheckerWorker
    {
        private readonly ProxyDbContext _context;
        private readonly ILoggerService _loggerService;

        public ProxyCheckerService(ProxyDbContext context, ILoggerService loggerService)
        {
            _context = context;
            _loggerService = loggerService;
        }
        
        public Task<bool> CheckProxyAsync(string proxy)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CheckProxyAsync(string ip, string port)
        {
            throw new System.NotImplementedException();
        }

        public Task CheckProxiesAsync(IEnumerable<string> proxies)
        {
            throw new System.NotImplementedException();
        }

        public Task CheckProxiesAsync(Dictionary<string, string> proxies)
        {
            throw new System.NotImplementedException();
        }
        
        public async Task StartWorkerAsync(int minutes)
        {
            while (ProxyWorkerSettings.Enable)
            {
                var proxies = await _context.Proxies
                    .Where(proxy => !proxy.IsDeleted && proxy.DateNexCheck > DateTime.Now).ToListAsync();

                foreach (var proxy in proxies)
                {
                    
                }

                await _context.SaveChangesAsync();
            }
        }

        public void Switcher(bool enable)
        {
            ProxyWorkerSettings.Enable = enable;
        }

        #region | Private methods |

        private async Task<bool> CheckAsync(string proxy)
        {
            var timer = new Timer();

            timer.Start();
            var result = await TestAsync("https://api.ipify.org");
            timer.Stop();
            
            throw new NotImplementedException();
            
            // return timer.Interval < 1000 && !string.IsNullOrEmpty(result);
        }

        private async Task<string> TestAsync(string url, CancellationToken cancellationToken = default)
        {
            var result = await GetStringAsync(url, cancellationToken);

            return result;
        }

        #endregion
        
        
        /// <summary>
        /// Получаем строку ответа
        /// </summary>
        /// <param name="url"> Ссылка на API </param>
        /// <param name="cancellationToken"> Токен отмены операции </param>
        /// <returns> строка ответа </returns>
        protected virtual async Task<string> GetStringAsync(string url, CancellationToken cancellationToken = default)
        {
            try
            {
                return await url.WithHeaders(GetHeaders()).WithCookies(GetCookies()).GetStringAsync(cancellationToken);
            }
            catch (Exception e)
            {
                _loggerService.Error(e);
                return null;
            }
        }

        /// <summary>
        /// Получаем заголовки для запроса
        /// </summary>
        /// <returns> Headers </returns>
        protected object GetHeaders()
        {
            return new { };
        }

        /// <summary>
        /// Получаем обект кук дял запроса
        /// </summary>
        /// <returns> Cookies </returns>
        protected object GetCookies()
        {
            return new { };
        }
    }
}