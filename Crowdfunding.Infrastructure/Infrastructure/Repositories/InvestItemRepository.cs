using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class InvestItemRepository
    {
        DatabaseContext dataBase;
        public InvestItemRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }
        public bool CreateInvestItem(InvestItemModels InvestItemData)//�s�W
        {
            if (InvestItemData == null)
                return false;
            InvestItem investItem = new InvestItem();
            investItem.Id = Guid.NewGuid();
            investItem.UserId = InvestItemData.UserId;
            investItem.ProjectId = InvestItemData.ProjectId;
            investItem.Donate = InvestItemData.Donate;
            investItem.CreateTime = DateTime.Now;
            investItem.IsDelete = InvestItemData.IsDelete;

            this.dataBase.InvestItems.Add(investItem);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateInvestItem(InvestItemModels InvestItemData) //�ק�
        {
            InvestItem investItem = this.dataBase.InvestItems.FirstOrDefault(x => x.Id == InvestItemData.Id) ?? throw new Exception("�d�L�����");
            investItem.Donate = InvestItemData.Donate;
            this.dataBase.SaveChanges();
            return true;
        }
        //public bool DeleteInvestItem(Guid id) //�R�� ���ӻݭn����L���A
        //{
        //    InvestItem investItem = this.dataBase.InvestItems.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
        //    this.dataBase.InvestItems.Remove(investItem);
        //    this.dataBase.SaveChanges();
        //    return true;
        //}
        public InvestItemModels GetInvestItem(Guid id)//�d�� �ٯʤ@�Ӭd�ߦh��
        {
            if (!this.dataBase.InvestItems.Any(x => x.Id == id))
                throw new Exception("�d�L�����");

            InvestItemModels investItem = this.dataBase.InvestItems.Where(x => x.Id == id)
            .Select(x => new InvestItemModels()
            {
                Id = x.Id,
                UserId = x.UserId,
                ProjectId = x.ProjectId,
                Donate = x.Donate,
                CreateTime = x.CreateTime,
            }).First();

            return investItem;
        }


        public List<InvestItemModels> GetInvestItemUserID(Guid userID)//�d��
        {
            if (!this.dataBase.InvestItems.Any(x => x.UserId == userID))
                throw new Exception("�d�L�����");

            List<InvestItemModels> favorite = this.dataBase.InvestItems.Where(x => x.UserId == userID)
            .Select(x => new InvestItemModels()
            {
                Id = x.Id,
                UserId = x.UserId,
                ProjectId = x.ProjectId,
                CreateTime = x.CreateTime,
            }).ToList();

            return favorite;
        }


        public bool RemoveInvestItem(Guid id) //�R�� ���ӻݭn����L���A
        {
            InvestItem investItem = this.dataBase.InvestItems.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            investItem.IsDelete = false;
            this.dataBase.SaveChanges();
            return true;
        }

        public bool ResumeInvestItem(Guid id) //�R�� ���ӻݭn����L���A
        {
            InvestItem investItem = this.dataBase.InvestItems.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            investItem.IsDelete = true;
            this.dataBase.SaveChanges();
            return true;
        }
    }
}
