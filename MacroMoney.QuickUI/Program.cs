using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Core.Common.Contracts;
using Core.Common.Core;
using MacroMoney.Client.Contracts;
using MacroMoney.Client.Entities;
using MacroMoney.Client.Proxies;

namespace MacroMoney.QuickUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
#if DEBUG
            Thread.Sleep(10000);
#endif
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var loader = new Client.Bootstrapper.Loader();
            loader.Load();

            var mainForm = new Main();
            var mainController = new MainController(mainForm);

            Application.Run(mainForm);
        }

        public class Global
        {
            private static Global _global;

            private Global()
            {
                var serviceFactory = new ServiceFactory();
                CurrentUser = serviceFactory.CreateClient<IUserService>().GetOnlyUserForNow();
            }

            public static Global global => _global ?? (_global = new Global());

            public User CurrentUser { get; }
        }
    }
}
