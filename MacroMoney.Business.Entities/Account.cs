using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Core.Common.Contracts;

namespace MacroMoney.Business.Entities
{
    [DataContract(IsReference = true)]
    public class Account : IIdentifier
    {
        
        public Account()
        {
            Transactions = new List<Transaction>();
        }
        
        public decimal AmountBalance
        {
            get
            {
                return StartingBalance + Transactions.Sum(tran => tran.Amount);
            }
        }
        
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string AccountType { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public decimal StartingBalance { get; set; }

        [DataMember]
        public Guid UserId { get; set; }

        [DataMember]
        public List<Transaction> Transactions { get; set; }

        public Guid Identity => Id;

    }
}
