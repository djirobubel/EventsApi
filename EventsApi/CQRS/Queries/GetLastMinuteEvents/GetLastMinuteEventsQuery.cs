using MediatR;

namespace EventsApi.CQRS.Queries.GetLastMinuteEvents
{
    public class GetLastMinuteEventsQuery : IRequest<GetLastMinuteEventsResult>
    {
    }
}
