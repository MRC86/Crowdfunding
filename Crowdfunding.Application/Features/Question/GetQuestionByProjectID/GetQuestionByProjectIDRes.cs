using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Question.GetQuestionByProjectID
{
    public class GetQuestionByProjectIDRes
    {
        public List<QuestionModels> questionModels { get; set; }
    }
}
