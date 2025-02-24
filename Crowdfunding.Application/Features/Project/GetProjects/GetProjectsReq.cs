using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.GetProjects
{
    public class GetProjectsReq : IRequest<ResponseData<GetProjectsRes>>
    {
        public Guid ProjectID { get; set; } 
    }
}
