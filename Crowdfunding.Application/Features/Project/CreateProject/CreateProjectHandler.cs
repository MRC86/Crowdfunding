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

namespace Crowdfunding.Application.Features.Project.CreateProject
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectReq, Response>
    {
        ProjectRepository repository;
        public CreateProjectHandler(ProjectRepository repository)
        {
            this.repository = repository;
        }

        //擇一選擇做使用，如果API要回傳資料就選擇 ResponseData，如果不需要回傳資料就選擇Response
        public async Task<Response> Handle(CreateProjectReq request, CancellationToken cancellationToken)
        {
            ProjectModels projectModel =  Mapper.Map<CreateProjectReq, ProjectModels>(request);
            bool isSuccess = this.repository.CreateProject(projectModel);
            if (isSuccess)
            {
                return await Task.FromResult(new Response("新增成功"));
            } else
            {
                return await Task.FromResult(new Response("新增失敗"));
            }
        }
    }
}
