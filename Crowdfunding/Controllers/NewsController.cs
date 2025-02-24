using Crowdfunding.Application.Features.InvestItem.CreateInvestItem;
using Crowdfunding.Application.Features.News.CreateNews;
using Crowdfunding.Application.Features.News.DeleteNews;
using Crowdfunding.Application.Features.News.GetNews;
using Crowdfunding.Application.Features.News.GetNewsByID;
using Crowdfunding.Application.Features.News.UpdateNews;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : BaseController
    {
        IMediator mediator;
        public NewsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateNews")]
        public async Task<IActionResult> CreateNews(CreateNewsReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteNews")]
        public async Task<IActionResult> DeleteNews(DeleteNewsReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetNews")]
        public async Task<IActionResult> GetNews(GetNewsReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetNewsByID")]
        public async Task<IActionResult> GetNewsByID(GetNewsByIDReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateNews")]
        public async Task<IActionResult> UpdateNews(UpdateNewsReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
