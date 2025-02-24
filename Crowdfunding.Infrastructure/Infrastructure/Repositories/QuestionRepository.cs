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
        public bool CreateQuestion(QuestionModels questionData)//�s�W
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
        public bool UpdateQuestion(QuestionModels questionData) //�ק�
        {
            Question question = this.dataBase.Questions.FirstOrDefault(x => x.Id == questionData.Id) ?? throw new Exception("�d�L�����");
            question.Title = questionData.Title;
            question.Contents = questionData.Contents;
            this.dataBase.SaveChanges();
            return true;
        }
        public bool DeleteQuestion(Guid id) //�R��
        {
            Question question = this.dataBase.Questions.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            this.dataBase.Questions.Remove(question);
            this.dataBase.SaveChanges();
            return true;
        }
        public QuestionModels GetQuestion(Guid id)//�d�� ���Ӧ��ھ�projectid�d�ߦh��
        {
            if (!this.dataBase.Questions.Any(x => x.Id == id))
                throw new Exception("�d�L�����");

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
        public List<QuestionModels> GetQuestionByProjectID(Guid projectid)//�ھ�projectid�d�ߦh��
        {
            if (!this.dataBase.Questions.Any(x => x.ProjectId == projectid))
                throw new Exception("�d�L�����");

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
