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

namespace Crowdfunding.Application.Features.InvestItem.CreateInvestItem
{
    public class CreateInvestItemHandler : IRequestHandler<CreateInvestItemReq, Response>
    {
        InvestItemRepository repository;
        public CreateInvestItemHandler(InvestItemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response> Handle(CreateInvestItemReq request, CancellationToken cancellationToken)
        {
            InvestItemModels investItemModels = Mapper.Map<CreateInvestItemReq, InvestItemModels>(request);
            bool isSuccess = this.repository.CreateInvestItem(investItemModels);

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
