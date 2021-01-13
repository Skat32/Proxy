using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.Entity;

namespace Logic.Abstracts
{
    public interface IProxyService
    {
        Task<Proxy> GetProxy();

        Task<IEnumerable<Proxy>> GetProxies(int count);
        
        /// <summary>
        /// Cохранение прокси
        /// </summary>
        /// <param name="proxy"></param>
        /// <returns></returns>
        Task SaveProxyAsync(Proxy proxy);

        /// <summary>
        /// Сохранение списка проксей
        /// </summary>
        /// <param name="proxies"></param>
        /// <returns></returns>
        Task SaveProxiesAsync(IEnumerable<Proxy> proxies);

        /// <summary>
        /// Получаем список прокси, которые необходимо проверить спустя какое-то время после проверки
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Proxy>> GetProxiesForWorker();
    }
}