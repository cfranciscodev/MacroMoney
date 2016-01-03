using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Contracts;

namespace MacroMoney.Business.Entities
{
    public class Account : IIdentifier
    {
        private Guid _id;
        private string _accountType;
        private string _name;
        private decimal _startingBalance;
        private Guid _userID;
        
        public Account(Guid userId, string accountType, string name, decimal startingBalance)
        {
            _id = Guid.NewGuid();
            _accountType = accountType;
            _name = name;
            _startingBalance = startingBalance;
            _userID = userId;
        }

        public Account()
        {
            
        }

        public Guid Identity
        {
            get { return Id; }
        }

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string AccountType
        {
            get { return _accountType; }
            set { _accountType = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal StartingBalance
        {
            get { return _startingBalance; }
            set { _startingBalance = value; }
        }

        public Guid UserId
        {
            get { return _userID; }
            set { _userID = value; }
        }
    }
}
