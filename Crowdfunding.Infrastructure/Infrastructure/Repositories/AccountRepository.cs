using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class AccountRepository
    {
        DatabaseContext dataBase;
        public AccountRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }
        public bool CreateAccount()
        {
            return true;
        }
       
        public UserModels Login(string account, string password)
        {
            var Account = this.dataBase.Accounts.SingleOrDefault(x => x.Password == password);
            if (Account == null)
                return null;

            User user = this.dataBase.Users.First(x => x.Id == Account.UserId);

            UserModels UserModel = new UserModels(user.Id,user.Name,user.Email);
            return UserModel;
        }
    }
}
