using System;
using System.Runtime.Serialization;
using Core.Common.Contracts;

namespace MacroMoney.Business.Entities
{
    [DataContract(IsReference = true)]
    public class TransactionDetail : IIdentifier
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public decimal Amount { get; set; }

        [DataMember]
        public Category Category { get; set; }

        [DataMember]
        public Transaction Transaction { get; set; }
        
        [DataMember]
        public Guid TransactionId { get; set; }

        [DataMember]
        public Guid CategoryId { get; set; }

        public Guid Identity => Id;

    }
}
