namespace Prueba1.Repository.Contracts;

public interface IUnitOfWorkRepository : ITransientRepository
{
    public Task SaveChangesAsync();
}