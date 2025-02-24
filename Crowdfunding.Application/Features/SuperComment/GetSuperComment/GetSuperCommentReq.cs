using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.SuperComment.GetSuperComment
{
    public class GetSuperCommentReq : IRequest<ResponseData<GetSuperCommentRes>>
    {
        public Guid Id { get; set; }
    }
}
