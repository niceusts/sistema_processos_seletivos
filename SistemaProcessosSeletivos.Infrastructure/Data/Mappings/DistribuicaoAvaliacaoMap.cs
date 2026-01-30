using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class DistribuicaoAvaliacaoMap : IEntityTypeConfiguration<DistribuicaoAvaliacao>
{
    public void Configure(EntityTypeBuilder<DistribuicaoAvaliacao> builder)
    {
        builder.ToTable("DistribuicaoAvaliacao", "AVALIACAO");

        builder.HasKey(x => x.Id);

        builder.HasOne<Inscricao>()
               .WithMany()
               .HasForeignKey(x => x.InscricaoId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<BancaMembro>()
               .WithMany()
               .HasForeignKey(x => x.BancaMembroId);
    }
}
