using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using MacroMoney.Business.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MacroMoney.Data.IntegrationTests
{
    [TestClass]
    public class UserRepository_IntegrationTests
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
        public void CreateUser()
        {
            var newUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = "MyName"
            };

            using (var context = new MacroMoneyContext())
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }


    }
}
