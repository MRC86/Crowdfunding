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

namespace Crowdfunding.Application.Features.InvestItem.RemoveInvestItem
{
    public class RemoveInvestItemHandler : IRequestHandler<RemoveInvestItemReq, Response>
    {
        InvestItemRepository repository;
        public RemoveInvestItemHandler(InvestItemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response> Handle(RemoveInvestItemReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = this.repository.RemoveInvestItem(request.Id);

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
