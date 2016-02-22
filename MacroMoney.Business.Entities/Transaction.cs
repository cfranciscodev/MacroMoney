using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Core.Common.Contracts;

namespace MacroMoney.Business.Entities
{
    [DataContract(IsReference = true)]
    public class Transaction : IIdentifier
    {
        public Transaction()
        {
            TransactionDetails = new List<TransactionDetail>();
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public DateTime TransactionDate { get; set; }

        [DataMember]
        public string Payee { get; set; }

        [DataMember]
        public List<TransactionDetail> TransactionDetails { get; set; }

        [DataMember]
        public Guid AccountId { get; set; }

        public decimal Amount
        {
            get
            {
                return TransactionDetails.Sum(tran => tran.Amount);
            }
        }

        public Guid Identity => Id;
    }
}
