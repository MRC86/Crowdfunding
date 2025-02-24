using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.SuperComment.GetSuperCommentByProjectID
{
    public class GetSuperCommentByProjectIDRes
    {
        public List<SuperCommentModels> superCommentModels { get; set; }
    }
}
