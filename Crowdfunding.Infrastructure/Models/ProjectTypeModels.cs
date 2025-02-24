using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Models
{
    public class ProjectTypeModels
    {
        public Guid Id { get; set; }    
        public String Name { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
