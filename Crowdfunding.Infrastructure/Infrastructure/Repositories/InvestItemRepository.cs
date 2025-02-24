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
        public bool CreateInvestItem(InvestItemModels InvestItemData)//新增
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
        public bool UpdateInvestItem(InvestItemModels InvestItemData) //修改
        {
            InvestItem investItem = this.dataBase.InvestItems.FirstOrDefault(x => x.Id == InvestItemData.Id) ?? throw new Exception("查無此資料");
            investItem.Donate = InvestItemData.Donate;
            this.dataBase.SaveChanges();
            return true;
        }
        //public bool DeleteInvestItem(Guid id) //刪除 應該需要有其他狀態
        //{
        //    InvestItem investItem = this.dataBase.InvestItems.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
        //    this.dataBase.InvestItems.Remove(investItem);
        //    this.dataBase.SaveChanges();
        //    return true;
        //}
        public InvestItemModels GetInvestItem(Guid id)//查詢 還缺一個查詢多筆
        {
            if (!this.dataBase.InvestItems.Any(x => x.Id == id))
                throw new Exception("查無此資料");

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


        public List<InvestItemModels> GetInvestItemUserID(Guid userID)//查詢
        {
            if (!this.dataBase.InvestItems.Any(x => x.UserId == userID))
                throw new Exception("查無此資料");

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


        public bool RemoveInvestItem(Guid id) //刪除 應該需要有其他狀態
        {
            InvestItem investItem = this.dataBase.InvestItems.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
            investItem.IsDelete = false;
            this.dataBase.SaveChanges();
            return true;
        }

        public bool ResumeInvestItem(Guid id) //刪除 應該需要有其他狀態
        {
            InvestItem investItem = this.dataBase.InvestItems.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
            investItem.IsDelete = true;
            this.dataBase.SaveChanges();
            return true;
        }
    }
}
