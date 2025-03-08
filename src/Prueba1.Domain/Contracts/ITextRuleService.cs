using Prueba1.Domain.ValueObjects;

namespace Prueba1.Domain.Contracts;

public interface ITextRuleService : ITransientDomain
{
    IEnumerable<WordSummary> GetWordsBtwZeroAndSixLetters(IEnumerable<string> words);
    IEnumerable<WordValid> GetWordsConcatenatSixLetters(IEnumerable<WordSummary> wordsSummary);
}