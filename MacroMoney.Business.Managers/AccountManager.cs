using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Core.Common.Contracts;
using MacroMoney.Business.Contracts;
using MacroMoney.Business.Entities;
using MacroMoney.Data.Contracts.RepositoryInterfaces;

namespace MacroMoney.Business.Managers
{
    public class AccountManager : ManagerBase, IAccountService
    {
        private readonly IDataRepositoryFactory _repoFactory;

        public AccountManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _repoFactory = dataRepositoryFactory;
        }

        public List<Account> GetUserAccounts(Guid userId)
        {
            return _repoFactory.GetDataRepository<IAccountRepository>().GetAccountsByUserId(userId);
        }

        public Account GetAccount(Guid Id)
        {
            return _repoFactory.GetDataRepository<IAccountRepository>().Get(Id);
        }

        public void DeleteAccount(Guid Id)
        {
            _repoFactory.GetDataRepository<IAccountRepository>().Remove(Id);
        }

        public Account AddOrUpdateAccount(Account account)
        {
            return _repoFactory.GetDataRepository<IAccountRepository>().AddOrUpdate(account);
        }
    }
}