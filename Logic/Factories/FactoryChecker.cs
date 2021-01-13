using Logic.Abstracts;
using Models.Enums;

namespace Logic.Factories
{
    public class FactoryChecker : IFactoryChecker
    {
        public IProxyCheckerService GetChecker(TypeCheckerEnum typeChecker)
        {
            throw new System.NotImplementedException();
        }
    }
}