using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class ProjectImageRepository
    {
        DatabaseContext dataBase;
        public ProjectImageRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }


        public bool CreateProjectImage(ProjectImageModels projectImageData)//新增
        {
            if (projectImageData == null)
                return false;
            ProjectImage projectImage = new ProjectImage();
            projectImage.Id = Guid.NewGuid();
            projectImage.Img = projectImageData.Img;
            projectImage.ProjectId = projectImageData.ProjectId;
            projectImage.CreateTime = DateTime.Now;

            this.dataBase.ProjectImages.Add(projectImage);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateProjectImage(ProjectImageModels projectImageData) //修改
        {
            ProjectImage projectImage = this.dataBase.ProjectImages.FirstOrDefault(x => x.Id == projectImageData.Id) ?? throw new Exception("查無此資料");
            projectImage.Img = projectImageData.Img;
            this.dataBase.SaveChanges();
            return true;
        }
        public bool DeleteProjectImage(Guid id) //刪除
        {
            ProjectImage projectImage = this.dataBase.ProjectImages.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
            this.dataBase.ProjectImages.Remove(projectImage);
            this.dataBase.SaveChanges();
            return true;
        }
        public ProjectImageModels GetProjectImage(Guid id)//查詢 應該成根據projectid查詢多個
        {
            if (!this.dataBase.ProjectImages.Any(x => x.Id == id))
                throw new Exception("查無此資料");

            ProjectImageModels projectImage = this.dataBase.ProjectImages.Where(x => x.Id == id)
            .Select(x => new ProjectImageModels()
            {
                Id = x.Id,
                Img = x.Img,
                ProjectId = x.ProjectId,
            }).First();

            return projectImage;
        }
        public List<ProjectImageModels> GetProjectImageByProjectID(Guid projectid)//根據projectid查詢多個
        {
            if (!this.dataBase.ProjectImages.Any(x => x.ProjectId == projectid))
                throw new Exception("查無此資料");

            List<ProjectImageModels> list = this.dataBase.ProjectImages.Where(x => x.ProjectId == projectid)
            .Select(x => new ProjectImageModels()
            {
                Id = x.Id,
                Img = x.Img,
                ProjectId = x.ProjectId,
            }).ToList();

            return list;
        }
    }
}
