using Autofac;
using Core.Common.Contracts;
using Core.Common.Core;

namespace MacroMoney.Data
{
    public class DataRepositoryFactory : IDataRepositoryFactory
    {
        T IDataRepositoryFactory.GetDataRepository<T>()
        {
            return IoC.Container.Resolve<T>();
        }
    }
}
