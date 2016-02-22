using System;
using System.Windows.Forms;
using MacroMoney.Client.Entities;

namespace MacroMoney.QuickUI
{
    public partial class Main : Form, IMainView
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            BindForm();

            grdTransactionDetail.AutoGenerateColumns = false;
            grdTransactions.AutoGenerateColumns = false;

        }

        public event RemoveDelegate RemoveAccount;
        public event AddOrUpdateDelegate AddOrUpdateAccount;

        public MainViewModel ViewModel { get; set; }

        public void BindForm()
        {
            grdTransactionDetail.AutoGenerateColumns = false;
            grdTransactions.AutoGenerateColumns = false;

            lstAccounts.DataSource = ViewModel.Accounts;
            lstAccounts.DisplayMember = nameof(Account.DisplayText);
            lstAccounts.ValueMember = nameof(Account.Id);

            Category.DataSource = ViewModel.Categories;
            Category.DisplayMember = nameof(Client.Entities.Category.Description);
            Category.ValueMember = nameof(Client.Entities.Category.Id);
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var account = new Account
            {
                UserId = Program.Global.global.CurrentUser.Id,
                
            };

            var accountFrm = new AccountInfo(account);
            var result = accountFrm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                AddOrUpdateAccount?.Invoke(accountFrm._account);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Account account = (Account) lstAccounts.SelectedItem;

            var accountFrm = new AccountInfo(account);
            var result = accountFrm.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                AddOrUpdateAccount?.Invoke(accountFrm._account);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Account account = (Account)lstAccounts.SelectedItem;
            RemoveAccount?.Invoke(account.Id);
        }

        private void lstAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdTransactions.AutoGenerateColumns = false;

            var account = (Account)lstAccounts.SelectedItem;
            var bindingSource = new BindingSource(account, "Transactions");
            grdTransactions.DataSource = bindingSource;
        }

        private void grdTransactions_SelectionChanged(object sender, EventArgs e)
        {
            RefreshTransactionDetail();
        }
        
        private void grdTransactions_DataSourceChanged(object sender, EventArgs e)
        {
            RefreshTransactionDetail();
        }

        private void RefreshTransactionDetail()
        {
            grdTransactionDetail.AutoGenerateColumns = false;
            if (grdTransactions.CurrentRow != null)
            {
                var transaction = (Transaction)grdTransactions.CurrentRow.DataBoundItem;
                var bindingSource = new BindingSource(transaction, "TransactionDetails");
                grdTransactionDetail.DataSource = bindingSource;
            }
            else
            {
                grdTransactionDetail.DataSource = null;
            }
        }
    }
}
