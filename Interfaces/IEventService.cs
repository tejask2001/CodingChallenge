using CodingChallenge.Models.DTO;
using CodingChallenge.Models;

namespace CodingChallenge.Interfaces
{
    public interface IEventService
    {
        public Task<Event> AddEvent(Event user);
        public Task<Event> RemoveEvent(int id);
        public Task<Event> GetEvent(int userId);
        public Task<List<Event>> GetAllEvent();
        public Task<Event> UpdateEvent(Event user);
    }
}
