using VerraMobility.Wordlist.Application.Contracts;
using VerraMobility.Wordlist.Domain.Contracts;
using VerraMobility.Wordlist.Domain.ValueObjects;

namespace VerraMobility.Wordlist.Application.UseCases;

public class WordlistUseCase : IWordlistUseCase
{
    IReaderFileService _readerFileService;
    ITextRuleService _textRuleService;

    public WordlistUseCase(
        IReaderFileService readerFileService,
        ITextRuleService textRuleService)
    {
        _readerFileService = readerFileService;
        _textRuleService = textRuleService;
    }

    public async Task ExceuteWordlist()
    {
        IEnumerable<string> words = await _readerFileService.ReadFileTxtByLinesAsync();
        await _textRuleService.LoadWordsBtwOneAndFiveLettersAsync(words);
        IEnumerable<WordValid> wordsValid = await _textRuleService.GetWordsConcatenatSixLettersAsync();
        Console.WriteLine($"#############Exercise one############");
        Console.WriteLine($"Found words:{string.Join("\n", wordsValid)}");
    }
}