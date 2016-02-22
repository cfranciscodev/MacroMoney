using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core.Common.Contracts;
using Core.Common.Core;

namespace MacroMoney.Client.Proxies
{
    public class ServiceFactory : IServiceFactory
    {
        public T CreateClient<T>() where T : IServiceContract
        {
            return IoC.Container.Resolve<T>();
        }
    }
}
