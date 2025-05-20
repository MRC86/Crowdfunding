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

namespace Crowdfunding.Application.Features.Project.GetProjectsByUserID
{
    public class GetProjectsByUserIDHandler : IRequestHandler<GetProjectsByUserIDReq, ResponseData<GetProjectsByUserIDRes>>
    {
        ProjectRepository repository;
        public GetProjectsByUserIDHandler(ProjectRepository projectRepository)
        {
            this.repository = projectRepository;
        }

        //擇一選擇做使用，如果API要回傳資料就選擇 ResponseData，如果不需要回傳資料就選擇Response
        public async Task<ResponseData<GetProjectsByUserIDRes>> Handle(GetProjectsByUserIDReq request, CancellationToken cancellationToken)
        {
            List<ProjectModels> projects = this.repository.GetProjectsByUserID(request.userID);

            GetProjectsByUserIDRes response = new GetProjectsByUserIDRes();
            response.Projects = projects;
            return await Task.FromResult(new ResponseData<GetProjectsByUserIDRes>(response));
        }
    }
}
