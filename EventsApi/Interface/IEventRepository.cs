using EventsApi.Models;

namespace EventsApi.Interface
{
    public interface IEventRepository
    {
        ICollection<Event> GetLastMinuteEvents();
        bool CreateEvent(Event eventModel);
        int GetValueSum(ICollection<Event> events);
        bool Save();
    }
}
