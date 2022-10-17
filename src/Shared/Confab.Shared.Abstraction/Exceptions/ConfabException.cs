namespace Confab.Shared.Abstraction.Exceptions;

public abstract class ConfabException : Exception
{
    protected ConfabException(string message) : base(message)
    { 
    }
}
