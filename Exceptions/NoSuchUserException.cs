namespace CodingChallenge.Exceptions
{
    public class NoSuchUserException:Exception
    {
        private readonly string message;
        public NoSuchUserException()
        {
            message = "No such user found";
        }
        public override string Message => message;
    }
}
