using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Account
{
    public class LoginReq : IRequest<ResponseData<LoginRes>>
    {
        public String Account { get; set; }
        public String Password { get; set; }
    }
}
