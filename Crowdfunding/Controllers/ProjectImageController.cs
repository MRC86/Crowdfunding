using Crowdfunding.Application.Features.Project.CreateProject;
using Crowdfunding.Application.Features.ProjectImage.CreateProjectImage;
using Crowdfunding.Application.Features.ProjectImage.DeleteProjectImage;
using Crowdfunding.Application.Features.ProjectImage.GetProjectImage;
using Crowdfunding.Application.Features.ProjectImage.GetProjectImageByProjectID;
using Crowdfunding.Application.Features.ProjectImage.UpdateProjectImage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectImageController : BaseController
    {
        IMediator mediator;
        public ProjectImageController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateProjectImage")]
        public async Task<IActionResult> CreateProjectImage(CreateProjectImageReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteProjectImage")]
        public async Task<IActionResult> DeleteProjectImage(DeleteProjectImageReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetProjectImage")]
        public async Task<IActionResult> GetProjectImage(GetProjectImageReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetProjectImageByProjectID")]
        public async Task<IActionResult> GetProjectImageByProjectID(GetProjectImageByProjectIDReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateProjectImage")]
        public async Task<IActionResult> UpdateProjectImage(UpdateProjectImageReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
