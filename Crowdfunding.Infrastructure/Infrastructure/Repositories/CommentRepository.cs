using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class CommentRepository
    {
        DatabaseContext dataBase;
        public CommentRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }
        public bool CreateComment(CommentModels CommentData)//�s�W6
        {
            if (CommentData == null)
                return false;
            Comment comment = new Comment();
            comment.Id = Guid.NewGuid();
            comment.Message = CommentData.Message;
            comment.UserId = CommentData.UserId;
            comment.ProjectId = CommentData.ProjectId;
            comment.CreateTime = DateTime.Now;

            this.dataBase.Comments.Add(comment);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateComment(CommentModels CommentData) //�ק�6
        {
            Comment comment = this.dataBase.Comments.FirstOrDefault(x => x.Id == CommentData.Id) ?? throw new Exception("�d�L�����");
            comment.Message = CommentData.Message;
            this.dataBase.SaveChanges();
            return true;
        }
        public bool DeleteComment(Guid id) //�R��6
        {
            Comment comment = this.dataBase.Comments.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            this.dataBase.Comments.Remove(comment);
            this.dataBase.SaveChanges();
            return true;
        }
        //public CommentModels GetComment(Guid id)// ���ݭn�������o��@comment ���Ӯھ�projectid ���o ��@�Ҹ궵�ؤU���Ҧ��d��
        //{
        //    if (!this.dataBase.Comments.Any(x => x.Id == id))
        //        throw new Exception("�d�L�����");

        //    CommentModels investItem = this.dataBase.Comments.Where(x => x.Id == id)
        //    .Select(x => new CommentModels()
        //    {
        //        Id = x.Id,
        //        Message = x.Message,
        //        UserId = x.UserId,
        //        ProjectId = x.ProjectId,
        //        CreateTime = x.CreateTime,
        //    }).First();

        //    return investItem;
        //}
        public List<CommentModels> GetsprojectComment(Guid projectid)// �ھ�projectid ���o ��@�Ҹ궵�ؤU���Ҧ��d��6
        {
            if (!this.dataBase.Projects.Any(x => x.Id == projectid))
                throw new Exception("�d�L�����");

            List<CommentModels> list = this.dataBase.Comments.Where(x => x.ProjectId == projectid)
            .Select(x => new CommentModels()
            {
                Id = x.Id,
                Message = x.Message,
                UserId = x.UserId,
                ProjectId = x.ProjectId,
                CreateTime = x.CreateTime,
            }).ToList();

            return list;
        }
        //public List<CommentModels> GetsCommentList()//�d��
        //{
        //    List<CommentModels> list = this.dataBase.Comments.Select(x => new CommentModels()
        //    {
        //        Id = x.Id,
        //        Message = x.Message,
        //        UserId = x.UserId,
        //        ProjectId = x.ProjectId,
        //        CreateTime = x.CreateTime,
        //    }).ToList();

        //    return list;
        //}
    }
}
