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

namespace Crowdfunding.Application.Features.User.GetUser
{
    public class GetUserHandler : IRequestHandler<GetUserReq, ResponseData<GetUserRes>>
    {
        UserRepository repository;
        public GetUserHandler(UserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ResponseData<GetUserRes>> Handle(GetUserReq request, CancellationToken cancellationToken)
        {
            UserModels user = this.repository.GetUser(request.Id);
            GetUserRes getUserRes = new GetUserRes();
            getUserRes.userModels = user;
            return await Task.FromResult(new ResponseData<GetUserRes>(getUserRes));
        }
    }
}
