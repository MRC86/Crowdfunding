using AutoMapper;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.InvestItem.ResumeInvestItem
{
    public class ResumeInvestItemHandler : IRequestHandler<ResumeInvestItemReq, Response>
    {
        InvestItemRepository repository;
        public ResumeInvestItemHandler(InvestItemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response> Handle(ResumeInvestItemReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = this.repository.ResumeInvestItem(request.Id);

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
