using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class NewsRepository
    {
        DatabaseContext dataBase;
        public NewsRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }
        public bool CreateNews(NewsModels newsData)//新增
        {
            if (newsData == null)
                return false;
            News news = new News();
            news.Id = Guid.NewGuid();
            news.Contents = newsData.Contents;
            news.CreateTime = DateTime.Now;
            news.ProjectId = newsData.ProjectId;

            this.dataBase.News.Add(news);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateNews(NewsModels newsData) //修改
        {
            News news = this.dataBase.News.FirstOrDefault(x => x.Id == newsData.Id) ?? throw new Exception("查無此資料");
            news.Contents = newsData.Contents;
            this.dataBase.SaveChanges();
            return true;
        }
        public bool DeleteNews(Guid id) //刪除
        {
            News news = this.dataBase.News.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
            this.dataBase.News.Remove(news);
            this.dataBase.SaveChanges();
            return true;
        }
        public NewsModels GetNews(Guid id)//查詢 應該成根據projectid查詢多個
        {
            if (!this.dataBase.News.Any(x => x.Id == id))
                throw new Exception("查無此資料");

            NewsModels news = this.dataBase.News.Where(x => x.Id == id)
            .Select(x => new NewsModels()
            {
                Id = x.Id,
                Title = x.Title,
                Contents = x.Contents,
                CreateTime = x.CreateTime,
                ProjectId = x.ProjectId,
            }).First();

            return news;
        }
        public List<NewsModels> GetNewsByID(Guid projectid)//根據projectid查詢多個
        {
            if (!this.dataBase.News.Any(x => x.ProjectId == projectid))
                throw new Exception("查無此資料");

            List<NewsModels> list = this.dataBase.News.Where(x => x.ProjectId == projectid)
            .Select(x => new NewsModels()
            {
                Id = x.Id,
                Title = x.Title,
                Contents = x.Contents,
                CreateTime = x.CreateTime,
                ProjectId = x.ProjectId,
            }).ToList();

            return list;
        }
    }
}
