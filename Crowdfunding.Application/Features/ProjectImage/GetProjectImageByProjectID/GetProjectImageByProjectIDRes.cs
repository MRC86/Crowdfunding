using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.ProjectImage.GetProjectImageByProjectID
{
    public class GetProjectImageByProjectIDRes
    {
        public List<ProjectImageModels> projectImageModels { get; set; }
    }
}
