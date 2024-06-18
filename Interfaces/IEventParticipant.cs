using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IEventParticipant
    {
        public Task<EventParticipant> AddEventParticipant(int eventId,int participantId);
    }
}
