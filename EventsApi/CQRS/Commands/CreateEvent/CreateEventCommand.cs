using MediatR;

namespace EventsApi.CQRS.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<CreateEventResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
