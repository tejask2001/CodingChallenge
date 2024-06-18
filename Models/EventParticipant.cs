using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallenge.Models
{
    public class EventParticipant
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public Event? Event { get; set; }
        public int ParticipantId { get; set; }
        [ForeignKey("ParticipantId")]
        public Participant? Participant { get; set;}
    }
}
