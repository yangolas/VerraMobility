using Prueba2.Domain.Dictionaries;
using Prueba2.Domain.Enums;

namespace Prueba2.Domain.ValueObjects;

public record struct Address
{
    public string Street { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public int ZipCode { get; set; }
    public StatusAdress StatusAdress { get; set; }
    
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

    public void SetStreet(string street)
    {
        NormalizeStreet(ref street);
        Street = street;
    }

    public void SetCity(string city)
    {
        NormalizeCity(ref city);
        City = city;
    }

    public void SetState(string state)
    {
        NormalizeState(ref state);
        State = state;
    }

    public void SetZipCode(int zipCode) 
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
        street = (string.Join(" ", partsNormalized)).ToUpper();
    }

    private static void NormalizeCity(ref string city)
    {
        city = city.ToUpper();
    }

    private static void NormalizeState(ref string state)
    {
        if(Dictionary.StateDictionary.TryGetValue(state, out var normalized))
            state = normalized.ToUpper();
    }

    private void VerifyZipCodeGratherThanZero(int zipCode)
    {
        if (zipCode < 0)
            StatusAdress = StatusAdress.NotValid;
    }
}