namespace VerraMobility.Wordlist.Domain.ValueObjects;

public record class WordSummary
{
    public int Length { get; set; }
    public string Word { get; set; } = string.Empty;
}