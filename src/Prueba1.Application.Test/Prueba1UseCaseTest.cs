using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Prueba1.Application.Model;
using Prueba1.Application.Services;
using Prueba1.Repository.Contracts;
using Prueba1.Repository.Models.Context;
using Prueba1.Repository.Models.EntitiesRepository;
using Prueba1.Repository.Repositories;
using Prueba1.Repository.Services;

namespace Prueba1.Application.Test
{
    public class Prueba1UseCaseTest
    {
        private readonly string ParametroString = "this is an example";
        private UseCase _sut = null!;

        [Fact]
        public async Task ShouldCreateAPrueba2RequiredACorrectPrueba2Dto()
        {
            ////Arrange
            //Prueba1Dto request = new()
            //{
            //    ParametroInt = 1,
            //    ParametroString = "this is an example",
            //};


            //Mock<ILogger<UseCase>> mockLogger = new();
            //mockLogger
            //    .Setup(log => log.Log(
            //        It.IsAny<LogLevel>(),
            //        It.IsAny<EventId>(),
            //        It.IsAny<object>(),
            //        It.IsAny<Exception>(),
            //        It.IsAny<Func<object, Exception, string>>()!)
            //    )
            //    .Verifiable();


            //DbContextOptions<SqlServerContext> options = new DbContextOptionsBuilder<SqlServerContext>()
            //    .UseInMemoryDatabase(databaseName: "Prueba2")
            //    .Options;

            //SqlServerContext sqlServerContext = new(options);
            //IResultadoRepository resultado2Repository = new ResultadoRepository(sqlServerContext);
            //IUnitOfWorkRepository unitOfWorkRepository = new UnitOfWorkRepository(sqlServerContext);

            //_sut = new(
            //    mockLogger.Object,
            //    unitOfWorkRepository,
            //    resultado2Repository
            //);

            ////act
            //await _sut.TextProcess(request);

            ////Assert
            //Resultado resultado = sqlServerContext.Resultados.First();
            //resultado.Description.Should().BeEquivalentTo(request.ParametroString);
        }
    }
}