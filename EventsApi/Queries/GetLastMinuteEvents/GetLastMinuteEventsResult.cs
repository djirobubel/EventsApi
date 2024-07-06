namespace EventsApi.Queries.GetLastMinuteEvents
{
    public class GetLastMinuteEventsResult
    {
        public DateTime currentTime { get; set; }
        public DateTime minuteAgo { get; set; }
        public int sumOfValues { get; set; }
    }
}
