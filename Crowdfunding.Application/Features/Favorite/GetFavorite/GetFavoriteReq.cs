﻿using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Favorite.GetFavorite
{
    public class GetFavoriteReq : IRequest<ResponseData<GetFavoriteRes>>
    {
        public Guid Id { get; set; }
    }
}
