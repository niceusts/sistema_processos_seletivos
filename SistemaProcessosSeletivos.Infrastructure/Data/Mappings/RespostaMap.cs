using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RespostaMap : IEntityTypeConfiguration<Resposta>
{
    public void Configure(EntityTypeBuilder<Resposta> builder)
    {
        builder.ToTable("Resposta", "EXECUCAO");

        builder.HasKey(x => x.Id);

        builder.HasIndex(x => new { x.InscricaoId, x.CampoConfigId })
               .IsUnique();

        builder.HasOne(x => x.Inscricao)
               .WithMany(i => i.Respostas)
               .HasForeignKey(x => x.InscricaoId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<CampoConfig>()
               .WithMany()
               .HasForeignKey(x => x.CampoConfigId);
    }
}
