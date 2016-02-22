using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Wcf;
using Core.Common.Core;
using MacroMoney.Business.Contracts;
using MacroMoney.Business.Managers;
using SM = System.ServiceModel;

namespace MacroMoney.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new MacroMoney.Boostrapper.Loader();
            loader.Load();

            Console.WriteLine("Starting up services...");
            Console.WriteLine("");

            SM.ServiceHost hostAccountManager = new SM.ServiceHost(typeof(AccountManager));
            hostAccountManager.AddDependencyInjectionBehavior<IAccountService>(IoC.Container);

            SM.ServiceHost hostTransactionmanager = new SM.ServiceHost(typeof(TransactionManager));
            hostTransactionmanager.AddDependencyInjectionBehavior<ITransactionService>(IoC.Container);

            SM.ServiceHost hostUserManager = new SM.ServiceHost(typeof(UserManager));
            hostUserManager.AddDependencyInjectionBehavior<IUserService>(IoC.Container);

            SM.ServiceHost hostCategoryManager = new SM.ServiceHost(typeof(CategoryManager));
            hostCategoryManager.AddDependencyInjectionBehavior<ICategoryService>(IoC.Container);

            StartService(hostAccountManager, "AccountManager");
            StartService(hostTransactionmanager, "TransactionManager");
            StartService(hostUserManager, "UserManager");
            StartService(hostCategoryManager, "CategoryManager");

            //System.Timers.Timer timer = new System.Timers.Timer(10000);
            //timer.Elapsed += OnTimerElapsed;
            //timer.Start();

            //Console.WriteLine("Reservation monitor started.");

            Console.WriteLine("");
            Console.WriteLine("Press [Enter] to exit.");
            Console.ReadLine();
            Console.WriteLine("");

            //timer.Stop();

            //Console.WriteLine("Reservaton mointor stopped.");

            StopService(hostAccountManager, "AccountManager");
            StopService(hostTransactionmanager, "TransactionManager");
            StopService(hostUserManager, "UserManager");
        }


        //static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        //{
        //    RentalManager rentalManager = new RentalManager();

        //    Reservation[] reservations = rentalManager.GetDeadReservations();
        //    if (reservations != null)
        //    {
        //        foreach (Reservation reservation in reservations)
        //        {
        //            using (TransactionScope scope = new TransactionScope())
        //            {
        //                rentalManager.CancelReservation(reservation.ReservationId);
        //                scope.Complete();
        //            }
        //        }
        //    }
        //}

        static void StartService(SM.ServiceHost host, string serviceDescription)
        {

            host.Open();
            Console.WriteLine("Service '{0}' started.", serviceDescription);

            foreach (var endpoint in host.Description.Endpoints)
            {
                Console.WriteLine(string.Format("Listening on endpoint:"));
                Console.WriteLine(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                Console.WriteLine(string.Format("Binding: {0}", endpoint.Binding.Name));
                Console.WriteLine(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
            }

            Console.WriteLine();
        }

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            Console.WriteLine("Service '{0}' stopped.", serviceDescription);
        }
    }
}
