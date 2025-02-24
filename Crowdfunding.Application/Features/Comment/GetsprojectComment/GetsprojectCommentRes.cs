using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Comment.GetsprojectComment
{
    public class GetsprojectCommentRes
    {
        public List<CommentModels> Comments { get; set; }
    }
}
