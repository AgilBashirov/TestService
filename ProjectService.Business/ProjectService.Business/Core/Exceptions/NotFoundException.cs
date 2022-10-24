namespace ProjectService.Business.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string name, object key)
        : base($"Entity \"{name}\" Id ({key}) not found.") { }
}