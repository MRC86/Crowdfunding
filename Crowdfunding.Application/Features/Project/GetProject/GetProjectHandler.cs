using AutoMapper;
using Crowdfunding.Application.Features.Project.GetProjects;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.GetProject
{
    public class GetProjectHandler : IRequestHandler<GetProjectReq, ResponseData<GetProjectRes>>
    {
        ProjectRepository repository;
        public GetProjectHandler(ProjectRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetProjectRes>> Handle(GetProjectReq request, CancellationToken cancellationToken)
        {
            ProjectModels projects = this.repository.GetProject(request.ProjectID);

            GetProjectRes response = new GetProjectRes();
            response.Project = projects;
            return await Task.FromResult(new ResponseData<GetProjectRes>(response));
        }
    }
}
