using Crowdfunding.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.News.GetNewsByID
{
    public class GetNewsByIDRes
    {
        public List<NewsModels> newsModels { get; set; }
    }
}
