using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.User.GetUser
{
    public class GetUserReq : IRequest<ResponseData<GetUserRes>>
    {
        public Guid Id { get; set; }
    }
}
