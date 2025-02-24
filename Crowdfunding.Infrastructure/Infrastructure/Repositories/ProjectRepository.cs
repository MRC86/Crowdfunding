using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class ProjectRepository
    {

        DatabaseContext dataBase;
        public ProjectRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }
        public bool CreateProject(ProjectModels projectData)//�s�W
        {
            if (projectData == null)
                return false;
            Project project = new Project();
            project.Id = Guid.NewGuid();
            project.Name = projectData.Name;
            project.ProjectTypeId = projectData.ProjectTypeId;
            project.Cover = projectData.Cover;
            project.TargetMoney = projectData.TargetMoney;
            project.ExpireTime = projectData.ExpireTime;
            project.Description = projectData.Description;
            project.Detail = projectData.Detail;
            project.UserId = projectData.UserId;
            project.CreateTime = DateTime.Now;
            project.Status = "init";
            project.UpdateTime = DateTime.Now;
            project.Status = projectData.Status;

            this.dataBase.Projects.Add(project);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateProject(ProjectModels projectData) //�ק�
        {
            Project project = this.dataBase.Projects.FirstOrDefault(x => x.Id == projectData.Id) ?? throw new Exception("�d�L�����");
            project.Name=projectData.Name;
            project.ProjectTypeId=projectData.ProjectTypeId;
            project.Cover = projectData.Cover;
            project.TargetMoney=projectData.TargetMoney;//
            project.ExpireTime=projectData.ExpireTime;//
            project.Description=projectData.Description;
            project.Detail = projectData.Detail;
            project.Status=projectData.Status;
            project.UpdateTime = DateTime.Now;
            this.dataBase.SaveChanges();
            return true;
        }
        //public bool DeleteProject(Guid id) //�R��
        //{
        //    Project project = this.dataBase.Projects.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
        //    this.dataBase.Projects.Remove(project);
        //    this.dataBase.SaveChanges();
        //    return true;
        //}
        public List<ProjectModels> GetProjects(Guid id)//�ھ�projectid�d�ߦh��
        {
            if (!this.dataBase.Projects.Any(x => x.Id == id))
                throw new Exception("�d�L�����");

            List<ProjectModels> project = this.dataBase.Projects.Where(x => x.Id == id)
            .Select(x => new ProjectModels()
            {
                Id = x.Id,
                Name = x.Name,
                ProjectTypeId = x.ProjectTypeId,
                Cover = x.Cover,
                TargetMoney=x.TargetMoney,
                ExpireTime=x.ExpireTime,
                Description=x.Description,
                Detail = x.Detail,
                UserId=x.UserId,
                CreateTime=x.CreateTime,
                Status=x.Status,
                UpdateTime=x.UpdateTime,
            }).ToList();

            return project;
        }
        public bool DeleteProject(Guid id) //�R��
        {
            Project project = this.dataBase.Projects.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            project.IsDelete = false;
            this.dataBase.SaveChanges();
            return true;
        }
    }
}
