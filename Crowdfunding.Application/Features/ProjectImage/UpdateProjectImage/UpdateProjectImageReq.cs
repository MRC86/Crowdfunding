using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.ProjectImage.UpdateProjectImage
{
    public class UpdateProjectImageReq : IRequest<Response>
    {
        public string Img { get; set; }

        public Guid ProjectId { get; set; }
    }
}
