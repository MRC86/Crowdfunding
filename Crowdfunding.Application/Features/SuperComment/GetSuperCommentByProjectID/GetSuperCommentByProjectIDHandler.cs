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

namespace Crowdfunding.Application.Features.SuperComment.GetSuperCommentByProjectID
{
    public class GetSuperCommentByProjectIDHandler : IRequestHandler<GetSuperCommentByProjectIDReq, ResponseData<GetSuperCommentByProjectIDRes>>
    {
        SuperCommentRepository repository;
        public GetSuperCommentByProjectIDHandler(SuperCommentRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetSuperCommentByProjectIDRes>> Handle(GetSuperCommentByProjectIDReq request, CancellationToken cancellationToken)
        {
            List<SuperCommentModels> superCommentData = this.repository.GetSuperCommentByProjectID(request.projectid);
            GetSuperCommentByProjectIDRes getSuperCommentByProjectIDRes = new GetSuperCommentByProjectIDRes();
            getSuperCommentByProjectIDRes.superCommentModels = superCommentData;
            return await Task.FromResult(new ResponseData<GetSuperCommentByProjectIDRes>(getSuperCommentByProjectIDRes));
        }
    }
}
