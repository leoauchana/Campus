namespace Application.Exceptions;

public class NullException : ApplicationException
{
    public NullException(string msg) : base(msg)
    {
    }
}