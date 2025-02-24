using Crowdfunding.Application.Features.Project.CreateProject;
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

namespace Crowdfunding.Application.Features.User.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserReq, Response>
    {
        UserRepository repository;
        public UpdateUserHandler(UserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(UpdateUserReq request, CancellationToken cancellationToken)
        {
            UserModels users = Mapper.Map<UpdateUserReq, UserModels>(request);
            bool isSuccess = this.repository.UpdateUser(users);

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
