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
        private readonly IProxyService _proxyService;
        private readonly ILoggerService _loggerService;

        public ProxyCheckerService(IProxyService proxyService, ILoggerService loggerService)
        {
            _proxyService = proxyService;
            _loggerService = loggerService;
        }
        
        public async Task<bool> CheckProxyAsync(string proxy)
        {
            return await CheckAsync(proxy);
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
                var proxies = await _proxyService.GetProxiesForWorker();

                var resultProxies = new List<Proxy>();
                foreach (var proxy in proxies.ToList())
                {
                    // code

                    resultProxies.Add(proxy);
                }

                await _proxyService.SaveProxiesAsync(resultProxies);
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

        /// <summary>
        /// Парсим прокси из строки на отдельный ip и port
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns></returns>
        private static (string ip, string port) ParseProxy(string proxy)
        {
            var proxySplit = proxy.Split(':');

            return (proxySplit[0], proxySplit[1]);
        }
    }
}