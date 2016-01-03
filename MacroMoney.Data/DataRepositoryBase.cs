using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;
using Core.Common.Data;

namespace MacroMoney.Data
{
    public abstract class DataRepositoryBase<T> : DataRepositoryBase<T, MacroMoneyContext>
        where T : class, IIdentifier, new()
    {
    }
}
