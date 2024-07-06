using MediatR;

namespace EventsApi.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<CreateEventResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
}
