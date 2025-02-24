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

namespace Crowdfunding.Application.Features.ProjectImage.UpdateProjectImage
{
    public class UpdateProjectImageHandler : IRequestHandler<UpdateProjectImageReq, Response>
    {
        ProjectImageRepository repository;
        public UpdateProjectImageHandler(ProjectImageRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(UpdateProjectImageReq request, CancellationToken cancellationToken)
        {
            ProjectImageModels projectImageModels = Mapper.Map<UpdateProjectImageReq, ProjectImageModels>(request);
            bool isSuccess = this.repository.UpdateProjectImage(projectImageModels);

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
