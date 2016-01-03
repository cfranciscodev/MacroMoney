using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Core.Common.Contracts
{
    public interface IDataRepository
    {

    }

    public interface IDataRepository<T> : IDataRepository
        where T : class, IIdentifier, new()
    {
        T Add(T entity);

        T AddOrUpdate(T entity);

        void Remove(T entity);

        void Remove(Guid id);

        T Update(T entity);

        IEnumerable<T> Get();

        T Get(Guid id);
    }

    public interface IDataGraphRepository<T> : IDataRepository
        where T : IObjectWithState, IIdentifier, new()
    {
        T Get(int id);

        T Save(T entity);
    }
}
