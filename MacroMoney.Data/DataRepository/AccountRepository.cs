using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Data;
using MacroMoney.Business.Entities;
using MacroMoney.Data.Contracts.RepositoryInterfaces;

namespace MacroMoney.Data.DataRepository
{
    public class AccountRepository : DataRepositoryBase<Account>, IAccountRepository
    {
        protected override Account AddEntity(MacroMoneyContext entityContext, Account entity)
        {
            entityContext.Account.Add(entity);
            return entity;
        }

        protected override Account UpdateEntity(MacroMoneyContext entityContext, Account entity)
        {
            entity = (from e in entityContext.Account
                      where e.Id == entity.Id
                      select e).FirstOrDefault();
            return entity;
        }

        protected override IEnumerable<Account> GetEntities(MacroMoneyContext entityContext)
        {
            var entities = (from e in entityContext.Account
                            select e);
            return entities;
        }

        protected override Account GetEntity(MacroMoneyContext entityContext, Guid id)
        {
            var entity = (from e in entityContext.Account
                          where e.Id == id
                          select e).FirstOrDefault();
            return entity;
        }

        public Account GetAccountInfoById(Guid id)
        {
            var account = new Account();
            using (var entityContext = new MacroMoneyContext())
            {
                account = entityContext.Account
                    .FirstOrDefault(a => a.Id == id);
            }
            return account;
        }
    }
}
