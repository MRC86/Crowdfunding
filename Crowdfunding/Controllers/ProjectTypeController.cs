using Crowdfunding.Application.Features.ProjectType.CreateType;
using Crowdfunding.Application.Features.ProjectType.DeleteType;
using Crowdfunding.Application.Features.ProjectType.GetsTypeList;
using Crowdfunding.Application.Features.ProjectType.UpdateType;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Core;


namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectTypeController : BaseController
    {
        IMediator mediator;
        public ProjectTypeController(IMediator mediator) { 
            this.mediator = mediator;
        }
        //domain/api/projecttype/list
        //[HttpGet("list")]
        //public async Task<IActionResult> GetProjectList(GetsTypeListReq req)
        //{
        //    var response = await mediator.Send(req);
        //    return Ok(response);
        //}

        [HttpPost("CreateType")]
        public async Task<IActionResult> CreateType(CreateTypeReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteType")]
        public async Task<IActionResult> DeleteType(DeleteTypeReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetsTypeList")]
        public async Task<IActionResult> GetsTypeList(GetsTypeListReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateType")]
        public async Task<IActionResult> UpdateType(UpdateTypeReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
