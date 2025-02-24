using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Question.GetQuestionByProjectID
{
    public class GetQuestionByProjectIDReq : IRequest<ResponseData<GetQuestionByProjectIDRes>>
    {
        public Guid ProjectID { get; set; }
    }
}
