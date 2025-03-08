using Prueba1.Domain.Contracts;
using Prueba1.Domain.ValueObjects;
using System.Collections.ObjectModel;

namespace Prueba1.Domain.Service;

public class TextRuleService : ITextRuleService
{
    public IEnumerable<WordSummary> GetWordsBtwZeroAndSixLetters(IEnumerable<string> words) 
    {
        return words
            .Where(word => word.Length > 0 && word.Length < 6)
            .Select(word => new WordSummary() 
                { 
                    Length = word.Length,
                    Word = word,
                }
            );
    }

    public IEnumerable<WordValid> GetWordsConcatenatSixLetters(IEnumerable<WordSummary> wordsSummary)
    {
        List<WordValid> wordsValid = new();
        WordSummary[] wordSummaries = wordsSummary.ToArray();
        int wordCount = wordSummaries.Length;

        for (int index = 0; index < wordCount - 1; index++)
        {
            for (int subIndex = index + 1; subIndex < wordCount; subIndex++)
            {
                if (wordSummaries[index].Length + wordSummaries[subIndex].Length == 6)
                {
                    wordsValid.Add(new (wordSummaries[index].Word, wordSummaries[subIndex].Word));
                }
            }
        }

        return wordsValid;
    }
}