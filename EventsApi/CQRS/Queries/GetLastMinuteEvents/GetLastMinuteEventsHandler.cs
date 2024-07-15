using EventsApi.Interface;
using EventsApi.Models;
using MediatR;

namespace EventsApi.CQRS.Queries.GetLastMinuteEvents
{
    public class GetLastMinuteEventsHandler : IRequestHandler<GetLastMinuteEventsQuery,
        GetLastMinuteEventsResult>
    {
        private readonly IEventRepository _eventRepository;

        public GetLastMinuteEventsHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        
        public Task<GetLastMinuteEventsResult> Handle(GetLastMinuteEventsQuery request, 
            CancellationToken cancellationToken)
        {
            var events = _eventRepository.GetLastMinuteEvents();
            var sum = GetValueSum(events);

            var time = DateTime.UtcNow;

            var result = new GetLastMinuteEventsResult
            {
                CurrentTime = time,
                MinuteAgo = time.AddMinutes(-1),
                SumOfValues = sum
            };

            return Task.FromResult(result);
        }
        
        private int GetValueSum(ICollection<Event> events)
        {
            return events.Sum(x => x.Value);
        }

    }
}
