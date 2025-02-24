using Crowdfunding.Application.Features.ProjectType.CreateType;
using Crowdfunding.Application.Features.Question.CreateQuestion;
using Crowdfunding.Application.Features.Question.DeleteQuestion;
using Crowdfunding.Application.Features.Question.GetQuestion;
using Crowdfunding.Application.Features.Question.GetQuestionByProjectID;
using Crowdfunding.Application.Features.Question.UpdateQuestion;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crowdfunding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : BaseController
    {
        IMediator mediator;
        public QuestionController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(CreateQuestionReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestion(DeleteQuestionReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetQuestion")]
        public async Task<IActionResult> GetQuestion(GetQuestionReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("GetQuestionByProjectID")]
        public async Task<IActionResult> GetQuestionByProjectID(GetQuestionByProjectIDReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
        [HttpPost("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionReq req)
        {
            var response = await mediator.Send(req);
            return Ok(response);
        }
    }
}
