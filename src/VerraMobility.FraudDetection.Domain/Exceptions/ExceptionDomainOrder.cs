namespace VerraMobility.FraudDetection.Domain.Exceptions;

public class ExceptionDomainOrder : Exception
{
    public ExceptionDomainOrder(string message) : base(message)
    { }
}