using CodingChallenge.Interfaces;
using CodingChallenge.Models;

namespace CodingChallenge.Services
{
    public class EventParticipantService : IEventParticipant
    {
        private readonly IRepository<int, EventParticipant> _participantRepository;
        public EventParticipantService(IRepository<int, EventParticipant> participantRepository)
        {
            _participantRepository = participantRepository;
        }
        public async Task<EventParticipant> AddEventParticipant(int eventId, int participantId)
        {
            EventParticipant participant = new EventParticipant();
            participant.EventId = eventId;
            participant.ParticipantId = participantId;

            return await _participantRepository.Add(participant);
             
        }
    }
}
