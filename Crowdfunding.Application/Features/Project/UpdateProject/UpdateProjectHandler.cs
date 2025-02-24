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

namespace Crowdfunding.Application.Features.Project.UpdateProject
{
    public class UpdateProjectHandler : IRequestHandler<UpdateProjectReq, Response>
    {
        ProjectRepository repository;
        public UpdateProjectHandler(ProjectRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(UpdateProjectReq request, CancellationToken cancellationToken)
        {
            ProjectModels projectModel = Mapper.Map<UpdateProjectReq, ProjectModels>(request);
            bool isSuccess = this.repository.CreateProject(projectModel);

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
