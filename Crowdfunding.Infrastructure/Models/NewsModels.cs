using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Models
{
    public class NewsModels
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid ProjectId { get; set; }
    }
}
