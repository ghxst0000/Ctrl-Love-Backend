namespace CtrlLove.Exceptions;

public class IdNotFoundException : Exception
{

    public IdNotFoundException(string? message) : base(message)
    {
    }
}