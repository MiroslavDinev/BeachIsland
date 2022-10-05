namespace BeachIsland.Server.Infrastructure.Exceptions
{
    public class EmailNotSentException : Exception
    {
        public EmailNotSentException(string message) 
            : base(message)
        {

        }
    }
}
