using System;
using System.Collections.Generic;
using System.ServiceModel;
using MacroMoney.Business.Entities;

namespace MacroMoney.Business.Contracts
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        List<Account> GetUserAccounts(Guid userId);

        [OperationContract]
        Account GetAccount(Guid Id);

        [OperationContract]
        void DeleteAccount(Guid Id);

        [OperationContract]
        Account AddOrUpdateAccount(Account account);

    }
}
