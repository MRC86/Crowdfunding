using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Comment.GetsprojectComment
{
    public class GetsprojectCommentReq : IRequest<ResponseData<GetsprojectCommentRes>>
    {
        public Guid ProjectID { get; set; }
    }
}
