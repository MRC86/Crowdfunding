using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class UserRepository
    {
        DatabaseContext dataBase;
        public UserRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }

        public bool CreateUser(UserModels users)//�s�W
        {
            if (users == null)
                return false;

            User user = new User();
            user.Id = Guid.NewGuid();
            user.Name = users.Name;
            user.Email = users.Email;
            user.CreateTime = DateTime.Now;

            Account account = new Account();
            account.Id = Guid.NewGuid();
            account.UserId = user.Id;
            account.Account1 = users.Account1;
            account.Password = users.Password;
            this.dataBase.Users.Add(user);
            this.dataBase.Accounts.Add(account);
            this.dataBase.SaveChanges();
            return true;
        }

        public bool UpdateUser(UserModels user) //�ק�
        {
            User user1 = this.dataBase.Users.FirstOrDefault(x => x.Id == user.Id) ?? throw new Exception("�d�L�����");
            user1.Name = user.Name;
            user1.Email = user.Email;
            this.dataBase.SaveChanges();
            return true;
        }

        public bool DeleteUser(Guid id) //�R��
        {
            //User user = this.dataBase.Users.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            //this.dataBase.Users.Remove(user);
            //this.dataBase.SaveChanges();
            return true;
        }

        public UserModels GetUser(Guid id)//�d��
        {
            if(!this.dataBase.Users.Any(x => x.Id == id))
                throw new Exception("�d�L�����");

            UserModels user = this.dataBase.Users.Where(x=>x.Id == id)
            .Select(x => new UserModels()
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
            }).First();

            return user;
        }
    }
}
