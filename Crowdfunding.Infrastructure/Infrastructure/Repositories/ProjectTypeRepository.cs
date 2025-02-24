using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class ProjectTypeRepository
    {
        DatabaseContext dataBase;
        public ProjectTypeRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }

        public bool CreateType(ProjectTypeModels projectTypeModels)//�s�W
        {
            if(String.IsNullOrEmpty(projectTypeModels.Name))
                return false;   

            ProjectType projectType = new ProjectType();
            projectType.Id = Guid.NewGuid();
            projectType.Name = projectTypeModels.Name;
            projectType.CreateTime = DateTime.Now;
            this.dataBase.ProjectTypes.Add(projectType);
            this.dataBase.SaveChanges();
            return true;
        }

        public bool UpdateType(ProjectTypeModels projectTypeModels) //�ק�
        {
            ProjectType projectType = this.dataBase.ProjectTypes.FirstOrDefault(x => x.Id == projectTypeModels.Id) ?? throw new Exception("�d�L�����");
            projectType.Name = projectTypeModels.Name;
            this.dataBase.SaveChanges();
            return true;
        }

        public bool DeleteType(Guid id) //�R��
        {
            ProjectType projectType = this.dataBase.ProjectTypes.FirstOrDefault(x => x.Id == id) ?? throw new Exception("�d�L�����");
            this.dataBase.ProjectTypes.Remove(projectType);
            this.dataBase.SaveChanges();
            return true;
        }

        public List<ProjectTypeModels> GetsTypeList()//�d��
        {
           List<ProjectTypeModels> list =  this.dataBase.ProjectTypes.Select(x=> new ProjectTypeModels()
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();

            return list;
        }
    }
}
