using Microsoft.Extensions.Logging;
using Prueba1.Application.Contracts;
//using Prueba1.Application.Mappers;
using Prueba1.Domain.Contracts;
//using Prueba1.Domain.Entities;
//using Prueba1.Domain.Service;
using Prueba1.Domain.ValueObjects;
//using Prueba1.ReaderTxt;
//using Prueba1.Repository.Contracts;
//using Prueba1.Repository.Models.EntitiesRepository;
//using System.Linq;
//using System.Text.Json;

namespace Prueba1.Application.Services;

public class UseCase : IUseCase
{
    IReaderTxt _readerTxt;
    ITextRuleService _textRuleService;
    //IResultadoRepository _resultadoRepository;
    //IUnitOfWorkRepository _unitOfWorkRepository;
    ILogger<UseCase> _logger;
    
    public UseCase(
        ILogger<UseCase> logger,
        IReaderTxt readerTxt,
        ITextRuleService textRuleService)
        //IUnitOfWorkRepository unitOfWorkRepository,
        //IResultadoRepository resultadoRepository,
    {
        _logger = logger;
        _readerTxt = readerTxt;
        _textRuleService = textRuleService;
        //_resultadoRepository = resultadoRepository;
        //_unitOfWorkRepository = unitOfWorkRepository;
    }

    public async Task TextProcess()
    {
        IEnumerable<string> words = await _readerTxt.ReadFileTxtByLinesAsync();
        IEnumerable<WordSummary> wordsSummary = _textRuleService.GetWordsBtwZeroAndSixLetters(words);
        IEnumerable<WordValid> wordsValid = _textRuleService.GetWordsConcatenatSixLetters(wordsSummary);
        //Entity entity = Mapper_Prueba1Dto_Domain.MapToDomain(prueba1Dto);
        //Resultado resultado = Mapper_ResultadoRepository_Domain.MapToRepository(entity);
        //_resultadoRepository.CreateResultado(resultado);
        //await _unitOfWorkRepository.SaveChangesAsync();
        ////Esto lo hago ! porque se con seguridad de que existe en bd la entity de repositorio que he insertado dos lineas arriba
        //Resultado responseDb = (await _resultadoRepository.GetByIdsync(resultado.Id))!;

        _logger.LogInformation($"Found words:{string.Join("\n", wordsValid)}");

    }
}