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

namespace Crowdfunding.Application.Features.ProjectImage.GetProjectImage
{
    public class GetProjectImageHandler : IRequestHandler<GetProjectImageReq, ResponseData<GetProjectImageRes>>
    {
        ProjectImageRepository repository;
        public GetProjectImageHandler(ProjectImageRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetProjectImageRes>> Handle(GetProjectImageReq request, CancellationToken cancellationToken)
        {
            ProjectImageModels projectImageModels = this.repository.GetProjectImage(request.Id);
            GetProjectImageRes getProjectImageRes = new GetProjectImageRes();
            getProjectImageRes.projectImageModels = projectImageModels;
            return await Task.FromResult(new ResponseData<GetProjectImageRes>(getProjectImageRes));
        }
    }
}
