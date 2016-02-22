using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMoney.Data.Contracts.RepositoryInterfaces;
using MacroMoney.Business.Entities;

namespace MacroMoney.Data.DataRepository
{
    public class TransactionRepository : DataRepositoryBase<Transaction>, ITransactionRepository
    {
        protected override Transaction AddEntity(MacroMoneyContext entityContext, Transaction entity)
        {
            entity.Id = Guid.NewGuid();
            entityContext.Transaction.Add(entity);
            return entity;
        }

        protected override Transaction UpdateEntity(MacroMoneyContext entityContext, Transaction entity)
        {
            entity = entityContext.Transaction.FirstOrDefault(e => e.Id == entity.Id);
            return entity;
        }

        protected override IEnumerable<Transaction> GetEntities(MacroMoneyContext entityContext)
        {
            var entities = entityContext.Transaction;
            return entities;
        }

        protected override Transaction GetEntity(MacroMoneyContext entityContext, Guid id)
        {
            var entity = entityContext.Transaction.FirstOrDefault(e => e.Id == id);
            return entity;
        }
    }
}
