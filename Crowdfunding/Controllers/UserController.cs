using Crowdfunding.Application.Features.SuperComment.CreateSuperComment;
using Crowdfunding.Application.Features.User.CreateUser;
using Crowdfunding.Application.Features.User.DeleteUser;
using Crowdfunding.Application.Features.User.GetUser;
using Crowdfunding.Application.Features.User.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        IMediator mediator;
        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser(DeleteUserReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetUser")]
        public async Task<IActionResult> GetUser(GetUserReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
