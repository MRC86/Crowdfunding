using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.News.GetNews
{
    public class GetNewsReq : IRequest<ResponseData<GetNewsRes>>
    {
        public Guid Id { get; set; }
    }
}
