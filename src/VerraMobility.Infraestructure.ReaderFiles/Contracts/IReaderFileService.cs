public interface IReaderFileService: ITransientReader
{ 
    public Task<IEnumerable<string>> ReadFileTxtByLinesAsync();
}