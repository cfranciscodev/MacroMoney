using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Common.Contracts;
using MacroMoney.Business.Contracts;
using MacroMoney.Business.Entities;
using MacroMoney.Data.Contracts.RepositoryInterfaces;

namespace MacroMoney.Business.Managers
{
    public class CategoryManager : ManagerBase, ICategoryService
    {

        private readonly IDataRepositoryFactory _repoFactory;

        public CategoryManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _repoFactory = dataRepositoryFactory;
        }

        public List<Category> GetCategories()
        {
            return _repoFactory.GetDataRepository<ICategoryRepository>().Get().ToList();
        }
    }
}