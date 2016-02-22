using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.ServiceModel;
using MacroMoney.Client.Contracts;

namespace MacroMoney.Client.Proxies
{
    public class TransactionClient : UserClientBase<ITransactionService>, ITransactionService
    {
        public DateTime SomethingToDo()
        {
            return Channel.SomethingToDo();
        }
    }
}
