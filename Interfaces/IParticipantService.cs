using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IParticipantService
    {
        public Task<Participant> AddUser(Participant participant);
        public Task<Participant> GetUser(int participantId);
        public Task<List<Participant>> GetAllUser();
    }
}
