using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using Crowdfunding.Share.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Favorite.UpdateFavorite
{
    public class UpdateFavoriteHandler : IRequestHandler<UpdateFavoriteReq, Response>
    {
        FavoriteRepository repository;
        public UpdateFavoriteHandler(FavoriteRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response> Handle(UpdateFavoriteReq request, CancellationToken cancellationToken)
        {
            FavoriteModels favoriteModels = Mapper.Map<UpdateFavoriteReq, FavoriteModels>(request);
            bool isSuccess = this.repository.UpdateFavorite(favoriteModels);

            if (isSuccess)
            {
                return await Task.FromResult(new Response("新增成功"));
            }
            else
            {
                return await Task.FromResult(new Response("新增失敗"));
            }
        }
    }
}
