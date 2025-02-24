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

namespace Crowdfunding.Application.Features.Question.GetQuestionByProjectID
{
    public class GetQuestionByProjectIDHandler : IRequestHandler<GetQuestionByProjectIDReq, ResponseData<GetQuestionByProjectIDRes>>
    {
        QuestionRepository repository;
        public GetQuestionByProjectIDHandler(QuestionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetQuestionByProjectIDRes>> Handle(GetQuestionByProjectIDReq request, CancellationToken cancellationToken)
        {
            List<QuestionModels> questionModels = this.repository.GetQuestionByProjectID(request.ProjectID);
            GetQuestionByProjectIDRes getQuestionByProjectIDRes = new GetQuestionByProjectIDRes();
            getQuestionByProjectIDRes.questionModels = questionModels;
            return await Task.FromResult(new ResponseData<GetQuestionByProjectIDRes>(getQuestionByProjectIDRes));
        }
    }
}
