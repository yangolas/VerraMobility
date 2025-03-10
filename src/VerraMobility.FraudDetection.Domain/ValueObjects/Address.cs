using Prueba2.Domain.Dictionaries;
using VerraMobility.FraudDetection.Domain.Enums;

namespace VerraMobility.FraudDetection.Domain.ValueObjects;

public record struct Address
{
    public string Street { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string State { get; private set; } = null!;
    public int ZipCode { get; private set; }
    public StatusAdress StatusAdress { get; private set; }

    public Address(
        string street,
        string city,
        string state,
        int zipCode)
    {
        SetStreet(street);
        SetCity(city);
        SetState(state);
        SetZipCode(zipCode);
    }

    private void SetStreet(string street)
    {
        NormalizeStreet(ref street);
        Street = street;
    }

    private void SetCity(string city)
    {
        NormalizeCity(ref city);
        City = city;
    }

    private void SetState(string state)
    {
        NormalizeState(ref state);
        State = state;
    }

    private void SetZipCode(int zipCode)
    {
        VerifyZipCodeGratherThanZero(zipCode);
        ZipCode = zipCode;
    }

    private static void NormalizeStreet(ref string street)
    {
        string[] parts = street.Split(' ');
        List<string> partsNormalized = [];
        for (int index = 0; index < parts.Length; index++)
        {
            string part = parts[index];
            if (Dictionary.StreetDictionary.TryGetValue(part, out var normalized))
            {
                part = normalized;
                partsNormalized.Add(part);
            }
            else
                partsNormalized.Add(part);
        }
        street = string.Join(" ", partsNormalized).ToUpper();
    }

    private static void NormalizeCity(ref string city)
    {
        city = city.ToUpper();
    }

    private static void NormalizeState(ref string state)
    {
        if (Dictionary.StateDictionary.TryGetValue(state, out var normalized))
            state = normalized.ToUpper();
    }

    private void VerifyZipCodeGratherThanZero(int zipCode)
    {
        if (zipCode < 0)
            StatusAdress = StatusAdress.NotValid;
    }
}