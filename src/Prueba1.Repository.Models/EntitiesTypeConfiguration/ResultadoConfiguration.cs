using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prueba1.Repository.Models.EntitiesRepository;

namespace Prueba1.Repository.Models.EntitiesTypeConfiguration;

public class ResultadoConfiguration : IEntityTypeConfiguration<Resultado>
{
    public void Configure(EntityTypeBuilder<Resultado> builder)
    {
        builder
            .Property(x => x.Description)
            .HasMaxLength(1000);
    }
}