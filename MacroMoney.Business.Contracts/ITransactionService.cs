using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MacroMoney.Business.Contracts
{
    [ServiceContract]
    public interface ITransactionService
    {
        [OperationContract]
        DateTime SomethingToDo();
    }
}
