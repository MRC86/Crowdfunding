using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.UpdateProject
{
    public class UpdateProjectReq : IRequest<Response>
    {
        public String Name { get; set; }
        public Guid ProjectTypeId { get; set; }

        public string Cover { get; set; }

        public int TargetMoney { get; set; }

        public DateTime ExpireTime { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        public Guid UserId { get; set; }
    }
}
