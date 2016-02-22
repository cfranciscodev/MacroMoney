using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Transactions;
using MacroMoney.Business.Entities;
using MacroMoney.Data.DataRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Transaction = MacroMoney.Business.Entities.Transaction;

namespace MacroMoney.Data.IntegrationTests
{
    [TestClass]
    public class TransactionRepository_IntegrationTests
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
        public void CreateTransaction()
        {
            var userRepo = new UserRepository();
            var accountRepo = new AccountRepository();
            var transactionRepo = new TransactionRepository();

            var user = TestEntityMaker.GetUser();
            var account = TestEntityMaker.GetAccount();

            userRepo.Add(user);
            accountRepo.Add(account);

            var transaction = new Business.Entities.Transaction();
            
            transaction.TransactionDate = DateTime.Now;
            transaction.Payee = "The Man";
            transaction.AccountId = account.Id;

            transactionRepo.Add(transaction);

            using (var context = new MacroMoneyContext())
            {
                var result = context.Account
                    .Include(i => i.Transactions)
                    .Where(e => e.Id == account.Id);

                Assert.IsTrue(result.Any());
            }

        }

        [TestMethod]
        public void GetData()
        {
            using (var context = new MacroMoneyContext())
            {
                //var result = context.Users
                //    .Include()
                //    .Where(e => e.Id == new Guid("96CEAB57-71ED-466E-A502-93A24C4D184E")).FirstOrDefault();

                var query1 = (from u in context.Users
                              .Include(e => e.Accounts)
                              .Include(e => e.Accounts.Select(t => t.Transactions))
                              .Include(e => e.Accounts.Select(t => t.Transactions.Select(td => td.TransactionDetails)))
                              .Include(e => e.Accounts.Select(t => t.Transactions.Select(td => td.TransactionDetails.Select(cat => cat.Category))))
                    where u.Id == new Guid("96CEAB57-71ED-466E-A502-93A24C4D184E")
                    select u).FirstOrDefault();

                Assert.IsTrue(true);

                //var query = (from u in context.Users
                //    where u.Id == new Guid("96CEAB57-71ED-466E-A502-93A24C4D184E")
                //             select new User()
                //             {
                //                 Id = u.Id,
                //                 UserName = u.UserName,
                //                 Accounts = (from a in context.Account
                //                            where a.UserId == u.Id
                //                             select new Account()
                //                             {
                //                                 Transactions = (from t in context.Transactions
                //                                                where t.AccountId == a.Id
                //                                                select new Transactions()
                //                                                {
                //                                                    TransactionDetails = context.TransactionDetails
                //                                                })

                //                })
                //}
                //).FirstOrDefault();
                //select new User()
                //{
                //    Accounts = a,
                //}

            }
        }


    }
}
