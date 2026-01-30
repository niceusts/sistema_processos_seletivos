using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

public class TipoProcessoMap : IEntityTypeConfiguration<TipoProcesso>
{
    public void Configure(EntityTypeBuilder<TipoProcesso> builder)
    {
        builder.ToTable("TipoProcesso", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnType("varchar(100)");

        builder.Property(x => x.RequerVagaReserva)
               .HasDefaultValue(false);

        builder.Property(x => x.RequerIntegracaoSalarial)
               .HasDefaultValue(false);
    }
}
