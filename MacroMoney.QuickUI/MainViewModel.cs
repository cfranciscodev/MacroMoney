using System.Collections.Generic;
using MacroMoney.Client.Entities;

namespace MacroMoney.QuickUI
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Accounts = new List<Account>();
            Categories = new List<Category>();
        }

        public List<Account> Accounts;

        public List<Category> Categories { get; set; }

    }
}
