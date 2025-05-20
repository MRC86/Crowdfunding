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

namespace Crowdfunding.Application.Features.Project.GetProjects
{
    public class GetProjectsHandler : IRequestHandler<GetProjectsReq, ResponseData<GetProjectsRes>>
    {
        ProjectRepository repository;
        public GetProjectsHandler(ProjectRepository projectRepository)
        {
            this.repository = projectRepository;
        }

        //擇一選擇做使用，如果API要回傳資料就選擇 ResponseData，如果不需要回傳資料就選擇Response
        public async Task<ResponseData<GetProjectsRes>> Handle(GetProjectsReq request, CancellationToken cancellationToken)
        {
            List <ProjectModels> projects = this.repository.GetProjects();

            GetProjectsRes response = new GetProjectsRes();
            response.Projects = projects;
            return await Task.FromResult(new ResponseData<GetProjectsRes>(response));
        }
       
    }
}
