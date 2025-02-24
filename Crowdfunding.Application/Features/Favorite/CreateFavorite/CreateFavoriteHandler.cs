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

namespace Crowdfunding.Application.Features.Favorite.CreateFavorite
{
    public class CreateFavoriteHandler : IRequestHandler<CreateFavoriteReq, Response>
    {
        FavoriteRepository repository;
        public CreateFavoriteHandler(FavoriteRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response> Handle(CreateFavoriteReq request, CancellationToken cancellationToken)
        {
            FavoriteModels favoriteModels = Mapper.Map<CreateFavoriteReq, FavoriteModels>(request);
            bool isSuccess = this.repository.CreateFavorite(favoriteModels);

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
