using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Comment.CreateComment
{
    public class CreateCommentReq : IRequest<Response>
    {

        public string Message { get; set; }

        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

    }
}
