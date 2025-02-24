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
    public class QuestionModels
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }

        public DateTime CreateTime { get; set; }

        public Guid ProjectId { get; set; }
    }
}
