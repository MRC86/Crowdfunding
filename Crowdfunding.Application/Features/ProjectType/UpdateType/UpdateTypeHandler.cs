using Crowdfunding.Application.Features.ProjectType.CreateType;
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

namespace Crowdfunding.Application.Features.ProjectType.UpdateType
{
    public class UpdateTypeHandler : IRequestHandler<UpdateTypeReq, Response>
    {
        ProjectTypeRepository repository;
        public UpdateTypeHandler(ProjectTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(UpdateTypeReq request, CancellationToken cancellationToken)
        {
            ProjectTypeModels projectTypeModels = Mapper.Map<UpdateTypeReq, ProjectTypeModels>(request);
            bool isSuccess = this.repository.UpdateType(projectTypeModels);

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
