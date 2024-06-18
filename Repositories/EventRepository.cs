using CodingChallenge.Context;
using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class EventRepository : IRepository<int, Event>
    {
        private readonly RequestTrackerContext _context;
        ILogger<EventRepository> _logger;

        public EventRepository(RequestTrackerContext context, ILogger<EventRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Event> Add(Event items)
        {
            _context.Add(items);
            _context.SaveChanges();
            _logger.LogInformation("Event added with id " + items.EventId);
            return items;
        }

        public async Task<Event> Delete(int key)
        {
            var events = await GetAsync(key);
            if (events != null)
            {
                _context.Remove(events);
                _context.SaveChanges();
                _logger.LogInformation("Event deleted with id " + key);
                return events;
            }
            throw new NoSuchEventException();
        }

        public async Task<Event> GetAsync(int key)
        {
            var events = await GetAsync();
            var _events = events.FirstOrDefault(e => e.EventId == key);
            if (_events != null)
            {
                return _events;
            }

            throw new NoSuchEventException();
        }

        public async Task<List<Event>> GetAsync()
        {
            return _context.Events.ToList();
        }

        public async Task<Event> Update(Event items)
        {
            var events = await GetAsync(items.EventId);
            if (events != null)
            {
                _context.Entry<Event>(items).State = EntityState.Modified;
                _context.SaveChanges();
                _logger.LogInformation("User updated with id " + items.EventId);
                return events;
            }
            throw new NoSuchEventException();
        }
    }
}
