namespace CodingChallenge.Exceptions
{
    public class NoSuchParticipantException:Exception
    {
        private readonly string message;
        public NoSuchParticipantException()
        {
            message = "No such participant found";
        }
        public override string Message => message;
    }
}
