using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.InvestItem.GetInvestItemUserID
{
    public class GetInvestItemUserIDReq : IRequest<ResponseData<GetInvestItemUserIDRes>>
    {
        public Guid userID { get; set; }
    }
}
