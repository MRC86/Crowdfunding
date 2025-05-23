﻿using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.ProjectType.UpdateType
{
    public class UpdateTypeReq : IRequest<Response>
    {
        public String Name { get; set; }
    }
}
