using EventsApi.CQRS.Commands.CreateEvent;
using EventsApi.CQRS.Queries.GetLastMinuteEvents;
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
        [ProducesResponseType(typeof(GetLastMinuteEventsResult),200)]
        public async Task<ActionResult> GetLastMinuteEvents()
        {
            var result = await _mediator.Send( new GetLastMinuteEventsQuery());
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateEventResult),204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> CreateEvent([FromBody] CreateEventCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
