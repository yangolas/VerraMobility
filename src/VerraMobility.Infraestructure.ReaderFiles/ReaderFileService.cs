
using Microsoft.Extensions.Options;
using VerraMobility.Shared.Settings;

namespace VerraMobility.Infraestructure.ReaderFiles;

public class ReaderFileService : IReaderFileService
{
    private readonly string _pathFileTxt;
    public ReaderFileService(
        IOptions<AppSettings> options)
    {
        _pathFileTxt = options.Value.ReaderTxt.Path;
    }

    public async Task<IEnumerable<string>> ReadFileTxtByLinesAsync()
    {
        string directory = Path.Combine(
            Directory.GetCurrentDirectory(),
            _pathFileTxt
        );

        return await File.ReadAllLinesAsync(directory);
    }

}