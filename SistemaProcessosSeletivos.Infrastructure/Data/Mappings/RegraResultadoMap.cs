using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RegraResultadoMap : IEntityTypeConfiguration<RegraResultado>
{
    public void Configure(EntityTypeBuilder<RegraResultado> builder)
    {
        builder.ToTable("RegraResultado", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Pontos)
               .HasPrecision(10, 2);

        builder.Property(x => x.PontosMaximos)
               .HasPrecision(10, 2);

        builder.HasIndex(x => x.RegraPontuacaoId)
               .IsUnique();

        builder.HasOne<RegraPontuacao>()
               .WithMany()
               .HasForeignKey(x => x.RegraPontuacaoId);
    }
}
