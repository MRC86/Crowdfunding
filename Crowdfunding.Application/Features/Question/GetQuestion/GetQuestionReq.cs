using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Question.GetQuestion
{
    public class GetQuestionReq : IRequest<ResponseData<GetQuestionRes>>
    {
        public Guid Id { get; set; }
    }
}
