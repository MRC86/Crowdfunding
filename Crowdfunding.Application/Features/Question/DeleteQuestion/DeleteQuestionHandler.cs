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

namespace Crowdfunding.Application.Features.Question.DeleteQuestion
{
    public class DeleteQuestionHandler : IRequestHandler<DeleteQuestionReq, Response>
    {
        QuestionRepository repository;
        public DeleteQuestionHandler(QuestionRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(DeleteQuestionReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = this.repository.DeleteQuestion(request.Id);

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
