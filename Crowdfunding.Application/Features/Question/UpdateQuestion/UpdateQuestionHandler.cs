using Crowdfunding.Application.Features.Project.CreateProject;
using Crowdfunding.Application.Features.Question.CreateQuestion;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using Crowdfunding.Share.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Question.UpdateQuestion
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionReq, Response>
    {
        QuestionRepository repository;
        public UpdateQuestionHandler(QuestionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(UpdateQuestionReq request, CancellationToken cancellationToken)
        {
            QuestionModels questionModels = Mapper.Map<UpdateQuestionReq, QuestionModels>(request);
            bool isSuccess = this.repository.UpdateQuestion(questionModels);

            if (isSuccess)
            {
                return await Task.FromResult(new Response("新增成功"));
            }
            else
            {
                return await Task.FromResult(new Response("新增失敗"));
            }
        }
    }
}
