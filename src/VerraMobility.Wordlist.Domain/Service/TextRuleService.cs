using VerraMobility.Wordlist.Domain.Contracts;
using VerraMobility.Wordlist.Domain.ValueObjects;

namespace VerraMobility.Wordlist.Domain.Service;

public class TextRuleService : ITextRuleService
{
    private const string InitializeMessage = $"Ey, developer, you must initalize {nameof(TextRuleService)} correctly";
    private const int _minimumWordLetters = 0;
    private const int _maximumWordLetters = 6;
    private IEnumerable<string>? _wordsOneToFive;
    public async Task LoadWordsBtwOneAndFiveLettersAsync(IEnumerable<string> words)
    {
        _wordsOneToFive = await Task.Run(() => words
            .Where(word => word.Length > _minimumWordLetters && word.Length < _maximumWordLetters)
            .ToList()
        );
    }

    public async Task<IEnumerable<WordValid>> GetWordsConcatenatSixLettersAsync()
    {
        if (_wordsOneToFive is null)
            throw new ArgumentNullException(InitializeMessage);

        return await Task.Run(() =>
        {
            List<WordValid> wordsValid = new();
            string[] wordsOneToFive = _wordsOneToFive.ToArray();
            int wordCount = wordsOneToFive.Length;

            for (int index = 0; index < wordCount - 1; index++)
            {
                for (int subIndex = index + 1; subIndex < wordCount; subIndex++)
                {
                    if (wordsOneToFive[index].Length + wordsOneToFive[subIndex].Length == _maximumWordLetters)
                    {
                        wordsValid.Add(new WordValid(wordsOneToFive[index], wordsOneToFive[subIndex]));
                    }
                }
            }

            return wordsValid;
        });
    }

}