using Microsoft.EntityFrameworkCore;
using VerraMobility.Infraestructure.Repository.Models.EntitiesRepository;
using VerraMobility.Infraestructure.Repository.Models.EntitiesTypeConfiguration;

namespace VerraMobility.Infraestructure.Repository.Models;

public class SqlServerContext(DbContextOptions<SqlServerContext> options) : DbContext(options)
{
    public DbSet<Resultado> Resultados { get; set; }
    public DbSet<Resultado2> Resultados2 { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ResultadoConfiguration());
        modelBuilder.ApplyConfiguration(new Resultado2Configuration());
    }
}