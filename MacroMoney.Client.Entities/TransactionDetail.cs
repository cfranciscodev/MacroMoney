using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace MacroMoney.Client.Entities
{
    [ImplementPropertyChanged]
    public class TransactionDetail
    {
        public Guid Id { get; set; }

        public decimal Amount { get; set; }

        public Category Category { get; set; }

        public Transaction Transaction { get; set; }

        public Guid TransactionId { get; set; }

        public Guid CategoryId { get; set; }
    }
}
