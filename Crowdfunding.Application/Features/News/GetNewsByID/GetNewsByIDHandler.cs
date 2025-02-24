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

namespace Crowdfunding.Application.Features.News.GetNewsByID
{
    public class GetNewsByIDHandler : IRequestHandler<GetNewsByIDReq, ResponseData<GetNewsByIDRes>>
    {
        NewsRepository repository;
        public GetNewsByIDHandler(NewsRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetNewsByIDRes>> Handle(GetNewsByIDReq request, CancellationToken cancellationToken)
        {
            List<NewsModels> newsModels = this.repository.GetNewsByID(request.projectid);
            GetNewsByIDRes getNewsByIDRes = new GetNewsByIDRes();
            getNewsByIDRes.newsModels = newsModels;
            return await Task.FromResult(new ResponseData<GetNewsByIDRes>(getNewsByIDRes));
        }
    }
}
