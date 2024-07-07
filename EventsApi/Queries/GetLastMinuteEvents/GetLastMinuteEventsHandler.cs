using EventsApi.Interface;
using EventsApi.Models;
using MediatR;

namespace EventsApi.Queries.GetLastMinuteEvents
{
    public class GetLastMinuteEventsHandler : IRequestHandler<GetLastMinuteEventsQuery,
        GetLastMinuteEventsResult>
    {
        private readonly IEventRepository _eventRepository;

        public GetLastMinuteEventsHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        private int GetValueSum(ICollection<Event> events)
        {
            var sum = 0;

            foreach (var e in events)
            {
                sum += e.Value;
            }

            return sum;
        }

        public Task<GetLastMinuteEventsResult> Handle(GetLastMinuteEventsQuery request, 
            CancellationToken cancellationToken)
        {
            var events = _eventRepository.GetLastMinuteEvents();
            var sum = GetValueSum(events);

            var time = DateTime.UtcNow;

            GetLastMinuteEventsResult result = new GetLastMinuteEventsResult
            {
                CurrentTime = time,
                MinuteAgo = time.AddMinutes(-1),
                SumOfValues = sum
            };

            return Task.FromResult(result);
        }
    }
}
