using AutoMapper;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Comment.DeleteComment
{
    public class DeleteCommentHandler : IRequestHandler<DeleteCommentReq, Response>
    {
        CommentRepository repository;
        public DeleteCommentHandler(CommentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response> Handle(DeleteCommentReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = this.repository.DeleteComment(request.Id);
            if (isSuccess)
            {
                return await Task.FromResult(new Response("新增成功"));
            }
            else
            {
                return await Task.FromResult(new Response("新增失敗"));
            }
        }
    }
}
