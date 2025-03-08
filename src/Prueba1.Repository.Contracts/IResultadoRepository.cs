using Prueba1.Repository.Models.EntitiesRepository;

namespace Prueba1.Repository.Contracts;

//Interface segregation
public interface IResultadoRepository:ITransientRepository
{
    public void CreateResultado(Resultado resultado);

    public void UpdateDescription(string description);

    public Task<Resultado?> GetByIdsync(Guid id);
}