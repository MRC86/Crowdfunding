using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Infrastructure.Repositories
{
    public class FavoriteRepository
    {
        DatabaseContext dataBase;
        public FavoriteRepository(DatabaseContext database)
        {
            this.dataBase = database;
        }
        public bool CreateFavorite(FavoriteModels FavoriteData)//新增6
        {
            if (FavoriteData == null)
                return false;
            Favorite favorite = new Favorite();
            favorite.Id = Guid.NewGuid();
            favorite.UserId = FavoriteData.UserId;
            favorite.ProjectId = FavoriteData.ProjectId;
            favorite.CreateTime = DateTime.Now;

            this.dataBase.Favorites.Add(favorite);
            this.dataBase.SaveChanges();
            return true;
        }
        public bool UpdateFavorite(FavoriteModels FavoriteData) //修改6
        {
            Favorite favorite = this.dataBase.Favorites.FirstOrDefault(x => x.Id == FavoriteData.Id) ?? throw new Exception("查無此資料");
            this.dataBase.SaveChanges();
            return true;
        }
        public bool DeleteFavorite(Guid id) //刪除6
        {
            Favorite favorite = this.dataBase.Favorites.FirstOrDefault(x => x.Id == id) ?? throw new Exception("查無此資料");
            this.dataBase.Favorites.Remove(favorite);
            this.dataBase.SaveChanges();
            return true;
        }
        public FavoriteModels GetFavorite(Guid id)//查詢6
        {
            if (!this.dataBase.Favorites.Any(x => x.Id == id))
                throw new Exception("查無此資料");

            FavoriteModels favorite = this.dataBase.Favorites.Where(x => x.Id == id)
            .Select(x => new FavoriteModels()
            {
                Id = x.Id,
                UserId = x.UserId,
                ProjectId = x.ProjectId,
                CreateTime = x.CreateTime,
            }).First();

            return favorite;
        }
        public List<FavoriteModels> GetFavoriteByUserID(Guid userID)//查詢
        {
            if (!this.dataBase.Favorites.Any(x => x.UserId == userID))
                throw new Exception("查無此資料");

            List<FavoriteModels> favorite = this.dataBase.Favorites.Where(x => x.UserId == userID)
            .Select(x => new FavoriteModels()
            {
                Id = x.Id,
                UserId = x.UserId,
                ProjectId = x.ProjectId,
                CreateTime = x.CreateTime,
            }).ToList();

            return favorite;
        }
    }
}
