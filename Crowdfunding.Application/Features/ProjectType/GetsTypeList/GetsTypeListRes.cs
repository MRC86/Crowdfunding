﻿using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.ProjectType.GetsTypeList
{
    public class GetsTypeListRes
    {
        public List<ProjectTypeModels> Projects { get; set; }
    }
}
