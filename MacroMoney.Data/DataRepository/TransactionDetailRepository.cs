using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMoney.Business.Entities;
using MacroMoney.Data.Contracts.RepositoryInterfaces;

namespace MacroMoney.Data.DataRepository
{
    public class TransactionDetailRepository : DataRepositoryBase<TransactionDetail>, ITransactionDetailRepository
    {
        protected override TransactionDetail AddEntity(MacroMoneyContext entityContext, TransactionDetail entity)
        {
            entity.Id = Guid.NewGuid();
            entityContext.TransactionDetail.Add(entity);
            return entity;
        }

        protected override TransactionDetail UpdateEntity(MacroMoneyContext entityContext, TransactionDetail entity)
        {
            entity = entityContext.TransactionDetail.FirstOrDefault(e => e.Id == entity.Id);
            return entity;
        }

        protected override IEnumerable<TransactionDetail> GetEntities(MacroMoneyContext entityContext)
        {
            var entities = entityContext.TransactionDetail;
            return entities;
        }

        protected override TransactionDetail GetEntity(MacroMoneyContext entityContext, Guid id)
        {
            var entity = entityContext.TransactionDetail.FirstOrDefault(e => e.Id == id);
            return entity;
        }
    }
}
