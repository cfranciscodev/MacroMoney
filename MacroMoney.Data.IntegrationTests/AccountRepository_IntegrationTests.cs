using System;
using System.Transactions;
using MacroMoney.Business.Entities;
using MacroMoney.Data.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MacroMoney.Data.IntegrationTests
{
    [TestClass]
    public class AccountRepository_IntegrationTests
    {

        private User myUser = new User();
        private TransactionScope trans = null;

        [TestInitialize]
        public void SetUp()
        {
            trans = new TransactionScope(TransactionScopeOption.Required);
            myUser = TestEntityMaker.GetUser();

            var userRepo = new UserRepository();
            userRepo.Add(myUser);
        }
        [TestCleanup]
        public void TearDown()
        {
            trans.Dispose();
        }

        [TestMethod]
        public void AddAccount_SavesAccountToDb()
        {

            //var account = new Account(myUser.Id, "Checking", "Chase Sucks", 0m);
            var account = new Account
            {
                Id = myUser.Id,
                AccountType = "Checking",
                Name = "Chase Sucks",
                StartingBalance = 0m
            };

            var repo = new AccountRepository();
            repo.Add(account);

            var accountFromDb = repo.Get(account.Id);
            Assert.AreEqual(account.Name, accountFromDb.Name);
        }

        [TestMethod]
        public void RemoveAccount_DeletesAccountFromDb()
        {

            //var account = new Account(myUser.Id, "Checking", "Chase Sucks2", 0m);
            var account = new Account
            {
                Id = myUser.Id,
                AccountType = "Checking",
                Name = "Chase Sucks2",
                StartingBalance = 0m
            };

            var repo = new AccountRepository();
            repo.Add(account);

            var accountFromDb = repo.Get(account.Id);
            repo.Remove(accountFromDb);

            accountFromDb = repo.Get(account.Id);

            Assert.IsNull(accountFromDb);
        }

        [TestMethod]
        public void UpdateAccount_UpdatesAccountInDb()
        {

            //var account = new Account(myUser.Id, "Checking", "Chase Sucks2", 0m);
            var account = new Account
            {
                Id = myUser.Id,
                AccountType = "Checking",
                Name = "Chase Sucks2",
                StartingBalance = 0m
            };

            var repo = new AccountRepository();
            repo.Add(account);

            var accountFromDb = repo.Get(account.Id);
            accountFromDb.Name = "Waka Waka";

            repo.Update(accountFromDb);

            accountFromDb = repo.Get(account.Id);

            Assert.AreEqual("Waka Waka", accountFromDb.Name);
        }
    }
}
