﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MacroMoney.Business.Entities;

namespace MacroMoney.Business.Contracts
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        User GetOnlyUserForNow();
    }
}
