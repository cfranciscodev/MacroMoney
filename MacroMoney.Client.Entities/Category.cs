using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace MacroMoney.Client.Entities
{
    [ImplementPropertyChanged]
    public class Category
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

    }
}
