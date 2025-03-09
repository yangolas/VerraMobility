namespace VerraMobility.FraudDetection.Application.Contracts;

public interface IFraudDetectionUseCase : ITransientApplicationFraudDetection
{
    void ExecuteFraudDetection(IEnumerable<string> inlineOrders);
}