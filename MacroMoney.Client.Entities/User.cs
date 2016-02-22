using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace MacroMoney.Client.Entities
{
    [ImplementPropertyChanged]
    public class User
    {
        public User()
        {
            Accounts = new HashSet<Account>();
        }

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
