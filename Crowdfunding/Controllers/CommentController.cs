using Crowdfunding.Application.Features.Comment.CreateComment;
using Crowdfunding.Application.Features.Comment.DeleteComment;
using Crowdfunding.Application.Features.Comment.GetsprojectComment;
using Crowdfunding.Application.Features.Comment.UpdateComment;
using Crowdfunding.Application.Features.ProjectType.GetsTypeList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        IMediator mediator;
        public CommentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateComment")]
        public async Task<IActionResult> CreateComment(CreateCommentReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteComment")]
        public async Task<IActionResult> DeleteComment(DeleteCommentReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetsprojectComment")]
        public async Task<IActionResult> GetsprojectComment(GetsprojectCommentReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateComment")]
        public async Task<IActionResult> UpdateComment(UpdateCommentReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
