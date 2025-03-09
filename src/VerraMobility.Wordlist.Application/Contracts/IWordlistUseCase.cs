namespace VerraMobility.Wordlist.Application.Contracts;

public interface IWordlistUseCase : ITransientApplicationWordlist
{
    Task ExceuteWordlist();
}