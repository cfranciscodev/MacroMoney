using System;
using System.Collections.Generic;
using Core.Common.ServiceModel;
using MacroMoney.Client.Contracts;
using MacroMoney.Client.Entities;

namespace MacroMoney.Client.Proxies
{
    public class AccountClient : UserClientBase<IAccountService>, IAccountService
    {

        public List<Account> GetUserAccounts(Guid userId)
        {
            return Channel.GetUserAccounts(userId);
        }

        public Account GetAccount(Guid Id)
        {
            return Channel.GetAccount(Id);
        }

        public void DeleteAccount(Guid Id)
        {
            Channel.DeleteAccount(Id);
        }

        public Account AddOrUpdateAccount(Account account)
        {
            return Channel.AddOrUpdateAccount(account);
        }


    }
}
