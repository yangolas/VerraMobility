namespace VerraMobility.FraudDetection.Application.Contracts;

public interface IFraudDetectionUseCase : ITransientApplicationFraudDetection
{
    Task ExecuteFraudDetectionAsync(IEnumerable<string> inlineOrders);
}