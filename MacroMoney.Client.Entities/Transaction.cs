using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using PropertyChanged;

namespace MacroMoney.Client.Entities
{
    [ImplementPropertyChanged]
    public class Transaction
    {
        public Transaction()
        {
            TransactionDetails = new List<TransactionDetail>();
        }

        public Guid Id { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Payee { get; set; }

        public List<TransactionDetail> TransactionDetails { get; set; }

        public Guid AccountId { get; set; }

        public decimal Amount
        {
            get { return TransactionDetails.Sum(tran => tran.Amount); }
        }
    }
}
