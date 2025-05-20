using Crowdfunding.Application.Features.News.CreateNews;
using Crowdfunding.Application.Features.Project.CreateProject;
using Crowdfunding.Application.Features.Project.DeleteProject;
using Crowdfunding.Application.Features.Project.GetProject;
using Crowdfunding.Application.Features.Project.GetProjects;
using Crowdfunding.Application.Features.Project.GetProjectsByUserID;
using Crowdfunding.Application.Features.Project.SearchProjects;
using Crowdfunding.Application.Features.Project.UpdateProject;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : BaseController
    {
        IMediator mediator;
        public ProjectController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateProject")]
        public async Task<IActionResult> CreateProject(CreateProjectReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteProject")]
        public async Task<IActionResult> DeleteProject(DeleteProjectReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetProject")]
        public async Task<IActionResult> GetProject(GetProjectReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetProjects")]
        public async Task<IActionResult> GetProjects(GetProjectsReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateProject")]
        public async Task<IActionResult> UpdateProject(UpdateProjectReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetProjectsByUserID")]
        public async Task<IActionResult> GetProjectsByUserID(GetProjectsByUserIDReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("SearchProjects")]
        public async Task<IActionResult> SearchProjects(SearchProjectsReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
