namespace Prueba1.Domain.ValueObjects;

public class WordValid
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