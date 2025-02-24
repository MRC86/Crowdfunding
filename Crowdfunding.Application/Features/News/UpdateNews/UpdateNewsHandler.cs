using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using Crowdfunding.Share.Utility;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.News.UpdateNews
{
    public class UpdateNewsHandler : IRequestHandler<UpdateNewsReq, Response>
    {
        NewsRepository repository;
        public UpdateNewsHandler(NewsRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(UpdateNewsReq request, CancellationToken cancellationToken)
        {
            NewsModels newsModels = Mapper.Map<UpdateNewsReq, NewsModels>(request);
            bool isSuccess = this.repository.UpdateNews(newsModels);

            if (isSuccess)
            {
                return await Task.FromResult(new Response("新增成功"));
            }
            else
            {
                return await Task.FromResult(new Response("新增失敗"));
            }
        }
    }
}
