using Crowdfunding.Application.Features.Favorite.CreateFavorite;
using Crowdfunding.Application.Features.InvestItem.CreateInvestItem;
using Crowdfunding.Application.Features.InvestItem.GetInvestItem;
using Crowdfunding.Application.Features.InvestItem.GetInvestItemUserID;
using Crowdfunding.Application.Features.InvestItem.RemoveInvestItem;
using Crowdfunding.Application.Features.InvestItem.ResumeInvestItem;
using Crowdfunding.Application.Features.InvestItem.UpdateInvestItem;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestItemController : BaseController
    {
        IMediator mediator;
        public InvestItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateInvestItem")]
        public async Task<IActionResult> CreateInvestItem(CreateInvestItemReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetInvestItem")]
        public async Task<IActionResult> GetInvestItem(GetInvestItemReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetInvestItemUserID")]
        public async Task<IActionResult> GetInvestItemUserID(GetInvestItemUserIDReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("RemoveInvestItem")]
        public async Task<IActionResult> RemoveInvestItem(RemoveInvestItemReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("ResumeInvestItem")]
        public async Task<IActionResult> ResumeInvestItem(ResumeInvestItemReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateInvestItem")]
        public async Task<IActionResult> UpdateInvestItem(UpdateInvestItemReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
