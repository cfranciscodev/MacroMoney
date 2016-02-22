using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core.Common.Contracts;
using Core.Common.Core;
using MacroMoney.Business.Contracts;
using MacroMoney.Business.Managers;
using MacroMoney.Data;
using MacroMoney.Data.Contracts.RepositoryInterfaces;
using MacroMoney.Data.DataRepository;

namespace MacroMoney.Boostrapper
{
    public class Loader
    {
        public void Load()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DataRepositoryFactory>().As<IDataRepositoryFactory>();
            builder.RegisterType<AccountRepository>().As<IAccountRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<TransactionDetailRepository>().As<ITransactionDetailRepository>();
            builder.RegisterType<TransactionRepository>().As<ITransactionRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            builder.RegisterType<AccountManager>().As<IAccountService>();
            builder.RegisterType<TransactionManager>().As<ITransactionService>();
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();

            IoC.Container = builder.Build();
        }
    }
}
