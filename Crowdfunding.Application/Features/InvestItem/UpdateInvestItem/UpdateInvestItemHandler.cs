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

namespace Crowdfunding.Application.Features.InvestItem.UpdateInvestItem
{
    public class UpdateInvestItemHandler : IRequestHandler<UpdateInvestItemReq, Response>
    {
        InvestItemRepository repository;
        public UpdateInvestItemHandler(InvestItemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Response> Handle(UpdateInvestItemReq request, CancellationToken cancellationToken)
        {
            InvestItemModels investItemModels = Mapper.Map<UpdateInvestItemReq, InvestItemModels>(request);
            bool isSuccess = this.repository.UpdateInvestItem(investItemModels);

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
