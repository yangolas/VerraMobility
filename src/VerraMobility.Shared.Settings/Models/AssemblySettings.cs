namespace VerraMobility.Shared.Settings.Models;

public class AssemblySettings
{
    public string AssemblyReaderFiles { get; set; } = null!;
    public string AssemblyApplicationWordlist { get; set; } = null!;
    public string AssemblyApplicationFraudDetection { get; set; } = null!;
    public string AssemblyDomainWordlist { get; set; } = null!;
    public string AssemblyDomainFraudDetection { get; set; } = null!;
    public string AssemblyRepository { get; set; } = null!;
}