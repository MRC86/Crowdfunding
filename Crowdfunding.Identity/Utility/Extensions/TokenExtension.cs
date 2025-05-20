using Crowdfunding.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Identity.Utility.Extensions
{
    public static class TokenExtension
    {
        public static String FindClaim(this Claim[] claims, JWTClaimEnum key)
        {
            String name = key.ToString();
            String value = claims.First(claim => claim.Type == name).Value;
            return value;
        }
    }
}
