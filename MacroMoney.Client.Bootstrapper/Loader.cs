using Autofac;
using Core.Common.Core;
using MacroMoney.Client.Contracts;
using MacroMoney.Client.Proxies;

namespace MacroMoney.Client.Bootstrapper
{
    public class Loader
    {
        public void Load()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<AccountClient>().As<IAccountService>();
            builder.RegisterType<TransactionClient>().As<ITransactionService>();
            builder.RegisterType<UserClient>().As<IUserService>();
            builder.RegisterType<CategoryClient>().As<ICategoryService>();

            IoC.Container = builder.Build();
        }
    }
}
