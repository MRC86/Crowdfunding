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

namespace Crowdfunding.Application.Features.Favorite.GetFavoriteByUserID
{
    public class GetFavoriteByUserIDHandler : IRequestHandler<GetFavoriteByUserIDReq, ResponseData<GetFavoriteByUserIDRes>>
    {
        FavoriteRepository repository;
        public GetFavoriteByUserIDHandler(FavoriteRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetFavoriteByUserIDRes>> Handle(GetFavoriteByUserIDReq request, CancellationToken cancellationToken)
        {
            List<FavoriteModels> favoriteModels = this.repository.GetFavoriteByUserID(request.userID);
            GetFavoriteByUserIDRes getFavoriteByUserIDRes = new GetFavoriteByUserIDRes();
            getFavoriteByUserIDRes.favoriteModels = favoriteModels;
            return await Task.FromResult(new ResponseData<GetFavoriteByUserIDRes>(getFavoriteByUserIDRes));
        }
    }
}
