﻿namespace VerraMobility.Wordlist.Domain.ValueObjects;

public record class WordValid
{
    public string WordFirst { get; init; }
    public string WordSecond { get; init; }

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