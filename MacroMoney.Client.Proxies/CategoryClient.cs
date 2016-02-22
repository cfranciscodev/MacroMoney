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
    public class CategoryClient : UserClientBase<ICategoryService>, ICategoryService
    {
        public List<Category> GetCategories()
        {
            return Channel.GetCategories();
        }
    }
}
