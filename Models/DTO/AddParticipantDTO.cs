namespace CodingChallenge.Models.DTO
{
    public class AddParticipantDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool isEventOrginizer { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }
}
