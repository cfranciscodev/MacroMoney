using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMoney.Business.Entities;
using MacroMoney.Data.Contracts.RepositoryInterfaces;

namespace MacroMoney.Data.DataRepository
{
    public class CategoryRepository : DataRepositoryBase<Category>, ICategoryRepository
    {
        protected override Category AddEntity(MacroMoneyContext entityContext, Category entity)
        {
            entity.Id = Guid.NewGuid();
            entityContext.Category.Add(entity);
            return entity;
        }

        protected override Category UpdateEntity(MacroMoneyContext entityContext, Category entity)
        {
            entity = entityContext.Category.FirstOrDefault(e => e.Id == entity.Id);
            return entity;
        }

        protected override IEnumerable<Category> GetEntities(MacroMoneyContext entityContext)
        {
            var entities = entityContext.Category;
            return entities;
        }

        protected override Category GetEntity(MacroMoneyContext entityContext, Guid id)
        {
            var entity = entityContext.Category.FirstOrDefault(e => e.Id == id);
            return entity;
        }
    }
}
