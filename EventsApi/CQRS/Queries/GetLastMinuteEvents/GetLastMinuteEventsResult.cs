namespace EventsApi.CQRS.Queries.GetLastMinuteEvents
{
    public class GetLastMinuteEventsResult
    {
        public DateTime CurrentTime { get; set; }
        public DateTime MinuteAgo { get; set; }
        public int SumOfValues { get; set; }
    }
}
