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

namespace Crowdfunding.Application.Features.ProjectImage.GetProjectImageByProjectID
{
    public class GetProjectImageByProjectIDHandler : IRequestHandler<GetProjectImageByProjectIDReq, ResponseData<GetProjectImageByProjectIDRes>>
    {
        ProjectImageRepository repository;
        public GetProjectImageByProjectIDHandler(ProjectImageRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetProjectImageByProjectIDRes>> Handle(GetProjectImageByProjectIDReq request, CancellationToken cancellationToken)
        {
            List<ProjectImageModels> projectImageModels = this.repository.GetProjectImageByProjectID(request.projectid);
            GetProjectImageByProjectIDRes getProjectImageByProjectIDRes = new GetProjectImageByProjectIDRes();
            getProjectImageByProjectIDRes.projectImageModels = projectImageModels;
            return await Task.FromResult(new ResponseData<GetProjectImageByProjectIDRes>(getProjectImageByProjectIDRes));
        }
    }
}
