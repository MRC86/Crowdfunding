using AutoMapper;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Question.GetQuestion
{
    public class GetQuestionHandler : IRequestHandler<GetQuestionReq, ResponseData<GetQuestionRes>>
    {
        QuestionRepository repository;
        public GetQuestionHandler(QuestionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetQuestionRes>> Handle(GetQuestionReq request, CancellationToken cancellationToken)
        {
            QuestionModels questionModels = this.repository.GetQuestion(request.Id);
            GetQuestionRes getQuestionRes = new GetQuestionRes();
            getQuestionRes.questionModels = questionModels;
            return await Task.FromResult(new ResponseData<GetQuestionRes>(getQuestionRes));
        }
    }
}
