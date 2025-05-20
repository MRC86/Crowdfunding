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
using Crowdfunding.Share;
using Crowdfunding.Share.Utility;
namespace Crowdfunding.Application.Features.Project.SearchProjects
{
    public class SearchProjectsHandler : IRequestHandler<SearchProjectsReq, ResponseData<SearchProjectsRes>>
    {
        ProjectRepository repository;
        public SearchProjectsHandler(ProjectRepository repository)
        {
            this.repository = repository;
        }

        //擇一選擇做使用，如果API要回傳資料就選擇 ResponseData，如果不需要回傳資料就選擇Response
        public async Task<ResponseData<SearchProjectsRes>> Handle(SearchProjectsReq request, CancellationToken cancellationToken)
        {

            var searchModel =  Mapper.Map<SearchProjectsReq,ProjectSearchModel>(request);
            List<ProjectModels> projects = this.repository.SearchProjects(searchModel);

            SearchProjectsRes response = new SearchProjectsRes();
            response.Projects = projects;
            return await Task.FromResult(new ResponseData<SearchProjectsRes>(response));
        }
    }
}
