using System.Threading.Tasks;

namespace Logic.Abstracts
{
    public interface IProxyCheckerWorker
    {
        /// <summary>
        /// Запуск воркера для парсинга
        /// </summary>
        /// <returns></returns>
        Task StartWorkerAsync(int minutes);
    }
}