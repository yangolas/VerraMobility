using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerraMobility.Infraestructure.Repository.Models.EntitiesRepository;

namespace VerraMobility.Infraestructure.Repository.Models.EntitiesTypeConfiguration;

public class ResultadoConfiguration : IEntityTypeConfiguration<Resultado>
{
    public void Configure(EntityTypeBuilder<Resultado> builder)
    {
        builder
            .Property(x => x.Description)
            .HasMaxLength(1000);
    }
}