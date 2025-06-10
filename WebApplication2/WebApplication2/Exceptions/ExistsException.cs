namespace WebApplication2.Exceptions;

public class ExistsException: Exception
{
    public ExistsException()
    {
        
    }
    public ExistsException(string? message) : base(message)
    {
        
    }
    public ExistsException(string? message, Exception? innerException) : base(message, innerException)
    {
        
    }
}
