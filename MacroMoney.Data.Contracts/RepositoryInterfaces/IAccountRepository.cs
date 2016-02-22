using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using MacroMoney.Business.Entities;

namespace MacroMoney.Data.Contracts.RepositoryInterfaces
{
    public interface IAccountRepository : IDataRepository<Account>
    {
        List<Account> GetAccountsByUserId(Guid userId);
    }
}
