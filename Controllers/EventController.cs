using CodingChallenge.Interfaces;
using CodingChallenge.Models;
using CodingChallenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IEventParticipant _eventParticipant;
        private readonly ILogger<EventController> _logger;
        public EventController(IEventService eventService, ILogger<EventController> logger, IEventParticipant eventParticipant)
        {
            _eventService = eventService;
            _logger = logger;
            _eventParticipant = eventParticipant;
        }

        [HttpGet]
        public async Task<ActionResult<List<Event>>> GetAllEvent()
        {
            try
            {
                var events = await _eventService.GetAllEvent();
                return events;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetEventById")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            try
            {
                var events = await _eventService.GetEvent(id);
                return events;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddEvent")]
        public async Task<ActionResult<Event>> AddUser(Event events)
        {
            try
            {
                return await _eventService.AddEvent(events);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        [Route("AddEventParticipant")]
        public async Task<ActionResult<EventParticipant>> AddEventParticipant(EventParticipant eventParticipant)
        {
            try
            {
                return await _eventParticipant.AddEventParticipant(eventParticipant.EventId, eventParticipant.ParticipantId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Event>> UpdateEvent(Event events)
        {
            try
            {
                return await _eventService.UpdateEvent(events);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }

        }

        [HttpDelete]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
            try
            {
                var events = await _eventService.RemoveEvent(id);
                return events;
            }
            catch (Exception ex)
            {
                _logger.LogInformation(ex.Message);
                return NotFound(ex.Message);
            }
        }

    }
}
