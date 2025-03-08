using Prueba1.Repository.Contracts;
using Prueba1.Repository.Models.Context;

namespace Prueba1.Repository.Services;

public class UnitOfWorkRepository : IUnitOfWorkRepository
{
    private readonly SqlServerContext _sqlServerContext;

    public UnitOfWorkRepository(SqlServerContext userContext)
    {
        _sqlServerContext = userContext;
    }

    public async Task SaveChangesAsync()
    {
        await _sqlServerContext.SaveChangesAsync();
    }
}
