using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Prueba1.Repository.Contracts;
using Prueba1.Repository.Models.Context;
using Prueba1.Repository.Models.EntitiesRepository;
using Prueba1.Repository.Repositories;
using Prueba1.Repository.Services;
using Prueba2.Application.Models;
using Prueba2.Application.UseCases;

namespace Prueba2.Application.Test;

public class Prueba2UseCaseTest
{
    private readonly string ParametroString = "this is an example";
    private UseCase2 _sut = null!;

    [Fact]
    public async Task ShouldCreateAPrueba2RequiredACorrectPrueba2Dto()
    {
        //Arrange
        Prueba2Dto request = new() 
        { 
            ParametroInt = 1,
            ParametroString = "this is an example",
        };


        Mock<ILogger<UseCase2>> mockLogger = new ();
        mockLogger
            .Setup(log => log.Log(
                It.IsAny<LogLevel>(), 
                It.IsAny<EventId>(), 
                It.IsAny<object>(), 
                It.IsAny<Exception>(), 
                It.IsAny<Func<object, Exception, string>>()!)
            )
            .Verifiable();


        DbContextOptions<SqlServerContext> options = new DbContextOptionsBuilder<SqlServerContext>()
            .UseInMemoryDatabase(databaseName: "Prueba2")
            .Options;

        SqlServerContext sqlServerContext = new(options);
        IResultado2Repository resultado2Repository = new Resultado2Repository(sqlServerContext);
        IUnitOfWorkRepository unitOfWorkRepository = new UnitOfWorkRepository(sqlServerContext);

        _sut = new(
            mockLogger.Object,
            unitOfWorkRepository,
            resultado2Repository
        );

        //act
        await _sut.ExecutePrueba2(request);

        //Assert
        Resultado2 resultado2 = sqlServerContext.Resultados2.First();
        resultado2.Description.Should().BeEquivalentTo(request.ParametroString);
    }
}