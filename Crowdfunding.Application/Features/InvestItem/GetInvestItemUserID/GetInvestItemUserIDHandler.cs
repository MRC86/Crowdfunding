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

namespace Crowdfunding.Application.Features.InvestItem.GetInvestItemUserID
{
    public class GetInvestItemUserIDHandler : IRequestHandler<GetInvestItemUserIDReq, ResponseData<GetInvestItemUserIDRes>>
    {
        InvestItemRepository repository;
        public GetInvestItemUserIDHandler(InvestItemRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetInvestItemUserIDRes>> Handle(GetInvestItemUserIDReq request, CancellationToken cancellationToken)
        {
            List<InvestItemModels> investItemModels = this.repository.GetInvestItemUserID(request.userID);
            GetInvestItemUserIDRes getInvestItemUserIDRes = new GetInvestItemUserIDRes();
            getInvestItemUserIDRes.InvestItemUserID = investItemModels;
            return await Task.FromResult(new ResponseData<GetInvestItemUserIDRes>(getInvestItemUserIDRes));
        }
    }
}
