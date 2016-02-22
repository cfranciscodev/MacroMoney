using System;
using Core.Common.Contracts;
using MacroMoney.Client.Contracts;
using MacroMoney.Client.Entities;
using MacroMoney.Client.Proxies;

namespace MacroMoney.QuickUI
{
    public class MainController
    {

        private readonly IServiceFactory _serviceFactory = new ServiceFactory();
        private IMainView _view;
        
        public MainController(IMainView mainView)
        {
            _view = mainView;
            
            RefreshViewModelAccounts();

            _view.AddOrUpdateAccount += HandleAddOrUpdateAccount;
            _view.RemoveAccount += RemoveAccount;

        }

        private void RemoveAccount(Guid accountid)
        {
            var accountSvc = _serviceFactory.CreateClient<IAccountService>();
            accountSvc.DeleteAccount(accountid);
            RefreshViewModelAccounts();
            _view.BindForm();
        }

        private void RefreshViewModelAccounts()
        {
            var accounts = _serviceFactory.CreateClient<IAccountService>().GetUserAccounts(Program.Global.global.CurrentUser.Id);
            var categories = _serviceFactory.CreateClient<ICategoryService>().GetCategories();
            var mainViewModel = new MainViewModel
            {
                Accounts = accounts,
                Categories = categories,
            };
            _view.ViewModel = mainViewModel;
        }

        private void HandleAddOrUpdateAccount(Account account)
        {
            var accountSvc = _serviceFactory.CreateClient<IAccountService>();
            accountSvc.AddOrUpdateAccount(account);

            RefreshViewModelAccounts();
            _view.BindForm();
        }


    }
}
