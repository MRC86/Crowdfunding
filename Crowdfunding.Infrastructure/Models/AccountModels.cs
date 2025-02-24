using Crowdfunding.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;

namespace Crowdfunding.Infrastructure.Models
{
    public class AccountModels
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Account1 { get; set; }

        public string Password { get; set; }

    }
}


//FavoriteRepository
//    CreateFavorite
//    UpdateFavorite
//    DeleteFavorite
//    GetFavorite
//    GetFavoriteByUserID
//InvestItemRepository
//    CreateInvestItem
//    UpdateInvestItem
//    GetInvestItem
//    GetInvestItemUserID
//    RemoveInvestItem
//    ResumeInvestItem
//NewsRepository
//    CreateNews
//    UpdateNews
//    DeleteNews
//    GetNews
//    GetNewsByID
//ProjectImageRepository
//    CreateProjectImage
//    UpdateProjectImage
//    DeleteProjectImage
//    GetProjectImage
//    GetProjectImageByProjectID
//ProjectRepository
//    CreateProject
//    UpdateProject
//    GetProjects
//    DeleteProject
//ProjectTypeRepository
//    CreateType
//    UpdateType
//    DeleteType
//    GetsTypeList
//QuestionRepository
//    CreateQuestion
//    UpdateQuestion
//    DeleteQuestion
//    GetQuestion
//    GetQuestionByProjectID
//SuperCommentRepository
//    CreateSuperComment
//    UpdateSuperComment
//    DeleteSuperComment
//    GetSuperComment
//    GetSuperCommentByProjectID
//UserRepository
//    CreateUser
//    UpdateUser
//    DeleteUser
//    GetUser