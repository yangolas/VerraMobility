using Microsoft.Extensions.Logging;
using VerraMobility.Wordlist.Application.Contracts;
using VerraMobility.Wordlist.Domain.Contracts;
using VerraMobility.Wordlist.Domain.ValueObjects;

//using System.Linq;

namespace VerraMobility.Wordlist.Application.UseCases;

public class WordlistUseCase : IWordlistUseCase
{
    ILogger<WordlistUseCase> _logger;
    IReaderFileService _readerFileService;
    ITextRuleService _textRuleService;
    //IResultadoRepository _resultadoRepository;
    //IUnitOfWorkRepository _unitOfWorkRepository;

    public WordlistUseCase(
        ILogger<WordlistUseCase> logger,
        IReaderFileService readerFileService,
        ITextRuleService textRuleService)
    //IUnitOfWorkRepository unitOfWorkRepository,
    //IResultadoRepository resultadoRepository,
    {
        _logger = logger;
        _readerFileService = readerFileService;
        _textRuleService = textRuleService;
        //_resultadoRepository = resultadoRepository;
        //_unitOfWorkRepository = unitOfWorkRepository;
    }

    public async Task ExceuteWordlist()
    {
        IEnumerable<string> words = await _readerFileService.ReadFileTxtByLinesAsync();
        IEnumerable<WordSummary> wordsSummary = _textRuleService.GetWordsBtwZeroAndSixLetters(words);
        IEnumerable<WordValid> wordsValid = _textRuleService.GetWordsConcatenatSixLetters(wordsSummary);
        //Entity entity = Mapper_Prueba1Dto_Domain.MapToDomain(prueba1Dto);
        //Resultado resultado = Mapper_ResultadoRepository_Domain.MapToRepository(entity);
        //_resultadoRepository.CreateResultado(resultado);
        //await _unitOfWorkRepository.SaveChangesAsync();
        ////Esto lo hago ! porque se con seguridad de que existe en bd la entity de repositorio que he insertado dos lineas arriba
        //Resultado responseDb = (await _resultadoRepository.GetByIdsync(resultado.Id))!;
        Console.WriteLine($"#############Exercise one############");
        Console.WriteLine($"Found words:{string.Join("\n", wordsValid)}");
    }
}