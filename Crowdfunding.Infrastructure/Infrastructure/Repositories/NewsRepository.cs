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
        public bool CreateNews(NewsModels newsData)//�s�W
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
        public bool UpdateNews(NewsModels newsData) //�ק�
        {
            News news = this.dataBase.News.FirstOrDefault(x => x.Id == newsData.Id) ?? throw new Exception("�d�L�����");
            news.Contents = newsData.Contents;
            this.dataBase.SaveChanges();
            return true;
        }
        public bool DeleteNews(Guid id) //�R��
        {
            News news = this.dataBase.News.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            this.dataBase.News.Remove(news);
            this.dataBase.SaveChanges();
            return true;
        }
        public NewsModels GetNews(Guid id)//�d�� ���Ӧ��ھ�projectid�d�ߦh��
        {
            if (!this.dataBase.News.Any(x => x.Id == id))
                throw new Exception("�d�L�����");

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
        public List<NewsModels> GetNewsByID(Guid projectid)//�ھ�projectid�d�ߦh��
        {
            if (!this.dataBase.News.Any(x => x.ProjectId == projectid))
                throw new Exception("�d�L�����");

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
