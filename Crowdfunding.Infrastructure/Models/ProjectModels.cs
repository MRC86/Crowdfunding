using Crowdfunding.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Models
{
    public class ProjectModels
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid ProjectTypeId { get; set; }

        public string Cover { get; set; }

        public int TargetMoney { get; set; }
        public int TotalDonate { get; set; }

        public DateTime ExpireTime { get; set; }

        public string Description { get; set; }

        public string Detail { get; set; }

        public Guid UserId { get; set; }

        public DateTime CreateTime { get; set; }

        public string Status { get; set; }

        public DateTime UpdateTime { get; set; }
        public bool IsDelete { get; set; }

    }
}
