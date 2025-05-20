using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Account
{
    public class LoginRes
    {
        public Guid UserID { get; set; }
        public String Email { get; set; }
        public String Token { get; set; }
    }
}
