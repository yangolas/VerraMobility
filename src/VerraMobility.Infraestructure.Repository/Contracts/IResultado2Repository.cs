using VerraMobility.Infraestructure.Repository.Models.EntitiesRepository;

namespace VerraMobility.Infraestructure.Repository.Contracts;

//Interface segregation
public interface IResultado2Repository : ITransientRepository
{
    public void CreateResultado(Resultado2 resultado);

    public void UpdateDescription(string description);

    public Task<Resultado2?> GetByIdsync(Guid id);
}