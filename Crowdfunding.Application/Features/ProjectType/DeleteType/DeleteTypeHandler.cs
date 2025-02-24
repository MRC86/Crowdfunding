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

namespace Crowdfunding.Application.Features.ProjectType.DeleteType
{
    public class DeleteTypeHandler : IRequestHandler<DeleteTypeReq, Response>
    {
        ProjectTypeRepository repository;
        public DeleteTypeHandler(ProjectTypeRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(DeleteTypeReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = this.repository.DeleteType(request.Id);

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
