using CodingChallenge.Context;
using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Repositories
{
    public class ParticipantRepository : IRepository<int, Participant>
    {
        private readonly RequestTrackerContext _context;
        ILogger<ParticipantRepository> _logger;

        public ParticipantRepository(RequestTrackerContext context, ILogger<ParticipantRepository> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Participant> Add(Participant items)
        {
            _context.Add(items);
            _context.SaveChanges();
            _logger.LogInformation("Participant added with id " + items.ParticipantId);
            return items;
        }

        public async Task<Participant> Delete(int key)
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

        public async Task<Participant> GetAsync(int key)
        {
            var participants = await GetAsync();
            var participant = participants.FirstOrDefault(e => e.ParticipantId == key);
            if (participant != null)
            {
                return participant;

            }
            throw new NoSuchParticipantException();
        }

        public async Task<List<Participant>> GetAsync()
        {
            return _context.Participants.ToList();
        }

        public async Task<Participant> Update(Participant items)
        {
            var participant = await GetAsync(items.UserId);
            if (participant != null)
            {
                _context.Entry<Participant>(items).State = EntityState.Modified;
                _context.SaveChanges();
                _logger.LogInformation("Participant updated with id " + items.ParticipantId);
                return participant;
            }
            throw new NoSuchParticipantException();
        }
    }
}
