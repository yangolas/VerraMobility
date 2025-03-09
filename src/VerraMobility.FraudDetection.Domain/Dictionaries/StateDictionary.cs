namespace Prueba2.Domain.Dictionaries;

internal partial class Dictionary
{
    public static readonly Dictionary<string, string> StateDictionary = new(StringComparer.OrdinalIgnoreCase)
    {
        { "il", "illinois" },
        { "ca", "california" },
        { "ny", "new york" }
    };
}