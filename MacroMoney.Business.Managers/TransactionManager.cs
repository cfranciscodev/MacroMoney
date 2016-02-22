using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MacroMoney.Business.Contracts;
using MacroMoney.Business.Entities;

namespace MacroMoney.Business.Managers
{
    public class TransactionManager : ManagerBase, ITransactionService
    {
        public List<Transaction> GetTransactions()
        {
            var transactions = new List<Transaction>();
            return transactions;
        }

        public DateTime SomethingToDo()
        {
            return DateTime.Now;
        }
    }
}