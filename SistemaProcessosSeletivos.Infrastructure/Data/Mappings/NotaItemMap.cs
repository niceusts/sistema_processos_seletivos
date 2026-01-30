using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class NotaItemMap : IEntityTypeConfiguration<NotaItem>
{
    public void Configure(EntityTypeBuilder<NotaItem> builder)
    {
        builder.ToTable("NotaItem", "AVALIACAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.NotaAtribuida)
               .HasPrecision(10, 2);

        builder.Property(x => x.JustificativaTexto)
               .HasColumnType("nvarchar(max)");

        builder.HasOne<DistribuicaoAvaliacao>()
               .WithMany()
               .HasForeignKey(x => x.DistribuicaoAvaliacaoId);

        builder.HasOne<RegraPontuacao>()
               .WithMany()
               .HasForeignKey(x => x.RegraPontuacaoId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}
