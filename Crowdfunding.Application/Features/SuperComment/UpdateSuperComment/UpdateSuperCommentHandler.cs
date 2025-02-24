using Crowdfunding.Application.Features.Project.CreateProject;
using Crowdfunding.Application.Features.SuperComment.CreateSuperComment;
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

namespace Crowdfunding.Application.Features.SuperComment.UpdateSuperComment
{
    public class UpdateSuperCommentHandler : IRequestHandler<UpdateSuperCommentReq, Response>
    {
        SuperCommentRepository repository;
        public UpdateSuperCommentHandler(SuperCommentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(UpdateSuperCommentReq request, CancellationToken cancellationToken)
        {
            SuperCommentModels superCommentData = Mapper.Map<UpdateSuperCommentReq, SuperCommentModels>(request);
            bool isSuccess = this.repository.UpdateSuperComment(superCommentData);

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
