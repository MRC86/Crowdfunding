﻿using Crowdfunding.Database.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Infrastructure.Models
{
    public class InvestItemModels
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid ProjectId { get; set; }

        public int Donate { get; set; }

        public DateTime CreateTime { get; set; }
        public bool IsDelete { get; set; }

    }
}
