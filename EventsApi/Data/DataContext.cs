using EventsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace EventsApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Event> Events { get; set; } 
    }
}
