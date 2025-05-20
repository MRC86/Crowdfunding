using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Identity.Models
{
    public class GenearteTokenDTO
    {
        public String UserId { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }

        public GenearteTokenDTO(string userId, string name, string email, string mobile)
        {
            this.UserId = userId;
            this.Name = name;
            this.Email = email;
            this.Mobile = mobile;
        }
    }
}
