using EventsApi.Interface;
using EventsApi.Models;
using MediatR;

namespace EventsApi.Commands.CreateEvent
{
    public class CreateEventHandler : IRequestHandler<CreateEventCommand, CreateEventResult>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public Task<CreateEventResult> Handle(CreateEventCommand request, 
            CancellationToken cancellationToken)
        {
            Event createdEvent = new Event
            {
                Name = request.Name,
                Value = request.Value,
                TimeOfCreation = DateTime.UtcNow,
            };

            _eventRepository.CreateEvent(createdEvent);

            CreateEventResult result = new CreateEventResult { Message = "Successfully created." };
            return Task.FromResult(result);
        }
    }
}
