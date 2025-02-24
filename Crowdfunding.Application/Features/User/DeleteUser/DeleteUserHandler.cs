using AutoMapper;
using Crowdfunding.Application.Models;
using Crowdfunding.Database.Entities;
using Crowdfunding.Infrastructure.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crowdfunding.Application.Features.User.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserReq, Response>
    {
        UserRepository repository;
        public DeleteUserHandler(UserRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(DeleteUserReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = this.repository.DeleteUser(request.Id);

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
