using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Repositories;

namespace CodingChallenge.Services
{
    public class ParticipantService : IParticipantService
    {
        private readonly IRepository<int, Participant> _participantRepository;
        public ParticipantService(IRepository<int, Participant> participantRepository)
        {
            _participantRepository = participantRepository;
        }
        public async Task<Participant> AddUser(Participant participant)
        {
            return await _participantRepository.Add(participant);
        }

        public async Task<List<Participant>> GetAllUser()
        {
            return await _participantRepository.GetAsync();
        }

        public async Task<Participant> GetUser(int participantId)
        {
            var user = await _participantRepository.GetAsync(participantId);
            if (user != null)
            {
                return user;
            }
            throw new NoSuchParticipantException();
        }
    }
}
