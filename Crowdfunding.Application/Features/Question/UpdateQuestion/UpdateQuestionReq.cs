﻿using Crowdfunding.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.Question.UpdateQuestion
{
    public class UpdateQuestionReq : IRequest<Response>
    {
        public string Title { get; set; }

        public string Contents { get; set; }

        public Guid ProjectId { get; set; }
    }
}
