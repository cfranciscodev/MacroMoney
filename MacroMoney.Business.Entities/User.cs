using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Core.Common.Contracts;

namespace MacroMoney.Business.Entities
{
    [DataContract]
    public partial class User : IIdentifier
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public virtual ICollection<Account> Accounts { get; set; }

        public Guid Identity => Id;
    }
}
