using MediatR;
using Microsoft.AspNetCore.Mvc;
using StoryCollaborationApi.Commands;

namespace StoryCollaborationApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("vote")]
        public async Task<IActionResult> Vote([FromBody] VoteContributionCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result)
            {
                return NotFound("Contribution not found");
            }
            return Ok();
        }
    }
}