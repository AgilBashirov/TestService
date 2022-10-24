namespace ProjectService.Business.Core.Exceptions;

public class UnauthorizedException : Exception
{
    public int Code { get; set; }
        
    public UnauthorizedException(string name, object key)
        : base($"User \"{name}\" not authorized.")
    {
    }

    public UnauthorizedException(string message = "") : base(message)
    {
    }
        
    public UnauthorizedException(int code)
    {
        Code = code;
    }
}
