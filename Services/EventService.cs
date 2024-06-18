using CodingChallenge.Exceptions;
using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Models.DTO;
using CodingChallenge.Repositories;

namespace CodingChallenge.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<int, Event> _eventRepository;

        public EventService(IRepository<int, Event> eventRepository)
        {
            _eventRepository= eventRepository;
        }
        public async Task<Event> AddEvent(Event user)
        {
            return await _eventRepository.Add(user);
        }

        public async Task<List<Event>> GetAllEvent()
        {
            return await _eventRepository.GetAsync();
        }

        public async Task<Event> GetEvent(int userId)
        {
            var user = await _eventRepository.GetAsync(userId);
            if (user != null)
            {
                return user;
            }
            throw new NoSuchEventException();
        }

        public async Task<Event> RemoveEvent(int id)
        {
            var users = await _eventRepository.GetAsync(id);
            if (users != null)
            {
                _eventRepository.Delete(id);
                return users;
            }
            throw new NoSuchEventException();
        }

        public async Task<Event> UpdateEvent(Event user)
        {
            var users = await _eventRepository.GetAsync(user.EventId);
            if (users != null)
            {
                users.Title = user.Title;
                users.Location = user.Location;
                users.MaxAttendees = user.MaxAttendees;
                users.RegistrationFees = user.RegistrationFees;
                users.DateOfEvent = user.DateOfEvent;
                users.Description = user.Description;
                return await _eventRepository.Update(users);
            }
            throw new NoSuchUserException();
        }
    }
}
