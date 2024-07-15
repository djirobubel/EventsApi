using EventsApi.Data;
using EventsApi.Interface;
using EventsApi.Models;

namespace EventsApi.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly DataContext _context;

        public EventRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateEvent(Event eventModel)
        {
            _context.Events.Add(eventModel);
            return Save();
        }

        public ICollection<Event> GetLastMinuteEvents()
        {
           var minuteAgo = DateTime.UtcNow.AddMinutes(-1);
           return _context.Events.Where(t => t.TimeOfCreation >= minuteAgo).ToList();
        }

        private bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
