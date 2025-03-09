using VerraMobility.Infraestructure.Repository.Models.EntitiesRepository;

namespace VerraMobility.Infraestructure.Repository.Contracts;

//Interface segregation
public interface IResultadoRepository : ITransientRepository
{
    public void CreateResultado(Resultado resultado);

    public void UpdateDescription(string description);

    public Task<Resultado?> GetByIdsync(Guid id);
}