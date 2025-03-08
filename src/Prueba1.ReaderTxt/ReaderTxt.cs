
using Microsoft.Extensions.Options;
using Prueba1.Shared.Settings;

namespace Prueba1.ReaderTxt;

public class ReaderTxt : IReaderTxt
{
    private readonly string _pathFileTxt;
    public ReaderTxt(
        IOptions<AppSettings> options)
    {
        _pathFileTxt = options.Value.ReaderTxt.Path;
    }

    public async Task<IEnumerable<string>> ReadFileTxtByLinesAsync()
    {
        string path = Directory.GetCurrentDirectory();
        string directory = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..",
            "AlthiraAuthorization.Presentation.Write",
            _pathFileTxt
        );

        return await File.ReadAllLinesAsync(directory);
    }

}