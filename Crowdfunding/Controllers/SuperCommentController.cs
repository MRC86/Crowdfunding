using Crowdfunding.Application.Features.Question.CreateQuestion;
using Crowdfunding.Application.Features.SuperComment.CreateSuperComment;
using Crowdfunding.Application.Features.SuperComment.DeleteSuperComment;
using Crowdfunding.Application.Features.SuperComment.GetSuperComment;
using Crowdfunding.Application.Features.SuperComment.GetSuperCommentByProjectID;
using Crowdfunding.Application.Features.SuperComment.UpdateSuperComment;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperCommentController : BaseController
    {
        IMediator mediator;
        public SuperCommentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateSuperComment")]
        public async Task<IActionResult> CreateSuperComment(CreateSuperCommentReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteSuperComment")]
        public async Task<IActionResult> DeleteSuperComment(DeleteSuperCommentReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetSuperComment")]
        public async Task<IActionResult> GetSuperComment(GetSuperCommentReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetSuperCommentByProjectID")]
        public async Task<IActionResult> GetSuperCommentByProjectID(GetSuperCommentByProjectIDReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateSuperComment")]
        public async Task<IActionResult> UpdateSuperComment(UpdateSuperCommentReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
