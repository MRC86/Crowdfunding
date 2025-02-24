using Crowdfunding.Application.Features.Comment.CreateComment;
using Crowdfunding.Application.Features.Favorite.CreateFavorite;
using Crowdfunding.Application.Features.Favorite.DeleteFavorite;
using Crowdfunding.Application.Features.Favorite.GetFavorite;
using Crowdfunding.Application.Features.Favorite.GetFavoriteByUserID;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoriteController : BaseController
    {
        IMediator mediator;
        public FavoriteController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateFavorite")]
        public async Task<IActionResult> CreateFavorite(CreateFavoriteReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteFavorite")]
        public async Task<IActionResult> DeleteFavorite(DeleteFavoriteReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetFavorite")]
        public async Task<IActionResult> GetFavorite(GetFavoriteReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetFavoriteByUserID")]
        public async Task<IActionResult> GetFavoriteByUserID(GetFavoriteByUserIDReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateFavorite")]
        public async Task<IActionResult> UpdateFavorite(GetFavoriteByUserIDReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
