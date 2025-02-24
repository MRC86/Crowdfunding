using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.SuperComment.GetSuperCommentByProjectID
{
    public class GetSuperCommentByProjectIDReq : IRequest<ResponseData<GetSuperCommentByProjectIDRes>>
    {
        public Guid projectid { get; set; }
    }
}
