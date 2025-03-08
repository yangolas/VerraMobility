public interface IReaderTxt: ITransientReader
{ 
    public Task<IEnumerable<string>> ReadFileTxtByLinesAsync();
}