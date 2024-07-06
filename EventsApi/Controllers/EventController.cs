using EventsApi.Commands.CreateEvent;
using EventsApi.Queries.GetLastMinuteEvents;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetLastMinuteEvents()
        {
            var query = new GetLastMinuteEventsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
