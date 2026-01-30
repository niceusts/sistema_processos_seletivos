using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class RecursoMap : IEntityTypeConfiguration<Recurso>
{
    public void Configure(EntityTypeBuilder<Recurso> builder)
    {
        builder.ToTable("Recurso", "JURIDICO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.DataAbertura)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasOne<Inscricao>()
               .WithMany()
               .HasForeignKey(x => x.InscricaoId)
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne<EditalEtapa>()
               .WithMany()
               .HasForeignKey(x => x.EditalEtapaId);
    }
}
