using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.User.UpdateUser
{
    public class UpdateUserReq : IRequest<Response>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Account1 { get; set; }

        public string Password { get; set; }
    }
}
