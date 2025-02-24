using Crowdfunding.Application.Features.Project.CreateProject;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using Crowdfunding.Share.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Comment.CreateComment
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentReq, Response>
    {
        CommentRepository repository;
        public CreateCommentHandler(CommentRepository repository)
        {
            this.repository = repository;
        }

        //擇一選擇做使用，如果API要回傳資料就選擇 ResponseData，如果不需要回傳資料就選擇Response
        public async Task<Response> Handle(CreateCommentReq request, CancellationToken cancellationToken)
        {
            CommentModels commentModels = Mapper.Map<CreateCommentReq, CommentModels>(request);
            bool isSuccess = this.repository.CreateComment(commentModels);
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
