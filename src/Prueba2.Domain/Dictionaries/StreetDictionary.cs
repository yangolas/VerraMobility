namespace Prueba2.Domain.Dictionaries;

internal partial class Dictionary
{
    public static readonly Dictionary<string, string> StreetDictionary = new(StringComparer.OrdinalIgnoreCase)
    {
        { "st.", "street" },
        { "rd.", "road" },
    };
}