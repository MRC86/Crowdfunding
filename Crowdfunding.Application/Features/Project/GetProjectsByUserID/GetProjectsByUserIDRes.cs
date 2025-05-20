using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Project.GetProjectsByUserID
{
    public class GetProjectsByUserIDRes
    {
        public List<ProjectModels> Projects { get; set; }
    }
}
