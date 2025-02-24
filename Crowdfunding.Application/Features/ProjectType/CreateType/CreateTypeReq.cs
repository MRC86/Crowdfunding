using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.ProjectType.CreateType
{
    public class CreateTypeReq : IRequest<Response>
    {
        public String Name { get; set; }
    }
}
