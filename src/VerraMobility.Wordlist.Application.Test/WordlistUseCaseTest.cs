using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using VerraMobility.Infraestructure.ReaderFiles;
using VerraMobility.Wordlist.Application.Contracts;
using VerraMobility.Wordlist.Application.UseCases;
using VerraMobility.Wordlist.Domain.Contracts;
using VerraMobility.Wordlist.Domain.Service;
using VerraMobility.Wordlist.Domain.ValueObjects;

namespace Prueba1.Application.Test
{
    public class WordListUseCaseTest
    {
        private readonly ITextRuleService _textRuleService;

        public WordListUseCaseTest()
        {
            _textRuleService = new TextRuleService();
        }

        [Fact]
        public async Task ShouldNotGetResultRequiredConcatTwoWordsSumCharactersEqualSix()
        {

            // Arrange
            List<string> wordlists =
            [
                "aa",
                "bb",
                "cc"
            ];

            Mock<IReaderFileService> mock = new();
            mock.Setup(reader => reader.ReadFileTxtByLinesAsync()).ReturnsAsync(wordlists);


            IWordlistUseCase sut = new WordlistUseCase(
                mock.Object,
                _textRuleService
            );

            //Act
            await sut.ExceuteWordlist();

            ////Assert
            IEnumerable<WordValid> wordsValid = await _textRuleService.GetWordsConcatenatSixLettersAsync();

            wordsValid.Should().HaveCount(0);
        }

        [Fact]
        public async Task ShouldGetOneResultRequiredConcatWordsSumCharactersThreePlusThreeEqualSix()
        {

            // Arrange
            List<string> wordlists =
            [
                "aaa",
                "bb",
                "ccc"
            ];

            Mock<IReaderFileService> mock = new();
            mock.Setup(reader => reader.ReadFileTxtByLinesAsync()).ReturnsAsync(wordlists);


            IWordlistUseCase sut = new WordlistUseCase(
                mock.Object,
                _textRuleService
            );

            //Act
            await sut.ExceuteWordlist();

            ////Assert
            IEnumerable<WordValid> wordsValid = await _textRuleService.GetWordsConcatenatSixLettersAsync();

            wordsValid.Should().HaveCount(1);
        }

        [Fact]
        public async Task ShouldGetOneResultRequiredConcatWordsSumCharactersOnePlusFiveEqualSix()
        {

            // Arrange
            List<string> wordlists =
            [
                "a",
                "bb",
                "ccccc"
            ];

            Mock<IReaderFileService> mock = new();
            mock.Setup(reader => reader.ReadFileTxtByLinesAsync()).ReturnsAsync(wordlists);


            IWordlistUseCase sut = new WordlistUseCase(
                mock.Object,
                _textRuleService
            );

            //Act
            await sut.ExceuteWordlist();

            ////Assert
            IEnumerable<WordValid> wordsValid = await _textRuleService.GetWordsConcatenatSixLettersAsync();

            wordsValid.Should().HaveCount(1);
        }

        [Fact]
        public async Task ShouldGetOneResultRequiredConcatWordsSumCharactersFivePlusOneEqualSix()
        {

            // Arrange
            List<string> wordlists =
            [
                "aaaaa",
                "bb",
                "c"
            ];

            Mock<IReaderFileService> mock = new();
            mock.Setup(reader => reader.ReadFileTxtByLinesAsync()).ReturnsAsync(wordlists);


            IWordlistUseCase sut = new WordlistUseCase(
                mock.Object,
                _textRuleService
            );

            //Act
            await sut.ExceuteWordlist();

            ////Assert
            IEnumerable<WordValid> wordsValid = await _textRuleService.GetWordsConcatenatSixLettersAsync();

            wordsValid.Should().HaveCount(1);
        }

        [Fact]
        public async Task ShouldGetThreeResultRequiredConcatWordsSumCharactersEqualSix()
        {

            // Arrange
            List<string> wordlists =
            [
                "aaaaa",
                "bb",
                "c",
                "dddd",
                "e",

            ];

            Mock<IReaderFileService> mock = new();
            mock.Setup(reader => reader.ReadFileTxtByLinesAsync()).ReturnsAsync(wordlists);


            IWordlistUseCase sut = new WordlistUseCase(
                mock.Object,
                _textRuleService
            );

            //Act
            await sut.ExceuteWordlist();

            ////Assert
            IEnumerable<WordValid> wordsValid = await _textRuleService.GetWordsConcatenatSixLettersAsync();

            wordsValid.Should().HaveCount(3);
        }
    }
}