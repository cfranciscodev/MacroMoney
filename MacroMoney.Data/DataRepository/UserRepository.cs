using System;
using System.Collections.Generic;
using System.Linq;
using MacroMoney.Business.Entities;
using MacroMoney.Data.Contracts.RepositoryInterfaces;

namespace MacroMoney.Data.DataRepository
{
    public class UserRepository : DataRepositoryBase<User>, IUserRepository
    {
        protected override User AddEntity(MacroMoneyContext entityContext, User entity)
        {
            entity.Id = Guid.NewGuid();
            entityContext.Users.Add(entity);
            return entity;
        }

        protected override User UpdateEntity(MacroMoneyContext entityContext, User entity)
        {
            entity = entityContext.Users.FirstOrDefault(e => e.Id == entity.Id);
            return entity;
        }

        protected override IEnumerable<User> GetEntities(MacroMoneyContext entityContext)
        {
            var entities = entityContext.Users;
            return entities;
        }

        protected override User GetEntity(MacroMoneyContext entityContext, Guid id)
        {
            var entity = entityContext.Users.FirstOrDefault(e => e.Id == id);
            return entity;
        }

        public User GetAccountInfoById(Guid id)
        {
            var users = new User();
            using (var entityContext = new MacroMoneyContext())
            {
                users = entityContext.Users
                    .FirstOrDefault(a => a.Id == id);
            }
            return users;
        }

    }
}
