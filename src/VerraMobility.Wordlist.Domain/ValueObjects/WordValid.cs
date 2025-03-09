namespace VerraMobility.Wordlist.Domain.ValueObjects;

public record class WordValid
{
    public string WordFirst { get; set; }
    public string WordSecond { get; set; }

    public WordValid(
        string wordFirst,
        string wordSecond)
    {
        WordFirst = wordFirst;
        WordSecond = wordSecond;
    }

    public override string ToString()
    {
        return $"{WordFirst} + {WordSecond} => {WordFirst}{WordSecond}";
    }
}