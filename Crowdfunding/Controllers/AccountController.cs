using Crowdfunding.Application.Features.Account;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        IMediator mediator;
        public AccountController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("login")]//登錄 輸入： "password": "string" 輸出：登錄成功與否的信息以及JWT token
        public async Task<IActionResult> Postlogin(LoginReq request)
        {
            var res = await mediator.Send(request);
            return Ok(res);
        }
    }
}
