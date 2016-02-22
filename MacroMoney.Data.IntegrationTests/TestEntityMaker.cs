using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MacroMoney.Business.Entities;

namespace MacroMoney.Data.IntegrationTests
{
    public static class TestEntityMaker
    {
        const String myGuidId = "8fd0cf30-c56f-496d-896b-151714cd9e2c";

        public static User GetUser()
        {
            var myUser = new User
            {
                Id = new Guid(myGuidId),
                UserName = "Me"
            };
            return myUser;
        }

        public static Account GetAccount()
        {
            //return new Account(new Guid(myGuidId), "Checking", "Chase Sucks", 0m);
            return new Account
            {
                Id = new Guid(myGuidId),
                AccountType = "Checking",
                Name = "Chase Sucks",
                StartingBalance = 0m
            };
        }
    }
}
