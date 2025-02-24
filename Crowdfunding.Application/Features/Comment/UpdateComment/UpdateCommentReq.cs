using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Comment.UpdateComment
{
    public class UpdateCommentReq : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }
    }
}
