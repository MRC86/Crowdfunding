using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.GetProjects
{
    public class GetProjectsRes
    {
        public List<ProjectModels> Projects { get; set; }   
    }
}
