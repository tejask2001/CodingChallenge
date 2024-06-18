using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodingChallenge.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }
        public string Name { get; set; }
        public int Age {  get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User? User { get; set; }
    }
}
