using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMoney.Client.Entities;

namespace MacroMoney.QuickUI
{
    public delegate void AddOrUpdateDelegate(Account account);

    public delegate void RemoveDelegate(Guid accountId);

    public interface IMainView
    {
        MainViewModel ViewModel { get; set; }

        event AddOrUpdateDelegate AddOrUpdateAccount;

        event RemoveDelegate RemoveAccount;

        void BindForm();
    }

}
