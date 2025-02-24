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

namespace Crowdfunding.Application.Features.ProjectType.CreateType
{
    public class CreateTypeHandler : IRequestHandler<CreateTypeReq, Response>
    {
        ProjectTypeRepository repository;
        public CreateTypeHandler(ProjectTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(CreateTypeReq request, CancellationToken cancellationToken)
        {
            ProjectTypeModels projectTypeModels = Mapper.Map<CreateTypeReq, ProjectTypeModels>(request);
            bool isSuccess = this.repository.CreateType(projectTypeModels);

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
