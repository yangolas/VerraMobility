using Prueba1.Repository.Models.EntitiesRepository;

namespace Prueba1.Repository.Contracts;

//Interface segregation
public interface IResultado2Repository : ITransientRepository
{
    public void CreateResultado(Resultado2 resultado);

    public void UpdateDescription(string description);

    public Task<Resultado2?> GetByIdsync(Guid id);
}