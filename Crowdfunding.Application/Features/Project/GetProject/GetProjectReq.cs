using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.GetProject
{
    public class GetProjectReq : IRequest<ResponseData<GetProjectRes>>
    {
        public Guid ProjectID { get; set; }
    }
}
