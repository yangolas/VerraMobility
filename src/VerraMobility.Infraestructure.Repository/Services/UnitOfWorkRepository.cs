using VerraMobility.Infraestructure.Repository.Contracts;
using VerraMobility.Infraestructure.Repository.Models;

namespace VerraMobility.Infraestructure.Repository.Services;

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
