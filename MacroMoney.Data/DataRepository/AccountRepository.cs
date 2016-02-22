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
            entity.Id = Guid.NewGuid();
            entityContext.Account.Add(entity);
            return entity;
        }

        protected override Account UpdateEntity(MacroMoneyContext entityContext, Account entity)
        {
            entity = entityContext.Account.FirstOrDefault(e => e.Id == entity.Id);
            return entity;
        }

        protected override IEnumerable<Account> GetEntities(MacroMoneyContext entityContext)
        {
            var entities = entityContext.Account;
            return entities;
        }

        protected override Account GetEntity(MacroMoneyContext entityContext, Guid id)
        {
            var entity = entityContext.Account.FirstOrDefault(e => e.Id == id);
            return entity;
        }

        //public Account GetAccountInfoByUserId(Guid id)
        //{
        //    var account = new Account();
        //    using (var entityContext = new MacroMoneyContext())
        //    {
        //        account = entityContext.Account
        //            .FirstOrDefault(a => a.Id == id);
        //    }
        //    return account;
        //}

        public List<Account> GetAccountsByUserId(Guid userId)
        {
            var accounts = new List<Account>();
            using (var entityContext = new MacroMoneyContext())
            {
                accounts = entityContext.Account
                    .Include(e => e.Transactions)
                    .Include(e => e.Transactions.Select(td => td.TransactionDetails))
                    .Where(a => a.UserId == userId).ToList();
            }
            return accounts;
        }

    }
}
