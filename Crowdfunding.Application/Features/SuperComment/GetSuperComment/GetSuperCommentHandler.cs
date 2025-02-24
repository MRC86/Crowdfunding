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

namespace Crowdfunding.Application.Features.SuperComment.GetSuperComment
{
    public class GetSuperCommentHandler : IRequestHandler<GetSuperCommentReq, ResponseData<GetSuperCommentRes>>
    {
        SuperCommentRepository repository;
        public GetSuperCommentHandler(SuperCommentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetSuperCommentRes>> Handle(GetSuperCommentReq request, CancellationToken cancellationToken)
        {
            SuperCommentModels superCommentData = this.repository.GetSuperComment(request.Id);
            GetSuperCommentRes getSuperCommentRes = new GetSuperCommentRes();
            getSuperCommentRes.superCommentModels = superCommentData;
            return await Task.FromResult(new ResponseData<GetSuperCommentRes>(getSuperCommentRes));
        }
    }
}
