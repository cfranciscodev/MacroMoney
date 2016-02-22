using System;
using System.Collections.Generic;
using System.ServiceModel;
using Core.Common.Contracts;
using MacroMoney.Business.Contracts;
using MacroMoney.Business.Entities;
using MacroMoney.Data;
using MacroMoney.Data.Contracts.RepositoryInterfaces;

namespace MacroMoney.Business.Managers
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall,
                 ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class UserManager : ManagerBase, IUserService
    {
        private const string UserId = "8BD3248E-486C-42D8-8DD1-984BDBD523EB";

        private readonly IDataRepositoryFactory _repoFactory;

        public UserManager(IDataRepositoryFactory dataRepositoryFactory)
        {
            _repoFactory = dataRepositoryFactory;
        }

        private static Guid GetUserId()
        {
            return new Guid(UserId);
        }

        public List<Account> GetAccountsForUsers(Guid userId)
        {
            return new List<Account>();
        }


        public User GetOnlyUserForNow()
        {
            var userRepo = _repoFactory.GetDataRepository<IUserRepository>();
            return userRepo.Get(GetUserId());
        }
    }
}