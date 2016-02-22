using System;
using System.Linq;
using System.Transactions;
using MacroMoney.Business.Entities;
using MacroMoney.Data.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MacroMoney.Data.IntegrationTests
{
    [TestClass]
    public class CategoryRepository_IntegrationTests
    {
        private TransactionScope trans = null;

        [TestInitialize]
        public void SetUp()
        {
            trans = new TransactionScope(TransactionScopeOption.Required);
        }
        [TestCleanup]
        public void TearDown()
        {
            trans.Dispose();
        }

        [TestMethod]
        public void CreateCategory()
        {
            var category = new Category {Id = Guid.NewGuid(), Description = "Food"};

            var categoryRepo = new CategoryRepository();
            categoryRepo.Add(category);

            var categories = categoryRepo.Get();
            Assert.IsTrue(categories.Any(c => c.Description == "Food"));
        }
    }
}