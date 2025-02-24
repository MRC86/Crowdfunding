using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.ProjectImage.GetProjectImage
{
    public class GetProjectImageReq : IRequest<ResponseData<GetProjectImageRes>>
    {
        public Guid Id { get; set; }
    }
}
