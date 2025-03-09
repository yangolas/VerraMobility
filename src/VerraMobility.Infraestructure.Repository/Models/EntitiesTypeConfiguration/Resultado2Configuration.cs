using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerraMobility.Infraestructure.Repository.Models.EntitiesRepository;

namespace VerraMobility.Infraestructure.Repository.Models.EntitiesTypeConfiguration;

public class Resultado2Configuration : IEntityTypeConfiguration<Resultado2>
{
    public void Configure(EntityTypeBuilder<Resultado2> builder)
    {
        builder
            .Property(x => x.Description)
            .HasMaxLength(1000);
    }
}