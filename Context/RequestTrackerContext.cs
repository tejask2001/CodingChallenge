using CodingChallenge.Models;
using Microsoft.EntityFrameworkCore;

namespace CodingChallenge.Context
{
    public class RequestTrackerContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<EventParticipant> EventParticipants { get; set; }

        public RequestTrackerContext(DbContextOptions options) : base(options)
        {

        }
    }
}
