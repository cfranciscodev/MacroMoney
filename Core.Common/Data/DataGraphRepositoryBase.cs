using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;

namespace Core.Common.Data
{
    public abstract class DataGraphRepositoryBase<T, U> : IDataGraphRepository<T>
        where T : ObjectWithState, IIdentifier, new()
        where U : DbContext, new()
    {
        protected abstract void AddToEntityContext(U entityContext, T entity);
        protected abstract T GetEntity(U entityContext, int id);

        public T Get(int id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, id);
                entity.ClearEntityObjectState();
                return entity;
            }
        }

        public T Save(T entity)
        {
            using (U entityContext = new U())
            {
                AddToEntityContext(entityContext, entity);
                ApplyStateChanges(entityContext, entity);
                entityContext.SaveChanges();
                entity.ClearEntityObjectState();
            }
            return entity;
        }

        private void ApplyStateChanges(U entityContext, T entity)
        {
            foreach (var entry in entityContext.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = ConvertState(stateInfo.State);
            }
        }

        private EntityState ConvertState(ObjectState state)
        {
            switch (state)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;

            }
        }
    }
}
