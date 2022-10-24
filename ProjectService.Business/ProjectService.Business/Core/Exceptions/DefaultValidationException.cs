namespace ProjectService.Business.Core.Exceptions;

public class DefaultValidationException : Exception
{
    public DefaultValidationException(string msg) : base(msg) { }
}