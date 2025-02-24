using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Favorite.GetFavoriteByUserID
{
    public class GetFavoriteByUserIDReq : IRequest<ResponseData<GetFavoriteByUserIDRes>>
    {
        public Guid userID { get; set; }
    }
}
