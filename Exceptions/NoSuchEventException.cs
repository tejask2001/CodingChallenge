namespace CodingChallenge.Exceptions
{
    public class NoSuchEventException:Exception
    {
        private readonly string message;
        public NoSuchEventException()
        {
            message = "No such event found";
        }
        public override string Message => message;
    }
}
