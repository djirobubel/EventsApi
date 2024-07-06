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
            DateTime minuteAgo = DateTime.Now.AddMinutes(-1);

            return _context.Events.Where(t => t.Time >= minuteAgo).ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public int GetValueSum(ICollection<Event> events)
        {
            var sum = 0;

            foreach (var e in events)
            {
                sum += e.Value;
            }

            return sum;
        }
    }
}
