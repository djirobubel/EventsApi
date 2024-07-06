using EventsApi.Interface;
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

        public Task<GetLastMinuteEventsResult> Handle(GetLastMinuteEventsQuery request, 
            CancellationToken cancellationToken)
        {
            var events = _eventRepository.GetLastMinuteEvents();
            var sum = _eventRepository.GetValueSum(events);

            var time = DateTime.Now;

            GetLastMinuteEventsResult result = new GetLastMinuteEventsResult
            {
                currentTime = time,
                minuteAgo = time.AddMinutes(-1),
                sumOfValues = sum
            };

            return Task.FromResult(result);
        }
    }
}
