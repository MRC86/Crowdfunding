﻿using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.ProjectImage.DeleteProjectImage
{
    public class DeleteProjectImageReq : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}
