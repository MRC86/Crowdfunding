using AutoMapper;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Favorite.GetFavorite
{
    public class GetFavoriteHandler : IRequestHandler<GetFavoriteReq, ResponseData<GetFavoriteRes>>
    {
        FavoriteRepository repository;
        public GetFavoriteHandler(FavoriteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetFavoriteRes>> Handle(GetFavoriteReq request, CancellationToken cancellationToken)
        {
            FavoriteModels favoriteModels = this.repository.GetFavorite(request.Id);
            GetFavoriteRes getFavoriteRes = new GetFavoriteRes();
            getFavoriteRes.favoriteModels = favoriteModels;
            return await Task.FromResult(new ResponseData<GetFavoriteRes>(getFavoriteRes));
        }
    }
}
