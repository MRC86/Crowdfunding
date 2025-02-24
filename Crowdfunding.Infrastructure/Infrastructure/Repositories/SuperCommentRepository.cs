using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class SuperCommentRepository
    {
        DatabaseContext dataBase;
        public SuperCommentRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }
        public bool CreateSuperComment(SuperCommentModels SuperCommentData)//�s�W
        {
            if (SuperCommentData == null)
                return false;
            SuperComment superComment = new SuperComment();
            superComment.Id = Guid.NewGuid();
            superComment.Message = SuperCommentData.Message;
            superComment.Donate = SuperCommentData.Donate;
            superComment.UserId = SuperCommentData.UserId;
            superComment.ProjectId = SuperCommentData.ProjectId;
            superComment.CreateTime = DateTime.Now;

            this.dataBase.SuperComments.Add(superComment);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateSuperComment(SuperCommentModels SuperCommentData) //�ק�
        {
            SuperComment superComment = this.dataBase.SuperComments.FirstOrDefault(x => x.Id == SuperCommentData.Id) ?? throw new Exception("�d�L�����");
            superComment.Message = SuperCommentData.Message;
            this.dataBase.SaveChanges();
            return true;
        }
        public bool DeleteSuperComment(Guid id) //�R��
        {
            SuperComment superComment = this.dataBase.SuperComments.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            this.dataBase.SuperComments.Remove(superComment);
            this.dataBase.SaveChanges();
            return true;
        }
        public SuperCommentModels GetSuperComment(Guid id)//�d�� ���Ӧ��ھ�projectid�d�ߦh��
        {
            if (!this.dataBase.SuperComments.Any(x => x.Id == id))
                throw new Exception("�d�L�����");

            SuperCommentModels investItem = this.dataBase.SuperComments.Where(x => x.Id == id)
            .Select(x => new SuperCommentModels()
            {
                Id = x.Id,
                Message = x.Message,
                Donate = x.Donate,
                UserId = x.UserId,
                ProjectId = x.ProjectId,
                CreateTime = x.CreateTime,
            }).First();

            return investItem;
        }
        public List<SuperCommentModels> GetSuperCommentByProjectID(Guid projectid)//�ھ�projectid�d�ߦh��
        {
            if (!this.dataBase.SuperComments.Any(x => x.ProjectId == projectid))
                throw new Exception("�d�L�����");

            List<SuperCommentModels> list = this.dataBase.SuperComments.Where(x => x.ProjectId == projectid)
            .Select(x => new SuperCommentModels()
            {
                Id = x.Id,
                Message = x.Message,
                Donate = x.Donate,
                UserId = x.UserId,
                ProjectId = x.ProjectId,
                CreateTime = x.CreateTime,
            }).ToList();

            return list;
        }
    }
}
