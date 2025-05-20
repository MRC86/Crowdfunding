using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Models
{
    public class ProjectSearchModel
    {
        public String ProjectName { get; set; } 
        public int LimitMoney { get; set; } 
        public string ProjectStatus { get; set;}
        public string ExpireStatus { get; set; }    
    }
}
