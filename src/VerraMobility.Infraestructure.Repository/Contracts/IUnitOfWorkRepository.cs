namespace VerraMobility.Infraestructure.Repository.Contracts;

public interface IUnitOfWorkRepository : ITransientRepository
{
    public Task SaveChangesAsync();
}