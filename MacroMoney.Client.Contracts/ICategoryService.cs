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
    public interface ICategoryService : IServiceContract
    {
        [OperationContract]
        List<Category> GetCategories();
    }
}
