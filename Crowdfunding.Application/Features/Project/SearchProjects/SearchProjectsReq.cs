using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.SearchProjects
{
    public class SearchProjectsReq : IRequest<ResponseData<SearchProjectsRes>>
    {
        public String ProjectName { get; set; }
        public int LimitMoney { get; set; }
        public string ProjectStatus { get; set; }
        public string ExpireStatus { get; set; }
    }
}
