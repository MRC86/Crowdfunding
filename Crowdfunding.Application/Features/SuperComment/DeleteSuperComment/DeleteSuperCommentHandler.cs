using AutoMapper;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.SuperComment.DeleteSuperComment
{
    public class DeleteSuperCommentHandler : IRequestHandler<DeleteSuperCommentReq, Response>
    {
        SuperCommentRepository repository;
        public DeleteSuperCommentHandler(SuperCommentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(DeleteSuperCommentReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = this.repository.DeleteSuperComment(request.Id);

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
