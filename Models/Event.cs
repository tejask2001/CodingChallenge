using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Models
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateOfEvent { get; set; }
        public string Location { get; set; }
        public int MaxAttendees { get; set; }
        public Double RegistrationFees { get; set; }

    }
}
