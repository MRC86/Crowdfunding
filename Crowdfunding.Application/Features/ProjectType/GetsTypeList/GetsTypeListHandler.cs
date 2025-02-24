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

namespace Crowdfunding.Application.Features.ProjectType.GetsTypeList
{
    public class GetsTypeListHandler : IRequestHandler<GetsTypeListReq, ResponseData<GetsTypeListRes>>
    {
        ProjectTypeRepository repository;
        public GetsTypeListHandler(ProjectTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetsTypeListRes>> Handle(GetsTypeListReq request, CancellationToken cancellationToken)
        {
            List<ProjectTypeModels> projects = this.repository.GetsTypeList();
            GetsTypeListRes getsTypeListRes = new GetsTypeListRes();
            getsTypeListRes.Projects = projects;
            return await Task.FromResult(new ResponseData<GetsTypeListRes>(getsTypeListRes));
        }
    }
}
