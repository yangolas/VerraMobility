

using FluentAssertions;
using Prueba1.Domain.Entities;
using Prueba1.Domain.Exceptions;

namespace Prueba1.Domain.Test;

public class ParameterString
{
    private const string InvalidId = "The id is not valid";
    private const string InvalidInt = "The number is not valid must be gratter than 0";
    private const string InvalidString = "The string is not valid must be initialize";
    private const int _parametroInt = 1;

    [Fact]
    public void ShouldThrowExceptionInvalidRequiredApropiateNameNoNull()
    {
        const string? BadDescription = null;
        // Arrange and Act
        Exception exception = Assert.Throws<ExceptionDomain>(() =>
        {
            Entity entity = new(
                _parametroInt,
                BadDescription!
            );
        });

        // Assert
        exception.Message.Should().Be(InvalidString);
    }

    [Fact]
    public void ShouldThrowExceptionInvalidRequiredApropiateNameNoEmpty()
    {
        const string? BadDescription = "";
        // Arrange and Act
        Exception exception = Assert.Throws<ExceptionDomain>(() =>
        {
            Entity entity = new(
                _parametroInt,
                BadDescription!
            );
        });

        // Assert
        exception.Message.Should().Be(InvalidString);
    }

    [Fact]
    public void ShouldThrowExceptionInvalidRequiredACorrectDescription()
    {
        const string? BadDescription = " ";
        // Arrange and Act
        Exception exception = Assert.Throws<ExceptionDomain>(() =>
        {
            Entity entity = new(
                _parametroInt,
                BadDescription!
            );
        });

        // Assert
        exception.Message.Should().Be(InvalidString);
    }


    [Fact]
    public void ShouldPassRequiredApropiateName()
    {
        const string correctDescription = "this is an example";
        // Arrange and Act

        Entity entity = new(
            _parametroInt,
            correctDescription
        );


        // Assert
        entity.ParametroString.Should().Be(correctDescription);
    }
}