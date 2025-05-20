using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.SearchProjects
{
    public class SearchProjectsRes
    {
        public List<ProjectModels> Projects { get; set; }
    }
}
