using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMoney.Business.Entities;
using MacroMoney.Data.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MacroMoney.Data.IntegrationTests
{
    [TestClass]
    public class AccountRepository_IntegrationTests
    {

        private Guid myUserId = new Guid("8fd0cf30-c56f-496d-896b-151714cd9e2c");

        [TestMethod]
        public void AddAccount_SavesAccountToDb()
        {

            var account = new Account(myUserId, "Checking", "Chase Sucks", 0m);
            var repo = new AccountRepository();
            repo.Add(account);

            var accountFromDb = repo.GetAccountInfoById(account.Id);
            Assert.AreEqual(account.Name, accountFromDb.Name);
        }

        [TestMethod]
        public void RemoveAccount_DeletesAccountFromDb()
        {

            var account = new Account(myUserId, "Checking", "Chase Sucks2", 0m);
            var repo = new AccountRepository();
            repo.Add(account);

            var accountFromDb = repo.GetAccountInfoById(account.Id);
            repo.Remove(accountFromDb);

            accountFromDb = repo.GetAccountInfoById(account.Id);

            Assert.IsNull(accountFromDb);
        }

        [TestMethod]
        public void UpdateAccount_UpdatesAccountInDb()
        {

            var account = new Account(myUserId, "Checking", "Chase Sucks2", 0m);
            var repo = new AccountRepository();
            repo.Add(account);

            var accountFromDb = repo.GetAccountInfoById(account.Id);
            accountFromDb.Name = "Waka Waka";

            repo.Update(accountFromDb);

            accountFromDb = repo.GetAccountInfoById(account.Id);

            Assert.AreEqual("Waka Waka", accountFromDb.Name);
        }
    }
}
