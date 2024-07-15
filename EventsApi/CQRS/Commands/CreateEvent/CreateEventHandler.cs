using EventsApi.Interface;
using EventsApi.Models;
using MediatR;

namespace EventsApi.CQRS.Commands.CreateEvent
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
            var createdEvent = new Event
            {
                Name = request.Name,
                Value = request.Value,
                TimeOfCreation = DateTime.UtcNow,
            };

           var saveResult =  _eventRepository.CreateEvent(createdEvent);
           
           var result = new CreateEventResult { Message = saveResult ? "Successfully created." : "Proebano" }; 
           return Task.FromResult(result);
        }
    }
}
