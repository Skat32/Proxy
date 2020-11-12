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

        /// <summary>
        /// включает / выключает вечную проверку проксей
        /// </summary>
        /// <param name="enable"> включен или выключен </param>
        void Switcher(bool enable);
    }
}