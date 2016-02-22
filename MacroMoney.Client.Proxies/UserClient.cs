using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.ServiceModel;
using MacroMoney.Client.Contracts;
using MacroMoney.Client.Entities;

namespace MacroMoney.Client.Proxies
{
    public class UserClient : UserClientBase<IUserService>, IUserService
    {
        public User GetOnlyUserForNow()
        {
            return Channel.GetOnlyUserForNow();
        }
    }
}
