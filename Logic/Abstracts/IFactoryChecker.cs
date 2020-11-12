using Models.Enums;

namespace Logic.Abstracts
{
    public interface IFactoryChecker
    {
        /// <summary>
        /// Получаем чеккер относительно его типа
        /// </summary>
        /// <param name="typeChecker"> тип чеккера </param>
        /// <returns></returns>
        IProxyCheckerService GetChecker(TypeCheckerEnum typeChecker);
    }
}