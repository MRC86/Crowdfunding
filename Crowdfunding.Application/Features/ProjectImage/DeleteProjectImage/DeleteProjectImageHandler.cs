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

namespace Crowdfunding.Application.Features.ProjectImage.DeleteProjectImage
{
    public class DeleteProjectImageHandler : IRequestHandler<DeleteProjectImageReq, Response>
    {
        ProjectImageRepository repository;
        public DeleteProjectImageHandler(ProjectImageRepository repository)
        {
            this.repository = repository;
        }
        public async Task<Response> Handle(DeleteProjectImageReq request, CancellationToken cancellationToken)
        {
            bool isSuccess = this.repository.DeleteProjectImage(request.Id);

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
