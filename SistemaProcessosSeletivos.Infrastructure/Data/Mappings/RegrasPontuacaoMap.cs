using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

public class RegraPontuacaoMap : IEntityTypeConfiguration<RegraPontuacao>
{
    public void Configure(EntityTypeBuilder<RegraPontuacao> builder)
    {
        builder.ToTable("RegraPontuacao", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(200)
               .HasColumnType("varchar(200)");

        builder.Property(x => x.TipoResultado)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

        builder.HasOne<EditalEtapa>()
               .WithMany()
               .HasForeignKey(x => x.EditalEtapaId);
    }
}
