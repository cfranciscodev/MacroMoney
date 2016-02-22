using System;
using System.Windows.Forms;
using Core.Common.Utils;
using MacroMoney.Client.Entities;

namespace MacroMoney.QuickUI
{
    public partial class AccountInfo : Form
    {

        public Account _account = new Account();

        public AccountInfo(Account account)
        {
            SimpleMapper.PropertyMap(account, _account);
            InitializeComponent();
            //_account = account;
            BindForm();
        }

        private void BindForm()
        {
            txtAccountType.DataBindings.Add("Text", _account, nameof(_account.AccountType));
            txtAccountName.DataBindings.Add("Text", _account, nameof(_account.Name));
            txtStartingBalance.DataBindings.Add("Text", _account, nameof(_account.StartingBalance), true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            DialogResult = DialogResult.Cancel;
        }
    }
}
