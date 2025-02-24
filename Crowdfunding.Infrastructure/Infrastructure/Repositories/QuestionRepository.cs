using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class QuestionRepository
    {
        DatabaseContext dataBase;
        public QuestionRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }
        public bool CreateQuestion(QuestionModels questionData)//新增
        {
            if (questionData == null)
                return false;
            Question question = new Question();
            question.Id = Guid.NewGuid();
            question.Title = questionData.Title;
            question.Contents = questionData.Contents;
            question.CreateTime = DateTime.Now;
            question.ProjectId = questionData.ProjectId;

            this.dataBase.Questions.Add(question);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateQuestion(QuestionModels questionData) //修改
        {
            Question question = this.dataBase.Questions.FirstOrDefault(x => x.Id == questionData.Id) ?? throw new Exception("查無此資料");
            question.Title = questionData.Title;
            question.Contents = questionData.Contents;
            this.dataBase.SaveChanges();
            return true;
        }
        public bool DeleteQuestion(Guid id) //刪除
        {
            Question question = this.dataBase.Questions.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
            this.dataBase.Questions.Remove(question);
            this.dataBase.SaveChanges();
            return true;
        }
        public QuestionModels GetQuestion(Guid id)//查詢 應該成根據projectid查詢多個
        {
            if (!this.dataBase.Questions.Any(x => x.Id == id))
                throw new Exception("查無此資料");

            QuestionModels news = this.dataBase.Questions.Where(x => x.Id == id)
            .Select(x => new QuestionModels()
            {
                Id = x.Id,
                Title = x.Title,
                Contents = x.Contents,
                CreateTime = x.CreateTime,
                ProjectId = x.ProjectId,
            }).First();

            return news;
        }
        public List<QuestionModels> GetQuestionByProjectID(Guid projectid)//根據projectid查詢多個
        {
            if (!this.dataBase.Questions.Any(x => x.ProjectId == projectid))
                throw new Exception("查無此資料");

            List<QuestionModels> list = this.dataBase.Questions.Where(x => x.ProjectId == projectid)
            .Select(x => new QuestionModels()
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
