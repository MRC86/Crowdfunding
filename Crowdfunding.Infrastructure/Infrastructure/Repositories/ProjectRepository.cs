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
        public bool CreateProject(ProjectModels projectData)//新增
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

            this.dataBase.Projects.Add(project);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateProject(ProjectModels projectData) //修改
        {
            Project project = this.dataBase.Projects.FirstOrDefault(x => x.Id == projectData.Id) ?? throw new Exception("查無此資料");
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
        //public bool DeleteProject(Guid id) //刪除
        //{
        //    Project project = this.dataBase.Projects.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
        //    this.dataBase.Projects.Remove(project);
        //    this.dataBase.SaveChanges();
        //    return true;
        //}
        public ProjectModels GetProject(Guid id)//根據projectid查詢多個
        {
            if (!this.dataBase.Projects.Any(x => x.Id == id))
                throw new Exception("查無此資料");

            ProjectModels project = this.dataBase.Projects.Where(x => x.Id == id)
            .Select(x => new ProjectModels()
            {
                Id = x.Id,
                Name = x.Name,
                ProjectTypeId = x.ProjectTypeId,
                Cover = x.Cover,
                TargetMoney=x.TargetMoney,
                TotalDonate = x.InvestItems.Where(y => y.ProjectId == x.Id).Sum(y => y.Donate),
                ExpireTime =x.ExpireTime,
                Description=x.Description,
                Detail = x.Detail,
                UserId=x.UserId,
                CreateTime=x.CreateTime,
                Status=x.Status,
                UpdateTime=x.UpdateTime,
            }).First();

            return project;
        }

        public bool DeleteProject(Guid id) //刪除
        {
            Project project = this.dataBase.Projects.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
            project.IsDelete = false;
            this.dataBase.SaveChanges();
            return true;
        }

        public List<ProjectModels> SearchProjects(ProjectSearchModel searchModel)
        {
            List<ProjectModels> project = this.dataBase.Projects
                .Where(x=> !String.IsNullOrEmpty(searchModel.ProjectName) ? x.Name.Contains(searchModel.ProjectName): true)
                .Where(x=> !String.IsNullOrEmpty(searchModel.ProjectStatus) ? x.Status == searchModel.ProjectStatus : true)
                .Where(x=> searchModel.LimitMoney >0 ? x.TargetMoney <= searchModel.LimitMoney : true)
            .Select(x => new ProjectModels()
            {
                Id = x.Id,
                Name = x.Name,
                ProjectTypeId = x.ProjectTypeId,
                Cover = x.Cover,
                TargetMoney = x.TargetMoney,
                TotalDonate = x.InvestItems.Where(y => y.ProjectId == x.Id).Sum(y => y.Donate), // this.dataBase.InvestItems.Where(y => y.ProjectId == x.Id).Sum(x => x.Donate),
                ExpireTime = x.ExpireTime,
                Description = x.Description,
                Detail = x.Detail,
                UserId = x.UserId,
                CreateTime = x.CreateTime,
                Status = x.Status,
                UpdateTime = x.UpdateTime,
            }).ToList().Where(x => {
                var timeSpan = x.ExpireTime - DateTime.Now;

                if (timeSpan < TimeSpan.Zero)
                    return false;
                if (searchModel.ExpireStatus == "ALL")
                    return true;

                if (searchModel.ExpireStatus == "24H" && timeSpan.Days == 0)
                    return true;

                if (searchModel.ExpireStatus == "7Day" && timeSpan.Days <= 7)
                    return true;

                if (searchModel.ExpireStatus == "7Day" && timeSpan.Days <= 7)
                    return true;

                return false;


            }).ToList();

            return project;
        }


        public List<ProjectModels> GetProjects()//根據projectid查詢多個
        {
            List<ProjectModels> project = this.dataBase.Projects
            .Select(x => new ProjectModels()
            {
                Id = x.Id,
                Name = x.Name,
                ProjectTypeId = x.ProjectTypeId,
                Cover = x.Cover,
                TargetMoney = x.TargetMoney,
                TotalDonate = x.InvestItems.Where(y=>y.ProjectId == x.Id).Sum(y=>y.Donate), // this.dataBase.InvestItems.Where(y => y.ProjectId == x.Id).Sum(x => x.Donate),
                ExpireTime = x.ExpireTime,
                Description = x.Description,
                Detail = x.Detail,
                UserId = x.UserId,
                CreateTime = x.CreateTime,
                Status = x.Status,
                UpdateTime = x.UpdateTime,
            }).ToList();

            return project;
        }
        public List<ProjectModels> GetProjectsByUserID(Guid id)//根據projectid查詢多個
        {
            if (!this.dataBase.Projects.Any(x => x.UserId == id))
                throw new Exception("查無此資料");

            List<ProjectModels> project = this.dataBase.Projects.Where(x => x.UserId == id)
            .Select(x => new ProjectModels()
            {
                Id = x.Id,
                Name = x.Name,
                ProjectTypeId = x.ProjectTypeId,
                Cover = x.Cover,
                TargetMoney = x.TargetMoney,
                TotalDonate = x.InvestItems.Where(y => y.ProjectId == x.Id).Sum(y => y.Donate), // this.dataBase.InvestItems.Where(y => y.ProjectId == x.Id).Sum(x => x.Donate),
                ExpireTime = x.ExpireTime,
                Description = x.Description,
                Detail = x.Detail,
                UserId = x.UserId,
                CreateTime = x.CreateTime,
                Status = x.Status,
                UpdateTime = x.UpdateTime,
            }).ToList();

            return project;
        }
    }
}
