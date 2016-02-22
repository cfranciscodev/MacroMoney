using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using MacroMoney.Client.Entities;

namespace MacroMoney.Client.Contracts
{
    [ServiceContract]
    public interface IAccountService : IServiceContract
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
