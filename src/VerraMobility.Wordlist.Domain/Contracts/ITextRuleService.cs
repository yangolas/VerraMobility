using VerraMobility.Wordlist.Domain.ValueObjects;

namespace VerraMobility.Wordlist.Domain.Contracts;

public interface ITextRuleService : ITransientDomainWordlist
{
    IEnumerable<WordSummary> GetWordsBtwZeroAndSixLetters(IEnumerable<string> words);
    IEnumerable<WordValid> GetWordsConcatenatSixLetters(IEnumerable<WordSummary> wordsSummary);
}