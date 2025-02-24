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

namespace Crowdfunding.Application.Features.ProjectImage.CreateProjectImage
{
    public class CreateProjectImageHandler : IRequestHandler<CreateProjectImageReq, Response>
    {
        ProjectImageRepository repository;
        public CreateProjectImageHandler(ProjectImageRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(CreateProjectImageReq request, CancellationToken cancellationToken)
        {
            ProjectImageModels projectImageModels = Mapper.Map<CreateProjectImageReq, ProjectImageModels>(request);
            bool isSuccess = this.repository.CreateProjectImage(projectImageModels);

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
