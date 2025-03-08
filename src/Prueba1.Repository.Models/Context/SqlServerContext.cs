using Microsoft.EntityFrameworkCore;
using Prueba1.Repository.Models.EntitiesRepository;
using Prueba1.Repository.Models.EntitiesTypeConfiguration;

namespace Prueba1.Repository.Models.Context;

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