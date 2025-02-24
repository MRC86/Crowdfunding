using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.InvestItem.GetInvestItem
{
    public class GetInvestItemReq : IRequest<ResponseData<GetInvestItemRes>>
    {
        public Guid InvestItemID { get; set; }
    }
}
