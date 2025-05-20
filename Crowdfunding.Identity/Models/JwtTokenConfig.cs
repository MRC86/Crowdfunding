using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Identity.Models
{
    public class JwtTokenConfig
    {
        public string Secret { get; set; }//秘藥
        public string Issuer { get; set; }//發行人
        public string Audience { get; set; }//觀眾
        public int ExpirationMinute { get; set; }//到期分鐘
    }
}
