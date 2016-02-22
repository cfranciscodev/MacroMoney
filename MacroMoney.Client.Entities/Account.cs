using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Core;
using PropertyChanged;

namespace MacroMoney.Client.Entities
{
    [ImplementPropertyChanged]
    public class Account : ObjectBase
    {
        public Account()
        {
            Transactions = new List<Transaction>();
        }

        [DoNotNotify]
        public decimal AccountBalance
        {
            get
            {
                return StartingBalance + Transactions.Sum(tran => tran.Amount);
            }
        }

        //[DoNotNotify]
        public string DisplayText
        {
            get
            {
                return $"{this.Name} - {this.AccountType} - Balance : {this.AccountBalance.ToString("C")}";
            }
        }

        public Guid Id { get; set; }

        public string AccountType { get; set; }

        public string Name { get; set; }

        public decimal StartingBalance { get; set; }

        public Guid UserId { get; set; }

        public List<Transaction> Transactions { get; set; }

    }
}
