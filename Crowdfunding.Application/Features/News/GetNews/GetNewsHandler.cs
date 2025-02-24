using AutoMapper;
using Crowdfunding.Application.Models;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using Crowdfunding.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.News.GetNews
{
    public class GetNewsHandler : IRequestHandler<GetNewsReq, ResponseData<GetNewsRes>>
    {
        NewsRepository repository;
        public GetNewsHandler(NewsRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetNewsRes>> Handle(GetNewsReq request, CancellationToken cancellationToken)
        {
            NewsModels newsModels = this.repository.GetNews(request.Id);
            GetNewsRes getNewsRes = new GetNewsRes();
            getNewsRes.newsModels = newsModels;
            return await Task.FromResult(new ResponseData<GetNewsRes>(getNewsRes));
        }
    }
}
