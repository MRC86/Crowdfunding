using AutoMapper;
using Crowdfunding.Application.Features.Project.GetProjects;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Comment.GetsprojectComment
{
    public class GetsprojectCommentHandler : IRequestHandler<GetsprojectCommentReq, ResponseData<GetsprojectCommentRes>>
    {
        CommentRepository repository;
        public GetsprojectCommentHandler(CommentRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseData<GetsprojectCommentRes>> Handle(GetsprojectCommentReq request, CancellationToken cancellationToken)
        {
            List<CommentModels> Comments = this.repository.GetsprojectComment(request.ProjectID);
            GetsprojectCommentRes getsprojectCommentRes = new GetsprojectCommentRes();
            getsprojectCommentRes.Comments = Comments;
            return await Task.FromResult(new ResponseData<GetsprojectCommentRes>(getsprojectCommentRes));
        }
    }
}
