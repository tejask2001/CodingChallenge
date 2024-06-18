using CodingChallenge.Context;
using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class EventParticipantRepository : IRepository<int, EventParticipant>
    {
        private readonly RequestTrackerContext _context;
        ILogger<EventParticipantRepository> _logger;

        public EventParticipantRepository(RequestTrackerContext context, ILogger<EventParticipantRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<EventParticipant> Add(EventParticipant items)
        {
            _context.Add(items);
            _context.SaveChanges();
            _logger.LogInformation("Participant added with id " + items.ParticipantId);
            return items;
        }

        public async Task<EventParticipant> Delete(int key)
        {
            var participant = await GetAsync(key);
            if (participant != null)
            {
                _context.Remove(participant);
                _context.SaveChanges();
                _logger.LogInformation("participant deleted with id " + key);
                return participant;
            }
            throw new NoSuchParticipantException();
        }

        public async Task<EventParticipant> GetAsync(int key)
        {
            var participants = await GetAsync();
            var participant = participants.FirstOrDefault(e => e.Id == key);
            if (participant != null)
            {
                return participant;

            }
            throw new NoSuchParticipantException();
        }

        public async Task<List<EventParticipant>> GetAsync()
        {
            return _context.EventParticipants.ToList();
        }

        public async Task<EventParticipant> Update(EventParticipant items)
        {
            var participant = await GetAsync(items.Id);
            if (participant != null)
            {
                _context.Entry<EventParticipant>(items).State = EntityState.Modified;
                _context.SaveChanges();
                _logger.LogInformation("Participant updated with id " + items.ParticipantId);
                return participant;
            }
            throw new NoSuchParticipantException();
        }
    }
}
