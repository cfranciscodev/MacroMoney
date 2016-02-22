using System;
using System.Runtime.Serialization;
using Core.Common.Contracts;

namespace MacroMoney.Business.Entities
{
    [DataContract(IsReference = true)]
    public class Category : IIdentifier
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Description { get; set; }

        public Guid Identity => Id;
    }
}