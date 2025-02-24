using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.DeleteProject
{
    public class DeleteProjectReq : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
