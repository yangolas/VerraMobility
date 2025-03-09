using VerraMobility.Wordlist.Domain.ValueObjects;

namespace VerraMobility.Wordlist.Domain.Contracts;

public interface ITextRuleService : ITransientDomainWordlist
{
    Task LoadWordsBtwOneAndFiveLettersAsync(IEnumerable<string> words);

    Task<IEnumerable<WordValid>> GetWordsConcatenatSixLettersAsync();
}