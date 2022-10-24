namespace ProjectService.Business.Core.Exceptions;

public class QuotaExceededException : Exception
{
    public int Code { get; set; }
    
    public QuotaExceededException(string message = "") : base(message)
    {
    }
    
    public QuotaExceededException(int code)
    {
        Code = code;;
    }
}