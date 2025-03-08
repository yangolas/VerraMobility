using Prueba2.Domain.Enums;
using Prueba2.Domain.Exceptions;
using Prueba2.Domain.ValueObjects;

namespace Prueba2.Domain.Entities;

public class Entity
{
    private const string InvalidId = "The id is not valid";
    private const string InvalidInt = "The number is not valid must be gratter than 0";
    private const string InvalidString = "The string is not valid must be initialize";
    public Guid Id { get; set; }
    public ValueObject ValueObject { get; set; } = null!;
    public Enumerado Enumerado { get; set; }
    public int ParametroInt { get; set; }
    public string ParametroString { get; set; } = null!;
    public Entity(
        int parametroInt,
        string parametroString)
    {
        SetId(Guid.NewGuid());
        SetInt(parametroInt);
        SetString(parametroString);
    }
    public void SetInt(int number)
    {
        VerifyIntGratterThanZero(number);
        ParametroInt = number;
    }

    public void SetString(string text)
    {
        VerifyStringIsInitialize(text);
        ParametroString = text;
    }

    public void SetId(Guid id)
    {
        VerifyGuidIsInitialize(id);
        Id = id;
    }

    private static void VerifyGuidIsInitialize(Guid guid)
    {
        if (guid == Guid.Empty)
        {
            throw new ExceptionDomain(InvalidId);
        }
    }

    private static void VerifyStringIsInitialize(string text)
    {
        if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
        {
            throw new ExceptionDomain(InvalidString);
        }
    }

    private static void VerifyIntGratterThanZero(int number)
    {
        if (number <= 0)
        {
            throw new ExceptionDomain(InvalidInt);
        }
    }

}