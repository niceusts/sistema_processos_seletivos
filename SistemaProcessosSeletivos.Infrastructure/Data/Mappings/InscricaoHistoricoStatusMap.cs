using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaProcessosSeletivos.Domain.Entities;

namespace SistemaProcessosSeletivos.Infrastructure.Data.Mappings;

public class InscricaoHistoricoStatusMap : IEntityTypeConfiguration<InscricaoHistoricoStatus>
{
    public void Configure(EntityTypeBuilder<InscricaoHistoricoStatus> builder)
    {
        builder.ToTable("inscricao_historico_status", "EXECUCAO");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Justificativa)
               .IsRequired();

        builder.Property(x => x.DataAlteracao)
               .HasDefaultValueSql("SYSDATETIME()");

        builder.HasOne<Inscricao>()
               .WithMany()
               .HasForeignKey(x => x.InscricaoId);

        builder.HasOne(x => x.StatusAnterior)
               .WithMany()
               .HasForeignKey("StatusAnteriorId")
               .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.StatusNovo)
               .WithMany()
               .HasForeignKey("StatusNovoId")
               .OnDelete(DeleteBehavior.NoAction);
    }
}
