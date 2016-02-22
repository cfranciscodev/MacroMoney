using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;

namespace MacroMoney.Client.Contracts
{
    [ServiceContract]
    public interface ITransactionService : IServiceContract
    {
        [OperationContract]
        DateTime SomethingToDo();
    }
}
