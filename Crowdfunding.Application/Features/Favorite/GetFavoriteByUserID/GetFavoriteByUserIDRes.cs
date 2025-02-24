using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Favorite.GetFavoriteByUserID
{
    public class GetFavoriteByUserIDRes
    {
        public List<FavoriteModels> favoriteModels { get; set; }
    }
}
