using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.InvestItem.UpdateInvestItem
{
    public class UpdateInvestItemReq : IRequest<Response>
    {
        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public int Donate { get; set; }

        public bool IsDelete { get; set; }
    }
}
