using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCryptHelper = BCrypt.Net.BCrypt;

namespace Crowdfunding.Share.Utility
{
    public class Cryptography
    {
        public static string Hash(string Text)
        {
            String Salt = BCryptHelper.GenerateSalt();
            return BCryptHelper.HashPassword(Text, Salt);
        }
        public static bool VerifyHash(string Text, string HashedText)
        {
            return BCryptHelper.Verify(Text, HashedText);
        }
    }
}
