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

namespace Crowdfunding.Application.Features.InvestItem.GetInvestItem
{
    public class GetInvestItemHandler : IRequestHandler<GetInvestItemReq, ResponseData<GetInvestItemRes>>
    {
        InvestItemRepository repository;
        public GetInvestItemHandler(InvestItemRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ResponseData<GetInvestItemRes>> Handle(GetInvestItemReq request, CancellationToken cancellationToken)
        {
            InvestItemModels investItemModels = this.repository.GetInvestItem(request.InvestItemID);
            GetInvestItemRes getInvestItemRes = new GetInvestItemRes();
            getInvestItemRes.InvestItem = investItemModels;
            return await Task.FromResult(new ResponseData<GetInvestItemRes>(getInvestItemRes));
        }
    }
}
