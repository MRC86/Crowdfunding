using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Comment.DeleteComment
{
    public class DeleteCommentReq : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
