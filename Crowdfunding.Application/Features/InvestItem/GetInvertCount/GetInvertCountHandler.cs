using AutoMapper;
using Crowdfunding.Application.Features.InvestItem.GetInvestItem;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.InvestItem.GetInvertCount
{
    public class GetInvertCountHandler : IRequestHandler<GetInvertCountReq, ResponseData<GetInvertCountRes>>
    {
        InvestItemRepository repository;
        public GetInvertCountHandler(InvestItemRepository repository)
        {
            this.repository = repository;
        }

        //擇一選擇做使用，如果API要回傳資料就選擇 ResponseData，如果不需要回傳資料就選擇Response
        public async Task<ResponseData<GetInvertCountRes>> Handle(GetInvertCountReq request, CancellationToken cancellationToken)
        {
            int investItemModels = this.repository.GetInvertCount(request.Id);
            GetInvertCountRes getInvestItemRes = new GetInvertCountRes();
            getInvestItemRes.InvestItemCount = investItemModels;
            return await Task.FromResult(new ResponseData<GetInvertCountRes>(getInvestItemRes));
        }
    }
}
