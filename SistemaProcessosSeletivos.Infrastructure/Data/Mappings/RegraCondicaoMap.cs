using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RegraCondicaoMap : IEntityTypeConfiguration<RegraCondicao>
{
    public void Configure(EntityTypeBuilder<RegraCondicao> builder)
    {
        builder.ToTable("RegraCondicao", "CONFIG");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Operador)
               .IsRequired()
               .HasMaxLength(50)
               .HasColumnType("varchar(50)");

        builder.Property(x => x.ValorReferencia)
               .IsRequired()
               .HasMaxLength(100)
               .HasColumnType("varchar(100)");

        builder.HasOne<RegraPontuacao>()
               .WithMany()
               .HasForeignKey(x => x.RegraPontuacaoId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<CampoConfig>()
               .WithMany()
               .HasForeignKey(x => x.CampoConfigId);
    }
}
